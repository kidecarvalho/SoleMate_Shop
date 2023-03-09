using Microsoft.AspNetCore.Mvc;
using SoleMate.Infrastructure;
using SoleMate.Models.ViewModels;
using SoleMate.Helpers;
using SoleMate.Models;
using Stripe;

namespace SoleMate.Controllers
{
    public class CheckoutController : Controller
    {
        [TempData]
        public string TotalAmount { get; set; }
        public IActionResult Index()
        {
            // var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            /*  ViewBag.cart = cart;
              ViewBag.DollarAmount = cart.Sum(x => x.Quantity * x.Price);
              ViewBag.total = Math.Round(ViewBag.DollarAmount, 2) * 100;
              ViewBag.total = Convert.ToInt64(ViewBag.total);
              long total = ViewBag.total;
              TotalAmount = total.ToString();
              return View();*/

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal = Convert.ToInt64(Math.Round(cart.Sum(x => x.Quantity * x.Price), 2) * 100),
            };
            // long total = cartVM.GrandTotal;
            TotalAmount = cartVM.GrandTotal.ToString();
            return View(cartVM);
        }
        [HttpPost]
        public IActionResult Processing(string stripeToken, string stripeEmail)
        {
            var optionsCust = new CustomerCreateOptions
            {
                Email = stripeEmail,
                Name = "Kundi",
                Phone = "4169876543"

            };
            var serviceCust = new CustomerService();
            Customer customer = serviceCust.Create(optionsCust);
            var optionsCharge = new ChargeCreateOptions
            {
                /*Amount = HttpContext.Session.GetLong("Amount")*/
                Amount = Convert.ToInt64(TempData["TotalAmount"]),
                Currency = "CAD",
                Description = "Buying Sneakers",
                Source = stripeToken,
                ReceiptEmail = stripeEmail
            };
            var service = new ChargeService();
            Charge charge = service.Create(optionsCharge);
            if (charge.Status == "succeeded")
            {
                string BalanceTransactionId = charge.BalanceTransactionId;
                ViewBag.AmountPaid = Convert.ToDecimal(charge.Amount) % 100 / 100 + (charge.Amount) / 100;
                ViewBag.BalanceTxId = BalanceTransactionId;
                ViewBag.Customer = customer.Name;
                //return View();
            }



            return View();
        }
    }
}

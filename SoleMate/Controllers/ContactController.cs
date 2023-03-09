using Microsoft.AspNetCore.Mvc;
using SoleMate.Infrastructure;
using SoleMate.Models;

namespace SoleMate.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactFormRepository _contactFormRepository;

        public ContactController(IContactFormRepository contactFormRepository)
        {
            _contactFormRepository = contactFormRepository;
        }

        public IActionResult Index()
        {
            var allContactForms = _contactFormRepository.GetAllContactForms();
            return View(allContactForms);
        }

        [HttpPost]
        public IActionResult SubmitContactForm(ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                _contactFormRepository.AddContactForm(contactForm);
                return RedirectToAction("Index");
            }

            return View("ContactForm", contactForm);
        }
    }
}

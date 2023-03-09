using SoleMate.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace SoleMate.Models
{
    public class ContactFormRepository : IContactFormRepository
    {
        private readonly DataContext _context;

        public ContactFormRepository(DataContext context)
        {
            _context = context;
        }

        public ContactForm GetContactForm(int id)
        {
            return _context.ContactForms.Find(id);
        }

        public IEnumerable<ContactForm> GetAllContactForms()
        {
            return _context.ContactForms.ToList();
        }

        public void AddContactForm(ContactForm contactForm)
        {
            _context.ContactForms.Add(contactForm);
            _context.SaveChanges();
        }

        public void UpdateContactForm(ContactForm contactForm)
        {
            _context.ContactForms.Update(contactForm);
            _context.SaveChanges();
        }

        public void DeleteContactForm(int id)
        {
            var contactForm = _context.ContactForms.Find(id);
            _context.ContactForms.Remove(contactForm);
            _context.SaveChanges();
        }
    }
}

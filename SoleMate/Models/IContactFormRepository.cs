using SoleMate.Infrastructure;
using System.Collections.Generic;

namespace SoleMate.Models
{
    public interface IContactFormRepository
    {
        ContactForm GetContactForm(int id);
        IEnumerable<ContactForm> GetAllContactForms();
        void AddContactForm(ContactForm contactForm);
        void UpdateContactForm(ContactForm contactForm);
        void DeleteContactForm(int id);
    }
}

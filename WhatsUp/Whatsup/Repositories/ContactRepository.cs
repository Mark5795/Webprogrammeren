using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WhatsUp.Models;
using Whatsup.Models;

namespace Whatsup.Repositories
{
    public class ContactRepository : IContactRepository
    {

        private WhatsupContext db = new WhatsupContext();

        public User GetContact(string Email)
        {
            User user = db.Users.SingleOrDefault(i => i.Email == Email);
            return user;
        }

        //public ContactViewModel GetContactUserViewModel() => new ContactViewModel(GetContact());

        public void AddContact(int OwnerAccountId, Contact contact)
        {
            db.Users.Single(a => a.Id == OwnerAccountId).Contacts.Add(contact);
            db.SaveChanges();
        }

        public void DeleteContact(int ContactAccountId)
        {
            Contact contact = db.Contact.Find(ContactAccountId);
            db.Contact.Remove(contact);
            db.SaveChanges();
        }

        public IEnumerable<ContactViewModel> GetAllContacts(int OwnerAccountId)
        {
            List<ContactViewModel> contactViewModels = new List<ContactViewModel>();
            List<Contact> contacts = db.Users.SingleOrDefault(a => a.Id == OwnerAccountId).Contacts.ToList();

            for (int i = 0; i < contacts.Count; i++)
                contactViewModels.Add(new ContactViewModel(contacts[i], i));

            return contactViewModels;
        }

        //public void GetContactAccoundID(int )
        //{

        //}

        //public IList<SelectContactViewModel> GetAllContacts(int OwnerAccountId)
        //{
        //    List<SelectContactViewModel> selectContactViewModel = new List<SelectContactViewModel>();
        //    List<Contact> contacts = db.Users.SingleOrDefault(a => a.Id == OwnerAccountId).Contacts.ToList();

        //    for (int i = 0; i < contacts.Count; i++)
        //    {
        //        selectContactViewModel.Add(new SelectContactViewModel(contacts[i], i));
        //    }

        //    return selectContactViewModel;
        //}

    }
}
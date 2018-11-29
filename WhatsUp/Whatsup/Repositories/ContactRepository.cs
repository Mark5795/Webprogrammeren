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

        public Contact GetContact(int OwnerAccountId, int Index)
        {
            return db.Users.Single(a => a.Id == OwnerAccountId).Contacts.ToList()[Index];
        }

        public Contact GetContactFromContactAccountId(int ContactAccountId)
        {
            return db.Contact.SingleOrDefault(a => a.ContactAccountId == ContactAccountId);
        }

        public void AddContact(int OwnerAccountId, Contact contact)
        {
            db.Users.Single(a => a.Id == OwnerAccountId).Contacts.Add(contact);
            db.SaveChanges();
        }

        public void EditContact(int OwnerAccountId, ContactViewModel model)
        {
            Contact editContact = GetContact(OwnerAccountId, model.Index);
            editContact.ContactAccountId = db.Users.SingleOrDefault(a => a.Email == model.Email).Id;
            editContact.NickName = model.NickName;
            db.SaveChanges();
        }

        public void DeleteContact(int ContactAccountId, int Index)
        {
            Contact contact = db.Users.Single(a => a.Id == ContactAccountId).Contacts.ToList()[Index];
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

        public IList<ChooseContactViewModel> GetChooseContactViewModels(int ownerId)
        {
            List<ChooseContactViewModel> chooseContactViewModels = new List<ChooseContactViewModel>();
            List<Contact> contacts = db.Users.SingleOrDefault(a => a.Id == ownerId).Contacts.ToList();

            for (int i = 0; i < contacts.Count; i++)
                chooseContactViewModels.Add(new ChooseContactViewModel(contacts[i], i));

            return chooseContactViewModels;
        }
    }
}
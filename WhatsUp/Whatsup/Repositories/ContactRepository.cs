using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsup.Models;
using System.Data.Entity;

namespace Whatsup.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private WhatsupContext db = new WhatsupContext();
        public IEnumerable<Contact> Contact { get { return db.Contacts; } }


        public IEnumerable<Contact> GetAllContacts()
        {
            IEnumerable<Contact> contacts = db.Contacts/*.Include(a => a.Contact)*/;
            return contacts;
        }

        public Contact GetContact(int contactId)
        {
            Contact contact = db.Contacts.Find(contactId);
            return contact;
        }

        public void AddContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        public void RemoveContact(int contactId)
        {
            Contact contact = db.Contacts.Find(contactId);
            db.Contacts.Remove(contact);
            db.SaveChanges();
        }

        public void EditContact(Contact contact)
        {
            db.Entry(contact).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            db.Dispose();
        }

    }
}
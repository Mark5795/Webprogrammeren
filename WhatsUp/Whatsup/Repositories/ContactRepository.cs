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

        //public User GetContact(string Username)
        //{
        //    User user = db.Users.SingleOrDefault(i => i.UserName == Username);
        //    return user;
        //}

        public void AddContact(int OwnerAccountId, Contact contact)
        {
            db.Users.Single(a => a.Id == OwnerAccountId).Contacts.Add(contact);
            db.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsup.Models;

namespace Whatsup.Repositories
{
    interface IContactRepository
    {
        IEnumerable<Contact> Contact { get; }

        IEnumerable<Contact> GetAllContacts();
        Contact GetContact(int ContactId);
        void AddContact(Contact contact);
        void RemoveContact(int concactId);
        void EditContact(Contact contact);
        void Dispose(bool disposing);
    }
}
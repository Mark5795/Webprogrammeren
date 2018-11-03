using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsup.Models;
using WhatsUp.Models;

namespace Whatsup.Repositories
{
    public interface IContactRepository
    {
        User GetContact(string Email);
        //ContactViewModel GetContactUserViewModel();
        void AddContact(int OwnerId, Contact contact);
        void DeleteContact(int ContactAccountId);
        IEnumerable<ContactViewModel> GetAllContacts(int OwnerAccountId);
        //IList<SelectContactViewModel> GetAllContacts(int OwnerAccountId);
    }
}
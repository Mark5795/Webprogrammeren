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
        Contact GetContact(int OwnerAccountId, int Index);
        Contact GetContactFromContactAccountId(int ContactAccountId);
        //ContactViewModel GetContactUserViewModel();
        void AddContact(int OwnerId, Contact contact);
        void EditContact(int OwnerAccountId, ContactViewModel model);
        void DeleteContact(int ContactAccountId, int Index);
        IEnumerable<ContactViewModel> GetAllContacts(int OwnerAccountId);
        IList<ChooseContactViewModel> GetChooseContactViewModels(int ownerId);
    }
}
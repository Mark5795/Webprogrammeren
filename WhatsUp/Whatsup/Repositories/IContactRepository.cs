using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUp.Models;

namespace Whatsup.Repositories
{
    public interface IContactRepository
    {
        void AddContact(int OwnerId, Contact contact);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsup.Models;
using System.Data.Entity;

namespace Whatsup.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private WhatsupContext db = new WhatsupContext();

        public void AddAccount(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
        }
    }
}
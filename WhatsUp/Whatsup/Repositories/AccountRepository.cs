using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsup.Models;
using System.Data.Entity;

namespace Whatsup.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private WhatsupContext db = new WhatsupContext();
        //public IEnumerable<Account> Account { get { return db.Accounts; } }
        public IEnumerable<Account> Account { get { return null; } }

        public Account GetAccount(string EmailAddress, string Password)
        {
            //Account account = db.Contacts.Find(EmailAddress, Password);
            //return account;
            return null;
        }
    }
}
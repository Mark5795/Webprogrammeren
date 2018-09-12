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
        public IEnumerable<Account> Account { get { return db.Accounts; } }

        public bool AlreadyRegistered(string EmailAddress)
        {
            if (db.Accounts.Any(i => i.EmailAddress == EmailAddress))
                return true;
            else
                return false;
        }

        public bool ValidCredentials(Login loginmodel)
        {
            if (AlreadyRegistered(loginmodel.EmailAddress))
            {
                if (GetAccount(loginmodel.EmailAddress).Password == loginmodel.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Account GetAccount(string EmailAddress)
        {
            Account account = db.Accounts.SingleOrDefault(i => i.EmailAddress == EmailAddress);
            return account;
        }

        public void AddAccount(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
        }
    }
}
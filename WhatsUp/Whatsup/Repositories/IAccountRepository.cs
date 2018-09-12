using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsup.Models;

namespace Whatsup.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<Account> Account { get; }

        //void Login(Account account);
        void AddAccount(Account account);

        //bool AlreadyRegistered(string email);
        bool ValidCredentials(Login loginmodel);
        Account GetAccount(string EmailAddress);
        //IEnumerable<Account> GetAll();
        //void AddAccount(Account account);
    }
}
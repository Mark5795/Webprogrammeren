using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsup.Models;

namespace Whatsup.Repositories
{
    interface IAccountRepository
    {
        IEnumerable<Account> Account { get; }

        //void Login(Account account);
        Account GetAccount(string EmailAddress, string Password);

    }
}
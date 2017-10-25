using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsup.Models;

namespace Whatsup.Repositories
{
    interface IRegisterRepository
    {
        void AddAccount(Account account);
    }
}
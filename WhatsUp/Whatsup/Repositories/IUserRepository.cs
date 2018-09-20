using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsup.Models;

namespace Whatsup.Repositories
{
    public interface IUserRepository
    {
        bool AlreadyRegistered(string email);
        IEnumerable<User> user { get; }
        void AddUser(User user);
        User GetUser(string Email);
    }
}
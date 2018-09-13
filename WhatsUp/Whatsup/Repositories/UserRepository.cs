using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsup.Models;
using System.Data.Entity;

namespace Whatsup.Repositories
{
    public class UserRepository : IUserRepository
    {
        private WhatsupContext db = new WhatsupContext();
        public IEnumerable<User> user { get { return db.Users; } }

        public bool AlreadyRegistered(string Email)
        {
            if (db.Users.Any(i => i.Email == Email))
                return true;
            else
                return false;
        }

        public User GetUser(string Email)
        {
            User user = db.Users.SingleOrDefault(i => i.Email == Email);
            return user;
        }

        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}
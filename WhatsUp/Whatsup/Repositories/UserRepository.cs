using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WhatsUp.Models;
using Whatsup.Models;

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

        public bool ValidCredentials(LoginUserViewModel model)
        {
            if (AlreadyRegistered(model.Email))
            {
                if (GetUser(model.Email).PasswordHash == model.PasswordHash)
                        return true;
                else
                    return false;
            }
            else
                return false;
        }

        public User GetUser(string Email)
        {
            User user = db.Users.SingleOrDefault(i => i.Email == Email);
            return user;
        }

        public byte[] GetSalt(string Email)
        {
            byte[] Salt = db.Users.SingleOrDefault(i => i.Email == Email).Salt;
            return Salt;
        }

        public DateTime GetDateCreated(string Email)
        {
            DateTime DateCreated = db.Users.SingleOrDefault(i => i.Email == Email).DateCreated;
            return DateCreated;
        }

        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}
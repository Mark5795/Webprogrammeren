using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsup.Models;
using WhatsUp.Models;

namespace Whatsup.Repositories
{
    public interface IUserRepository
    {
        bool AlreadyRegistered(string email);
        bool ValidCredentials(LoginUserViewModel model);
        IEnumerable<User> user { get; }
        void AddUser(User user);
        byte[] GetSalt(string Email);
        User GetUser(string Email);
        User GetUserById(int Id);
        DateTime GetDateCreated(string Email);
        User GetProfileUser(int Id);
        int GetLoggedInUser();
        ProfileUserViewModel GetProfileUserViewModel();
        void AddNewPassword(LoginUserViewModel model);
        void EditUser(ProfileUserViewModel model);
        void DeleteUser(int UserId);
    }
}
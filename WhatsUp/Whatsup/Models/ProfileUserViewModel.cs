using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsup.Repositories;

namespace Whatsup.Models
{
    public class ProfileUserViewModel
    {
        private IUserRepository userRepository = new UserRepository();
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime DateCreated { get { return userRepository.GetDateCreated(Email); } }
    }
}
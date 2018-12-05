using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Whatsup.Repositories;

namespace Whatsup.Models
{
    public class ProfileUserViewModel
    {
        private IUserRepository userRepository = new UserRepository();

        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public ProfileUserViewModel() { }

        public ProfileUserViewModel(User user)
        {
            Username = user.UserName;
            Email = user.Email;
            DateCreated = user.DateCreated;
        }

        public ProfileUserViewModel(int Id)
        {
            this.Id = Id;
        }
    }
}
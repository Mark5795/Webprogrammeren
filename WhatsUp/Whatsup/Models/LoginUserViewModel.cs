
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Whatsup;
using Whatsup.Repositories;
using Whatsup.Models;

namespace WhatsUp.Models
{
    public class LoginUserViewModel
    {
        private IUserRepository userRepository = new UserRepository();

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        public string PasswordHash { get { return Hash.Encrypt(Password, userRepository.GetSalt(Email)); } }

        //Get new Salt
        public byte[] Salt = Hash.GetRandomSalt();

        //Make new hash
        public string NewHashedPassword { get { return Hash.Encrypt(Password, Salt); } }

        public LoginUserViewModel()
        {

        }

        public LoginUserViewModel(User user)
        {
            Email = user.Email;
        }
    }
}
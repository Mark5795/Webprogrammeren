
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Whatsup;
using Whatsup.Repositories;

namespace WhatsUp.Models
{
    public class LoginUserViewModel
    {
        private IUserRepository userRepository = new UserRepository();

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public string PasswordHash { get { return Hash.Encrypt(Password, userRepository.GetSalt(Email)); } }

        //Get new Salt
        public byte[] Salt = Hash.GetRandomSalt();

        //Make new hash
        public string NewHashedPassword { get { return Hash.Encrypt(Password, Salt); } }
    }
}
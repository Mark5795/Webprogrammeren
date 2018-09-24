using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Cryptography;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whatsup.Models
{
    public class CreateUserViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string PasswordHash { get { return Hash.Encrypt(Password); } }

        //[Required]
        //public DateTime DateCreated { get { return new DataColumn("Date", typeof(DateTime)); } }

        [Required]
        public DateTime DateCreated { get { return DateTime.Now; } }

    }
}
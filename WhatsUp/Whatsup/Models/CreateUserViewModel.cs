using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

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

        public byte[] s = Hash.GenerateSalt();
        public string salt = Convert.ToBase64String(s);
        public string PasswordHash = Hash.ComputeHMAC_SHA256(Encoding.UTF8.GetBytes("Password"), salt);

    }
}
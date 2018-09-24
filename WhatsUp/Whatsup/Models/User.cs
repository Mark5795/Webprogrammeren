using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Whatsup.Models
{
    public partial class User
    {
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        public int EmailConfirmed { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public int PhoneNumberConfirmed { get; set; }
        public int TwoFactorEnabled { get; set; }
        public DateTime LockoutEndDateUtc { get; set; }
        public int LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        [Required]
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }

        public User(string UserName, string Email, string PhoneNumber, string PasswordHash)
        {
            this.UserName = UserName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.PasswordHash = PasswordHash;
        }

        //voor linken naar ander model
        //public virtual ICollection<Contact> Contacts { get; set; }
    }
}
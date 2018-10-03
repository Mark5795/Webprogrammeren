using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WhatsUp.Models;

namespace Whatsup.Models
{
    public class ContactViewModel
    {
        
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ContactViewModel() { }

        public ContactViewModel(string Name, string Email)
        {
            this.Name = Name;
            this.Email = Email;
        }

        public ContactViewModel(Contact contact)
        {
            Name = contact.Name;
            Email = contact.ContactAccount.Email;
        }
    }
}
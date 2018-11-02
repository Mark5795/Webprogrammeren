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
        public int Index { get; set; }

        public string NickName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ContactViewModel() { }

        public ContactViewModel(string NickName, string Email)
        {
            this.NickName = NickName;
            this.Email = Email;
        }

        public ContactViewModel(Contact contact)
        {
            NickName = contact.NickName;
            Email = contact.ContactAccount.Email;
        }

        public ContactViewModel(Contact contact, int index) : this(contact)
        {
            Index = index;
        }
    }
}
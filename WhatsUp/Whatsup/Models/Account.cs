using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whatsup.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobilNumber { get; set; }
        public string emailAddress { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
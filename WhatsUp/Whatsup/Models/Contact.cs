using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whatsup.Models
{
    public class Contact
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string PhoneNumber { get; set; }

        public int OwnerAccountId { get; set; }
        public virtual Account OwnerAccount { get; set; }
    }
}
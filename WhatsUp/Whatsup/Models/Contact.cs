using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Whatsup.Models;

namespace WhatsUp.Models
{
    [Table("Contact")]
    public partial class Contact
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public int OwnerAccountId { get; set; }
        public int ContactAccountId { get; set; }

        public virtual User OwnerAccount { get; set; }
        public virtual User ContactAccount { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Whatsup.Models;
using WhatsUp.Models;

namespace Whatsup.Models
{
    [Table("Chat")]
    public partial class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Group { get; set; }
        public int CreatorId { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual User Creator { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<User> Members { get; set; }

        public Chat() { }
    }
}
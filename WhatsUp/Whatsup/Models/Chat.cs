using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whatsup.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public Account SenderId { get; set; }
        public Account ReceiverId { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Account OwnerAccount { get; set; }
    }
}
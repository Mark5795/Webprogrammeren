using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Whatsup.Models;

namespace WhatsUp.Models
{
    [Table("Message")]
    public partial class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime TimeSend { get; set; }
        [Required]
        public string Content { get; set; }
        //public int ChatId { get; set; }
        //public int SenderId { get; set; }

        //public virtual User Sender { get; set; }
        //public virtual Chat Chat { get; set; }

        public Message() { }

        public Message(string Content)
        {
            this.TimeSend = DateTime.Now;
            this.Content = Content;
            //this.SenderId = SenderId;
            //this.ChatId = ChatId;
        }
    }
}
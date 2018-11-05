using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class MessageViewModel
    {
        public string SentOn { get; set; }
        public string Content { get; set; }
        public string SenderName { get; set; }
        public bool IsSender { get; set; }
        
        public MessageViewModel()
        {
        }

        public MessageViewModel(Message message)
        {
            SentOn = message.CreatedOn.ToLongDateString();
            Content = message.Content;
        }

        public MessageViewModel(int userId, string name, Message message) : this(message)
        {
            if (userId == message.SenderId)
                IsSender = true;
            SenderName = name;
        }
    }
}
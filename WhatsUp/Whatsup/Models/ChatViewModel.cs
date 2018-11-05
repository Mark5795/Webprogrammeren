using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsup.Repositories;
using WhatsUp.Models;

namespace Whatsup.Models
{
    public class ChatViewModel
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public bool AllMessages { get; set; }
        public string Content { get; set; }
        public List<MessageViewModel> Reader { get; set; }

        public ChatViewModel() { }

        public ChatViewModel(Message message)
        {
            Content = message.Content;
        }

    }
}
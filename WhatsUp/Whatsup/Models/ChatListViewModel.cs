using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Whatsup.Models;

namespace WhatsUp.Models
{
    public class ChatListViewModel
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string LastMessage { get; set; }

        public ChatListViewModel() { }

        public ChatListViewModel(Chat chat)
        {
            Name = chat.Name;
            if (chat.Messages == null)
            {
                LastMessage = "No messages";
            }
            else if (chat.Messages.Count == 0)
            {
                LastMessage = "No messages";
            }                
            else
            {
                LastMessage = chat.Messages.Last().Content;
            }                
        }

        public ChatListViewModel(Chat chat, int index) : this(chat)
        {
            Index = index;
        }
    }
}
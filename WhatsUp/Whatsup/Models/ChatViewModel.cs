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
        public string Content { get; set; }
        public List<MessageViewModel> Reader { get; set; }

        public ChatViewModel() { }

        public ChatViewModel(int userId, int index, IDictionary<int, string> usernames, ICollection<Message> messageList, string name)
        {
            List<MessageViewModel> messages = new List<MessageViewModel>();

            Index = index;
            Reader = messages;
            Name = name;
        }

        //public ChatViewModel(Chat chat)
        //{

        //}

        //public ChatViewModel(Chat chat, int index) : this(chat)
        //{
        //    Index = index;
        //}

    }
}
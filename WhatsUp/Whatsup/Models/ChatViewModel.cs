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
        private IUserRepository userRepository = new UserRepository();

        //public string Name { get; set; }
       //public int Index { get; set; }
       //public bool AllMessages { get; set; }
        //public string Content { get; set; }
        //public List<MessageViewModel> Reader { get; set; }
        //public IDictionary<int, string> Usernames { get; set; }

        public DateTime TimeSend { get; set; }
        public string Content { get; set; }


        public ChatViewModel() { }

        public ChatViewModel(Message message)
        {

        }

    }
}
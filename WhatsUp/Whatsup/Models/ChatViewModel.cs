using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsup.Repositories;

namespace Whatsup.Models
{
    public class ChatViewModel
    {
        private IUserRepository userRepository = new UserRepository();

        public string Name { get; set; }
        public int Index { get; set; }
        public bool AllMessages { get; set; }
        public string Content { get; set; }
        //public List<MessageViewModel> Reader { get; set; }
        //public IDictionary<int, string> Usernames { get; set; }

        public ChatViewModel() { }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public IDictionary<int, string> Usernames { get; set; }

        public ChatViewModel() { }

        public ChatViewModel(int userId, int index, IDictionary<int, string> usernames, ICollection<Message> messageList, string name)
        {
            List<MessageViewModel> messages = new List<MessageViewModel>();
            Usernames = new Dictionary<int, string>();

            try
            {
                AddUserNamesToMessageViewModels(userId, usernames, messageList, ref messages);
            }
            catch (ArgumentNullException e) { } // Empty chat

            Index = index;
            Reader = messages;
            Name = name;
            Usernames = usernames;
        }

        private void AddUserNamesToMessageViewModels(int userId, IDictionary<int, string> usernames, ICollection<Message> messageList, ref List<MessageViewModel> messages)
        {
            foreach (Message message in messageList)
            {
                messages.Add(new MessageViewModel(userId, usernames[message.SenderId], message));
            }
        }
    }
}
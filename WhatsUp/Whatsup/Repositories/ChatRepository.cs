using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsup.Models;
using WhatsUp.Models;

namespace Whatsup.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private WhatsupContext db = new WhatsupContext();

        public void AddChat(int CreatorId, Chat chat)
        {
            db.Users.Single(a => a.Id == CreatorId).Chats.Add(chat);
            db.SaveChanges();
        }

        public void AddMessage(int SenderId,Message message)
        {
            //db.Message.Add(message);
            //db.Users.Single(a => a.Id == SenderId).Chats.Add(message);
            //db.SaveChanges();
        }

        public IEnumerable<ContactViewModel> GetAllChats(int CreatorId)
        {
            List<ChatViewModel> chatViewModels = new List<ChatViewModel>();
            List<Chat> chats = db.Users.SingleOrDefault(a => a.Id == CreatorId).Chats.ToList();

            for (int i = 0; i < chats.Count; i++)
                chatViewModels.Add(new ChatViewModel(chats[i], i));

            return chatViewModels;
        }
    }
}
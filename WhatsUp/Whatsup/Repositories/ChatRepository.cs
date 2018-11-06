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

        public void AddMessage(Message message)
        {
            db.Message.Add(message);
            db.SaveChanges();
        }

        //public List<Message> GetAllMessages()
        //{
            
        //}
    }
}
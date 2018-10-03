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

        public void AddNewMessage(Message message)
        {
            db.Message.Add(message);
            db.SaveChanges();
        }

        //public List<Message> GetAllMessages()
        //{
            
        //}
    }
}
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

        public void AddNewMessage(ChatViewModel model)
        {
            db.Message.Add(model);
            db.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatsup.Models;
using WhatsUp.Models;

namespace Whatsup.Repositories
{
    public interface IChatRepository
    {
        void AddMessage(Message message);
        void AddChat(int CreatorId, Chat chat);
    }
}
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
        void AddMessage(int SenderId, Message message);
        void AddChat(int CreatorId, Chat chat);
        IEnumerable<ChatListViewModel> GetAllChats(int CreatorId);
    }
}
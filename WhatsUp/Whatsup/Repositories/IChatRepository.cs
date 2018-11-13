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
        Chat GetChat(string Name);
        void AddMessage(int SenderId, ChatViewModel message);
        //void AddChat(int CreatorId, Chat chat);
        ChatListViewModel AddChat(int creatorId, int contactIndex, string name);
        IEnumerable<ChatListViewModel> GetAllChats(int CreatorId);
        void GroupchatName(int CreatorId, AddGroupViewModel model);
    }
}
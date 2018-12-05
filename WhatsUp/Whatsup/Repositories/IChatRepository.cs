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
        Chat GetChatByContactIndex(int contactOwnerId, int contactIndex);
        int GetChatIndexByContactOwnerId(int contactOwnerId, int contactIndex);
        bool CheckChatExist(int contactOwnerId, int contactIndex);
        bool CheckIfChatExists(int contactOwnerId, int contactIndex);
        ChatListViewModel AddChat(int creatorId, int contactIndex, string name);
        void ChangeNameGroupChat(AddGroupViewModel model, int index);
        ChatListViewModel AddGroupChat(int creatorId, List<int> addedContacts, string name);
        IEnumerable<ChatListViewModel> GetAllChats(int CreatorId);
        IDictionary<int, string> GetChatParticipantContactNames(int userId, int chatId);
        IEnumerable<ChatListViewModel> GetChatListViewModelsByParticipant(int id);
        void GetChatParticipantContactName(int contactOwnerId);
        void DeleteChat(string Name, int Id);
        void DeleteAllChatsForParticipant(int contactOwnerId);
    }
}
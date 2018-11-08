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

        public Chat GetChat(string Name)
        {
            if (db.Chat.SingleOrDefault(a => a.Name == Name) != null)
            {
                return db.Chat.Single(a => a.Name == Name);
            }
            return null;
        }


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

        public IEnumerable<ChatListViewModel> GetAllChats(int CreatorId)
        {
            List<ChatListViewModel> chatListViewModels = new List<ChatListViewModel>();
            List<Chat> chatList = db.Users.SingleOrDefault(a => a.Id == CreatorId).Chats.ToList();

            for (int i = 0; i < chatList.Count; i++)
                chatListViewModels.Add(new ChatListViewModel(chatList[i], i));

            return chatListViewModels;
        }
    }
}
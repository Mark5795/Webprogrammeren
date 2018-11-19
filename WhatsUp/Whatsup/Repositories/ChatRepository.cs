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

        public ChatListViewModel AddChat(int creatorId, int contactIndex, string name)
        {
            Chat chat = new Chat();

            chat.CreatorId = creatorId;
            chat.Members = new List<User>();

            chat.Members.Add(GetContactUserByIndex(creatorId, contactIndex));

            chat.Members.Add(db.Users.SingleOrDefault(a => a.Id == creatorId));
            chat.CreatedOn = DateTime.Now;
            chat.Name = name;

            db.Users.SingleOrDefault(a => a.Id == creatorId).Chats.Add(chat);
            db.SaveChanges();

            return new ChatListViewModel(chat, db.Users.SingleOrDefault(a => a.Id == creatorId).Chats.Count - 1);
        }

        private User GetContactUserByIndex(int ownerId, int index)
        {
            int contactId = db.Users.SingleOrDefault(a => a.Id == ownerId).Contacts.ToList()[index].ContactAccountId;
            User user = db.Users.SingleOrDefault(a => a.Id == contactId);

            return user;
        }

        public void AddMessage(int memberId, ChatViewModel model)
        {
            Chat chat = GetChatByContactIndex(memberId, model.Index);
            List<Chat> chatList = GetChatsByMember(memberId);
            Message message = new Message(memberId, chat.Id, model);

            chat.Messages.Add(message);
            db.SaveChanges();
        }

        public Chat GetChatByContactIndex(int contactOwnerId, int contactIndex)
        {
            List<Chat> chatList = db.Users.SingleOrDefault(a => a.Id == contactOwnerId).Chats.ToList();
            if (chatList != null)
            {
                return chatList[contactIndex];
            }
            return null;
        }

        public bool CheckChatExist(int contactOwnerId, int contactIndex)
        {
            List<Chat> chatList = db.Users.SingleOrDefault(a => a.Id == contactOwnerId).Chats.ToList();
            if (chatList != null)
            {
                return true;
            }
            return false;
        }

        private List<Chat> GetChatsByMember(int id)
        {
            return db.Users.SingleOrDefault(a => a.Id == id).Chats.ToList();
        }

        public IEnumerable<ChatListViewModel> GetAllChats(int Id)
        {
            List<ChatListViewModel> chatListViewModels = new List<ChatListViewModel>();
            List<Chat> chatList = db.Users.SingleOrDefault(a => a.Id == Id).Chats.ToList();

            for (int i = 0; i < chatList.Count; i++)
                chatListViewModels.Add(new ChatListViewModel(chatList[i], i));

            return chatListViewModels;
        }

        public void GroupchatName(int CreatorId, AddGroupViewModel model)
        {
            //db.Users.Single(a => a.Id == CreatorId).Chats.Add(model);
            db.SaveChanges();
        }

        public IDictionary<int, string> GetChatMemberContactNames(int userId, int chatId)
        {
            Dictionary<int, string> memberNames = new Dictionary<int, string>();
            List<User> chatMembers = db.Chat.SingleOrDefault(c => c.Id == chatId).Members.ToList();
            List<Contact> contacts = db.Contact.Where(c => c.OwnerAccountId == userId).ToList();

            foreach (User member in chatMembers)
            {
                if (userId == member.Id)
                {
                    memberNames.Add(member.Id, "you");
                }
                else if (contacts.Any(c => c.ContactAccountId == member.Id))
                    memberNames.Add(member.Id, contacts.SingleOrDefault(c => c.ContactAccountId == member.Id).NickName);
                else
                    memberNames.Add(member.Id, member.Email);
            }

            return memberNames;
        }
    }
}
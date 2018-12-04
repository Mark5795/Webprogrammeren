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
            chat.Participants = new List<User>();

            chat.Participants.Add(GetContactUserByIndex(creatorId, contactIndex));

            chat.Participants.Add(db.Users.SingleOrDefault(a => a.Id == creatorId));
            chat.CreatedOn = DateTime.Now;
            chat.Name = name;

            db.Users.SingleOrDefault(a => a.Id == creatorId).Chats.Add(chat);
            db.SaveChanges();

            return new ChatListViewModel(chat, db.Users.SingleOrDefault(a => a.Id == creatorId).Chats.Count - 1);
        }

        public ChatListViewModel AddGroupChat(int creatorId, List<int> addedContacts, string name)
        {
            Chat chat = new Chat();
            chat.CreatorId = creatorId;
            chat.Participants = new List<User>();

            foreach (int contactIndex in addedContacts)
            {
                chat.Participants.Add(GetContactUserByIndex(creatorId, contactIndex));
            }
            
            chat.Participants.Add(db.Users.SingleOrDefault(a => a.Id == creatorId));
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

        public int GetChatIndexByContactOwnerId(int contactOwnerId, int contactIndex)
        {
            bool member1 = false, member2 = false;
            List<Chat> chatList = GetChatsByMember(contactOwnerId);
            User contact = GetContactUserByIndex(contactOwnerId, contactIndex);

            for (int i = 0; i < chatList.Count; i++)
            {
                if (chatList[i].Participants.Count == 2)
                {
                    foreach (User user in chatList[i].Participants)
                    {
                        if (user.Id == contactOwnerId)
                            member1 = true;
                        else if (user.Id == contact.Id)
                            member2 = true;
                    }

                    if (member1 && member2)
                    {
                        return i;
                    }
                    else
                    {
                        member1 = false;
                        member2 = false;
                    }
                }
            }

            throw new InvalidOperationException("No chat index could be found");
        }

        public bool CheckIfChatExists(int contactOwnerId, int contactIndex)
        {
            bool member1 = false, member2 = false;
            List<Chat> chatList = GetChatsByMember(contactOwnerId);
            User contact = GetContactUserByIndex(contactOwnerId, contactIndex);

            for (int i = 0; i < chatList.Count; i++)
            {
                if (chatList[i].Participants.Count == 2)
                {
                    foreach (User user in chatList[i].Participants)
                    {
                        if (user.Id == contactOwnerId)
                            member1 = true;
                        else if (user.Id == contact.Id)
                            member2 = true;
                    }

                    if (member1 && member2)
                    {
                        return true;
                    }
                    else
                    {
                        member1 = false;
                        member2 = false;
                    }
                }
            }

            return false;
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
            List<User> chatMembers = db.Chat.SingleOrDefault(c => c.Id == chatId).Participants.ToList();
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

        public void GetChatMemberContactName(int contactOwnerId)
        {
            try
            {
                foreach (Chat chat in GetChatsByMember(contactOwnerId))
                {
                    if (chat.Participants.Count() == 2)
                    {
                        if (chat.Participants.ToList()[0].Id == contactOwnerId)
                        {
                            chat.Name = db.Users.SingleOrDefault(a => a.Id == contactOwnerId).Contacts.SingleOrDefault(c => c.ContactAccountId == chat.Participants.ToList()[1].Id).NickName;
                        }
                        else if (chat.Participants.ToList()[1].Id == contactOwnerId)
                        {
                            chat.Name = db.Users.SingleOrDefault(a => a.Id == contactOwnerId).Contacts.SingleOrDefault(c => c.ContactAccountId == chat.Participants.ToList()[0].Id).NickName;
                        }
                    }
                }
                db.SaveChanges();
            }
            catch { }
        }

        public IEnumerable<ChatListViewModel> GetChatListViewModelsByMember(int id)
        {
            List<ChatListViewModel> chats = new List<ChatListViewModel>();
            List<Chat> chatList = db.Users.SingleOrDefault(a => a.Id == id).Chats.ToList();

            for (int index = 0; index < chatList.Count; index++)
            {
                chats.Add(new ChatListViewModel(chatList[index], index));
            }

            return chats;
        }

        public void DeleteChat(string Name, int Id)
        {
            Chat chat = db.Chat.Single(c => (c.Name == Name) &&  (c.Id == Id));
            db.Chat.Remove(chat);
            db.SaveChanges();
        }
    }
}
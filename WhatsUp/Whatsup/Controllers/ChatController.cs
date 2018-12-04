using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whatsup.Models;
using Whatsup.Repositories;
using WhatsUp.Models;

namespace Whatsup.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private IUserRepository userRepository = new UserRepository();
        private IChatRepository chatRepository = new ChatRepository();
        private IContactRepository contactRepository = new ContactRepository();

        [HttpGet]
        public ActionResult Chat(int index)
        {
            if (chatRepository.CheckChatExist(GetUser().Id, index))
            {
                Chat chat = chatRepository.GetChatByContactIndex(GetUser().Id, index);
                List<Message> messages = new List<Message>();
                messages = chat.Messages.ToList();

                ChatViewModel model = new ChatViewModel(GetUser().Id, index, chatRepository.GetChatMemberContactNames(GetUser().Id,
                    chatRepository.GetChatByContactIndex(GetUser().Id, index).Id), messages, chat.Group ? chat.Name : chat.Name);
                return View(model);
            }
            else
            {
                ViewBag.ErrorMessage = "That chat doesn't exist";
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        public ActionResult Chat(ChatViewModel model, int Index)
        {
            if (ModelState.IsValid)
            {
                chatRepository.AddMessage(GetUser().Id, model);
                return RedirectToAction("Chat", new { index = model.Index});
            }
            return View();
        }


        [HttpGet]
        public ActionResult AddGroupChat()
        {
            AddGroupViewModel model = new AddGroupViewModel();
            model.Contacts = contactRepository.GetChooseContactViewModels(GetUser().Id);

            return View(model);
        }

        [HttpPost]
        public ActionResult AddGroupChat(AddGroupViewModel model)
        {
            List<int> addedContacts = new List<int>();
            foreach (ChooseContactViewModel item in model.Contacts)
            {
                if (item.Chosen)
                {
                    addedContacts.Add(item.Index);
                }
            }
            return CreateGroupChat(addedContacts, model.Name);
        }

        [HttpGet]
        public ActionResult ChatContact()
        {
            IEnumerable<ContactViewModel> contactList = contactRepository.GetAllContacts(GetUser().Id);
            return View(contactList);
        }

        [HttpGet]
        public ActionResult AddChat(int contactIndex)
        {
            if (!chatRepository.CheckIfChatExists(GetUser().Id, contactIndex))
            {
                Contact contact = contactRepository.GetContact(GetUser().Id, contactIndex);
                return AddNewChat(contactIndex, contact.NickName);
            }
            else
            {
                return RedirectToAction("Chat", new { index = chatRepository.GetChatIndexByContactOwnerId(GetUser().Id, contactIndex) });
            }
        }

        [HttpGet]
        public ActionResult CreateGroupChat(List<int> addedContacts, string name)
        {
            ChatListViewModel model = chatRepository.AddGroupChat(GetUser().Id, addedContacts, name);
            return RedirectToAction("Chat", new { index = model.Index });
        }

        [HttpGet]
        public ActionResult DeleteChat(int Index)
        {
            Chat chat = chatRepository.GetChatByContactIndex(GetUser().Id, Index);
            return View(chat);
        }

        [HttpPost]
        public ActionResult DeleteChat(string Name, int Id)
        {
            chatRepository.DeleteChat(Name, Id);
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult AddNewChat(int contactIndex, string name)
        {
            ChatListViewModel model = chatRepository.AddChat(GetUser().Id, contactIndex, name);
            return RedirectToAction("Chat", new { index = model.Index});
        }

        private User GetUser()
        {
            return userRepository.GetUser(User.Identity.Name);
        }
    }
}
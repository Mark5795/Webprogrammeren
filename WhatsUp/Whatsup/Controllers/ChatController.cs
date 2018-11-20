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

                ChatViewModel model = new ChatViewModel(GetUser().Id,
                    index,
                    chatRepository.GetChatMemberContactNames(GetUser().Id, chatRepository.GetChatByContactIndex(GetUser().Id, index).Id),
                    messages,
                    chat.Group ? "Group chat:" + chat.Name : "Chat: " + chat.Name
                    );

                return View(model);
            }
            else
            {
                ViewBag.ErrorMessage = "That chat doesn't exist";
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        public ActionResult Chat(ChatViewModel model, int Index, List<int> contactIndices, string name)
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
            return View();
        }

        [HttpPost]
        public ActionResult AddGroupChat(AddGroupViewModel model)
        {
            if (model.GroupName != null)
            {
                if (ModelState.IsValid)
                {
                    //return AddChat(model.GroupName;
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult ChatContact()
        {
            IEnumerable<ContactViewModel> contactList = contactRepository.GetAllContacts(GetUser().Id);
            return View(contactList);
        }

        [HttpGet]
        public ActionResult CreateChat(int contactIndex)
        {
            if (chatRepository.CheckChatExist(GetUser().Id, contactIndex))
            {
                Contact contact = contactRepository.GetContact(GetUser().Id, contactIndex);
                //List<int> recipients = new List<int>();
                //recipients.Add(contactIndex);

                return AddChat(contactIndex, contact.NickName);
            }
            else
                return RedirectToAction("Chat", new { index = chatRepository.GetChatByContactIndex(GetUser().Id, contactIndex) });
        }

        [HttpGet]
        public ActionResult AddChat(int contactIndex, string name)
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
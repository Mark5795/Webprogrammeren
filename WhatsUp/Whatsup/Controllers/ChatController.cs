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
        public ActionResult Chat(int Index)
        {
            Contact contact = contactRepository.GetContact(GetUser().Id, Index);
            ContactViewModel contactViewModel = new ContactViewModel(contact, Index);                                 
            ViewBag.Email = contactViewModel.Email;
            ViewBag.Nickname = contactViewModel.NickName;
            return View();
        }

        [HttpPost]
        public ActionResult Chat(ChatViewModel model, int Index)
        {
            if (model.Content != null)
            {
                //Check if there is a chat already
                if (chatRepository.GetChat(contactRepository.GetContact(GetUser().Id, Index).NickName) == null)
                {
                    Chat chat = new Chat();
                    chat.Group = false;
                    chat.CreatorId = GetUser().Id;
                    chat.CreatedOn = DateTime.Now;

                    chat.Name = contactRepository.GetContact(GetUser().Id, Index).NickName;
                    chatRepository.AddChat(GetUser().Id, chat);
                }
                else if(ModelState.IsValid)
                {
                    chatRepository.AddMessage(GetUser().Id, model);
                        //    Message message = new Message(model.Content);
                        //chatRepository.AddMessage(GetUser().Id, message);
                        //return View();
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult NewGroupChat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewGroupChat(AddGroupViewModel model)
        {
            if (model.Name != null)
            {
                //Check if there is a chat already
                if (ModelState.IsValid)
                {
                    chatRepository.GroupchatName(GetUser().Id, model);
                }
            }
            return View();
        }

        public ActionResult ChatContact()
        {
            IEnumerable<ContactViewModel> contactList = contactRepository.GetAllContacts(GetUser().Id);
            return View(contactList);
        }

        private User GetUser()
        {
            return userRepository.GetUser(User.Identity.Name);
        }
    }
}
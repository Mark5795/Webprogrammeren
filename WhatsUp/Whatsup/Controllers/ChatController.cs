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
        public ActionResult Chat(ChatViewModel model)
        {
            if (model.Content != null)
            {
                Chat chat = new Chat();
                chat.Group = false;
                chat.CreatorId = GetUser().Id;
                chat.CreatedOn = DateTime.Now;
                chatRepository.AddChat(GetUser().Id, chat);
                

                Message message = new Message(model.Content);

                chatRepository.AddMessage(message);
                return View();
            }
            return View();
        }

        public ActionResult ChatContact()
        {
            IEnumerable<ContactViewModel> contactList = contactRepository.GetAllContacts(GetUser().Id);
            return View(contactList);
        }

        //[HttpPost]
        //public ActionResult ChatContact(ChatViewModel model)
        //{
        //    Chat chat = new Chat();
        //    chat.Group = false;
        //    chat.CreatorId = GetUser().Id;
        //    chat.CreatedOn = DateTime.Now;
        //    chatRepository.AddChat(GetUser().Id, chat);
        //    return View();
        //}

        private User GetUser()
        {
            return userRepository.GetUser(User.Identity.Name);
        }
    }
}
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
        public ActionResult Chat(ChatViewModel model, int Index, List<int> contactIndices, string name)
        {
            if (model.Content != null)
            {
                //Check if there is a chat already
                if (chatRepository.GetChat(contactRepository.GetContact(GetUser().Id, Index).NickName) == null)
                {
                    //string Name = contactRepository.GetContact(GetUser().Id, Index).NickName;
                    //chatRepository.AddChat(GetUser().Id, Index, Name);
                    ChatListViewModel model = chatRepository.AddChat(GetUser().Id, contactIndices, name);
                }
                else if (ModelState.IsValid)
                {
                    chatRepository.AddMessage(GetUser().Id, model);
                    //return View();
                    return RedirectToAction("Index", "Home");
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
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
    [RequireHttps]
    public class HomeController : Controller
    {
        private IUserRepository userRepository = new UserRepository();
        private IChatRepository chatRepository = new ChatRepository();

        // Get list of chats
        public ActionResult Index()
        {
            if (GetUser() != null)
            {
                //to get the right chatnames
                chatRepository.GetChatParticipantContactName(GetUser().Id);
                IEnumerable<ChatListViewModel> chatList = chatRepository.GetChatListViewModelsByParticipant(GetUser().Id);
                return View(chatList);
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        private User GetUser()
        {
            return userRepository.GetUser(User.Identity.Name);
        }
    }
}
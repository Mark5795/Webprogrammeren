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
        private IContactRepository contactRepository = new ContactRepository();
        private IUserRepository userRepository = new UserRepository();
        private IChatRepository chatRepository = new ChatRepository();

        public ActionResult Index()
        {
            if (GetUser() != null)
            {
                IEnumerable<ChatListViewModel> chatList = chatRepository.GetAllChats(GetUser().Id);
                return View(chatList);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        private User GetUser()
        {
            return userRepository.GetUser(User.Identity.Name);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whatsup.Models;
using Whatsup.Repositories;

namespace Whatsup.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private IContactRepository contactRepository = new ContactRepository();
        private IUserRepository userRepository = new UserRepository();

        public ActionResult Index()
        {
            if (GetUser() != null)
            {
                IEnumerable<ContactViewModel> contactList = contactRepository.GetAllContacts(GetUser().Id);
                return View(contactList);
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
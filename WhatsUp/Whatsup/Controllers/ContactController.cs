using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Whatsup.Models;
using Whatsup.Repositories;
using System.Web.Security;
using System.Data.Entity.Validation;
using WhatsUp.Models;

namespace Whatsup.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {

        private IUserRepository userRepository = new UserRepository();
        private IContactRepository contactRepository = new ContactRepository();

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (userRepository.GetUser(model.Email) != null)
                {
                    Contact contact = new Contact();
                    contact.Name = model.Name;
                    //contactRepository.AddContact(userRepository.GetLoggedInUser(), contact);
                    contact.OwnerAccountId = userRepository.GetLoggedInUser();
                    contact.ContactAccountId = userRepository.GetUser(model.Email).Id;
                    contactRepository.AddContact(GetUser().Id, contact);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Email", "There was no user found with this Email!");
                    return View(model);
                }
            }
            return View(model);
        }

        private User GetUser()
        {
            return userRepository.GetUser(User.Identity.Name);
        }
    }
}
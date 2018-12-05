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

        [HttpGet]
        public ActionResult Contact()
        {
            IEnumerable<ContactViewModel> contactList = contactRepository.GetAllContacts(GetUser().Id);
            return View(contactList);
        }

        [HttpGet]
        public ActionResult ContactProfile(int Index)
        {
            Contact contact = contactRepository.GetContact(GetUser().Id, Index);
            ContactViewModel contactViewModel = new ContactViewModel(contact, Index);
            return View(contactViewModel);
        }

        [HttpGet]
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
                    contact.NickName = model.NickName;
                    contact.OwnerAccountId = userRepository.GetLoggedInUser();
                    contact.ContactAccountId = userRepository.GetUser(model.Email).Id;

                    contactRepository.AddContact(GetUser().Id, contact);
                    return RedirectToAction("Contact", "Contact");
                }
                else
                {
                    ModelState.AddModelError("Email", "There was no user found with this Email!");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult EditContact(int Index)
        {
            Contact contact = contactRepository.GetContact(GetUser().Id, Index);
            ContactViewModel contactViewModel = new ContactViewModel(contact, Index);
            return View(contactViewModel);
        }

        [HttpPost]
        public ActionResult EditContact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (userRepository.GetUser(model.Email) != null)
                {
                    contactRepository.EditContact(GetUser().Id, model);
                    return RedirectToAction("Contact", "Contact");
                }
                else
                {
                    ModelState.AddModelError("Email", "There was no user found with this Email!");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteContact(int Index)
        {
            Contact contact = contactRepository.GetContact(GetUser().Id, Index);
            ContactViewModel contactViewModel = new ContactViewModel(contact, Index);
            ViewBag.Email = contactViewModel.Email;
            return View(contactViewModel);
        }

        [HttpPost]
        public ActionResult DeleteContact(ContactViewModel model, int Index)
        {
            contactRepository.DeleteContact(GetUser().Id, Index);
            ModelState.AddModelError("Email", "Contact is deleted");
            return RedirectToAction("Contact", "Contact");
        }

        private User GetUser()
        {
            return userRepository.GetUser(User.Identity.Name);
        }
    }
}
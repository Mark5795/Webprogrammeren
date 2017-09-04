using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Whatsup.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Index()
        {
            return View();
        }

        // Nieuw Contact
        public ActionResult Nieuw()
        {

            return View();
        }

        //  Contact
        public ActionResult Weizig(int? id)
        {

            return View();
        }

        // Delete Contact
        public ActionResult Delete(int? id)
        {

            return View();
        }
    }
}
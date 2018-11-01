using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whatsup.Repositories;

namespace Whatsup.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private IContactRepository contactRepository = new ContactRepository();

        public ActionResult Index()
        {
            //ViewBag.AllContacts = contactRepository.GetAllContacts();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}
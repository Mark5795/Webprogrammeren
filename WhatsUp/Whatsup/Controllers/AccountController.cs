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

namespace Whatsup.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Account account = repository.GetAccount(
                             model.EmailAddress, model.Password);
                if (account != null)
                {
                    FormsAuthentication.SetAuthCookie(account.EmailAddress, false);

                    Session["loggedin_account"] = account;

                    return RedirectToAction("Index", "Contact");
                }
                else
                {
                    ModelState.AddModelError("login-error",
                        "The user name or password provided is incorrect.");
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthenication.SignOut();

            return RedirectToAction("Login", "Account");
        }
    }
}
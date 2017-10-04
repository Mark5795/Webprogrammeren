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
using System.Data.Sql;

namespace Whatsup.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository accountRepository = new AccountRepository();

        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                Account account = accountRepository.GetAccount(
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
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        //Registratie maken hier

        [HttpPost]
        public ActionResult Register(Register model)
        {

            return View(model);
        }
    }
}
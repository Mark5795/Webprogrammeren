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

namespace Whatsup.Views
{
    public class UserController : Controller
    {
        private IUserRepository userRepository = new UserRepository();
        private IChatRepository chatRepository = new ChatRepository();

        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // Login: User
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (userRepository.ValidCredentials(model))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);

                    //Remember complete account
                    Session["loggedin_user"] = model;

                    //Create a new hashed password and salt and store in db, to push the security level one step higher.
                    userRepository.AddNewPassword(model);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Password is incorrect");
                    return View(model);
                }
            }
            else
                return View(model);
        }

        // Register: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // POST: User/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Email,UserName,Password")] AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (userRepository.AlreadyRegistered(model.Email))
                {
                    ModelState.AddModelError("Email", "This e-mail is already used.");
                    return View(model);
                }
            }

            try
            {
                User user = new User(model.Username, model.Email, model.PasswordHash, model.Salt, model.DateCreated);
                userRepository.AddUser(user);
                return RedirectToAction("Login", "User");
            }
            catch (Exception e)
            {
                //ModelState.AddModelError("Password", e.ToString());
                return View(model);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult RegisterSuccesful()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult ProfileUser()
        {
            ProfileUserViewModel profileUserViewModel = userRepository.GetProfileUserViewModel();
            ViewBag.Email = profileUserViewModel.Email;

            return View(profileUserViewModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult LogOut()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult LogOutUser()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        // GET: User/Edit
        [Authorize]
        [HttpGet]
        public ActionResult EditUser()
        {
            ProfileUserViewModel profileUserViewModel = userRepository.GetProfileUserViewModel();

            ViewBag.Username = profileUserViewModel.Username;
            ViewBag.Email = profileUserViewModel.Email;
            ViewBag.DateCreated = profileUserViewModel.DateCreated;

            return View(profileUserViewModel);
        }

        // POST: User/Edit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser([Bind(Include = "Email,UserName")] ProfileUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                userRepository.EditUser(model);
                return RedirectToAction("ProfileUser", "User");
            }
            return RedirectToAction("ProfileUser", "User");
        }

        // GET: User/Delete
        [Authorize]
        [HttpGet]
        public ActionResult DeleteUser()
        {
            chatRepository.DeleteAllChatsForMember(GetUser().Id);
            User user = userRepository.GetUserById(GetUser().Id);
            LoginUserViewModel loginUserViewModel = new LoginUserViewModel(user);
            return View(loginUserViewModel);
        }

        [HttpPost]
        public ActionResult DeleteUser(LoginUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (userRepository.ValidCredentials(model))
                {
                    userRepository.DeleteUser(GetUser().Id);

                    LogOutUser();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Password is incorrect");
                    return View(model);
                }
            }
            else
                return View(model);
        }

        private User GetUser()
        {
            return userRepository.GetUser(User.Identity.Name);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whatsup.Models;
using Whatsup.Repositories;

namespace Whatsup.Controllers
{
    public class ChatController : Controller
    {
        private IChatRepository chatRepository = new ChatRepository();

        // GET: Chat
        public ActionResult Chat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Chat(ChatViewModel model)
        {
            if (model.Content != null)
            {
                chatRepository.AddNewMessage(model);
            }
            return View();
        }
    }
}
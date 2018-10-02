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
                Message message = new Message(model.Content);
                chatRepository.AddNewMessage(message);
            }
            return View();
        }
    }
}
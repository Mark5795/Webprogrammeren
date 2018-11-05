using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WhatsUp.Models;

namespace Whatsup.Models
{
    public class ContactChatViewModel
    {
        public IEnumerable<ContactViewModel> ContactViewModel { get; set; }

        public ChatViewModel ChatViewModel { get; set; }

    }
}
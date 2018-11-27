using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUp.Models;

namespace Whatsup.Models
{
    public class AddedContactViewModel : ContactViewModel
    {
        public bool Added { get; set; }

        public AddedContactViewModel() { }
        public AddedContactViewModel(Contact contact, int index) : base(contact, index) { }
    }
}
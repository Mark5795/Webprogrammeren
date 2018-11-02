using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUp.Models;

namespace Whatsup.Models
{
    public class SelectContactViewModel : ContactViewModel
    {
        public bool Selected { get; set; }

        public SelectContactViewModel() { }
        public SelectContactViewModel(Contact contact, int index) : base(contact, index) { }
    }
}
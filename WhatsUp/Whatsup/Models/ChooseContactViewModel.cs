using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUp.Models;

namespace Whatsup.Models
{
    public class ChooseContactViewModel : ContactViewModel
    {
        public bool Chosen { get; set; }

        public ChooseContactViewModel() { }
        public ChooseContactViewModel(Contact contact, int index) : base(contact, index) { }
    }
}
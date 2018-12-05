using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Whatsup.Models
{
    public class AddGroupViewModel
    {
        public IList<ChooseContactViewModel> Contacts { get; set; }

        [Required]
        public string Name { get; set; }

        public AddGroupViewModel() { }

        public AddGroupViewModel(IList<ChooseContactViewModel> contact, string name)
        {
            Contacts = contact;
            Name = Name;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Whatsup.Models
{
    public class AddGroupViewModel
    {
        public string Name { get; set; }

        public AddGroupViewModel() { }

        public AddGroupViewModel(string name)
        {
            Name = Name;
        }
    }
}
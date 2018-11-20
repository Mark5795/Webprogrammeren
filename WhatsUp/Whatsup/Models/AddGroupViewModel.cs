using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Whatsup.Models
{
    public class AddGroupViewModel
    {
        public string GroupName { get; set; }

        public AddGroupViewModel() { }

        public AddGroupViewModel(string GroupName)
        {
            this.GroupName = GroupName;
        }
    }
}
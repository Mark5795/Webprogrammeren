using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whatsup.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
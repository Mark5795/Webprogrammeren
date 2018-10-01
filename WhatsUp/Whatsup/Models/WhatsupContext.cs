using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Whatsup.Models
{
    public class WhatsupContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WhatsupContext() : base("name=WhatsupContext")
        {
        }

        public System.Data.Entity.DbSet<Whatsup.Models.User> Users { get; set; }
        public System.Data.Entity.DbSet<WhatsUp.Models.Message> Message { get; set; }
        public System.Data.Entity.DbSet<WhatsUp.Models.Contact> Contact { get; set; }
        public System.Data.Entity.DbSet<Whatsup.Models.Chat> Chat { get; set; }
    }
}

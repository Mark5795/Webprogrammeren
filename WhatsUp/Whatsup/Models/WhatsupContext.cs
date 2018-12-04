using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WhatsUp.Models;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<Contact>(a => a.Contacts)
                .WithRequired(c => c.OwnerAccount);

            modelBuilder.Entity<Chat>()
                .HasMany<User>(c => c.Participants)
                .WithMany(a => a.Chats)
                .Map(ca =>
                {
                    ca.MapLeftKey("ChatId");
                    ca.MapRightKey("MemberId");
                    ca.ToTable("ChatMember");
                });
        }
    }
}

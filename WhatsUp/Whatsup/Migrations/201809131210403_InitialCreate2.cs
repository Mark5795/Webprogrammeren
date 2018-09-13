namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "OwnerAccountId", "dbo.Accounts");
            DropForeignKey("dbo.Chats", "OwnerAccount_Id", "dbo.Accounts");
            DropForeignKey("dbo.Chats", "ReceiverId_Id", "dbo.Accounts");
            DropForeignKey("dbo.Chats", "SenderId_Id", "dbo.Accounts");
            DropIndex("dbo.Contacts", new[] { "OwnerAccountId" });
            DropIndex("dbo.Chats", new[] { "OwnerAccount_Id" });
            DropIndex("dbo.Chats", new[] { "ReceiverId_Id" });
            DropIndex("dbo.Chats", new[] { "SenderId_Id" });
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Int(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Int(nullable: false),
                        TwoFactorEnabled = c.Int(nullable: false),
                        LockoutEndDateUtc = c.DateTime(nullable: false),
                        LockoutEnabled = c.Int(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Accounts");
            DropTable("dbo.Contacts");
            DropTable("dbo.Chats");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        OwnerAccount_Id = c.Int(),
                        ReceiverId_Id = c.Int(),
                        SenderId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mobilenumber = c.String(),
                        OwnerAccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MobileNumber = c.String(),
                        EmailAddress = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Users");
            CreateIndex("dbo.Chats", "SenderId_Id");
            CreateIndex("dbo.Chats", "ReceiverId_Id");
            CreateIndex("dbo.Chats", "OwnerAccount_Id");
            CreateIndex("dbo.Contacts", "OwnerAccountId");
            AddForeignKey("dbo.Chats", "SenderId_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Chats", "ReceiverId_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Chats", "OwnerAccount_Id", "dbo.Accounts", "Id");
            AddForeignKey("dbo.Contacts", "OwnerAccountId", "dbo.Accounts", "Id", cascadeDelete: true);
        }
    }
}

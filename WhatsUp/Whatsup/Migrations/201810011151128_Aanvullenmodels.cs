namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aanvullenmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chat",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Group = c.Boolean(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.CreatorId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        Content = c.String(nullable: false),
                        ChatId = c.Int(nullable: false),
                        SenderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chat", t => t.ChatId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.SenderId, cascadeDelete: false)
                .Index(t => t.ChatId)
                .Index(t => t.SenderId);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OwnerAccountId = c.Int(nullable: false),
                        ContactAccountId = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ContactAccountId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.OwnerAccountId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.OwnerAccountId)
                .Index(t => t.ContactAccountId)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Users", "Chat_Id", c => c.Int());
            CreateIndex("dbo.Users", "Chat_Id");
            AddForeignKey("dbo.Users", "Chat_Id", "dbo.Chat", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contact", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Contact", "OwnerAccountId", "dbo.Users");
            DropForeignKey("dbo.Contact", "ContactAccountId", "dbo.Users");
            DropForeignKey("dbo.Chat", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Message", "SenderId", "dbo.Users");
            DropForeignKey("dbo.Message", "ChatId", "dbo.Chat");
            DropForeignKey("dbo.Users", "Chat_Id", "dbo.Chat");
            DropForeignKey("dbo.Chat", "CreatorId", "dbo.Users");
            DropIndex("dbo.Contact", new[] { "User_Id" });
            DropIndex("dbo.Contact", new[] { "ContactAccountId" });
            DropIndex("dbo.Contact", new[] { "OwnerAccountId" });
            DropIndex("dbo.Message", new[] { "SenderId" });
            DropIndex("dbo.Message", new[] { "ChatId" });
            DropIndex("dbo.Chat", new[] { "User_Id" });
            DropIndex("dbo.Chat", new[] { "CreatorId" });
            DropIndex("dbo.Users", new[] { "Chat_Id" });
            DropColumn("dbo.Users", "Chat_Id");
            DropTable("dbo.Contact");
            DropTable("dbo.Message");
            DropTable("dbo.Chat");
        }
    }
}

namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class opnieuw : DbMigration
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatorId, cascadeDelete: true)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        PasswordHash = c.String(nullable: false),
                        Salt = c.Binary(),
                        PhoneNumber = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NickName = c.String(),
                        OwnerAccountId = c.Int(nullable: false),
                        ContactAccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ContactAccountId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.OwnerAccountId, cascadeDelete: false)
                .Index(t => t.OwnerAccountId)
                .Index(t => t.ContactAccountId);
            
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
                "dbo.ChatMember",
                c => new
                    {
                        ChatId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChatId, t.MemberId })
                .ForeignKey("dbo.Chat", t => t.ChatId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.MemberId, cascadeDelete: false)
                .Index(t => t.ChatId)
                .Index(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Message", "SenderId", "dbo.Users");
            DropForeignKey("dbo.Message", "ChatId", "dbo.Chat");
            DropForeignKey("dbo.ChatMember", "MemberId", "dbo.Users");
            DropForeignKey("dbo.ChatMember", "ChatId", "dbo.Chat");
            DropForeignKey("dbo.Chat", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Contact", "OwnerAccountId", "dbo.Users");
            DropForeignKey("dbo.Contact", "ContactAccountId", "dbo.Users");
            DropIndex("dbo.ChatMember", new[] { "MemberId" });
            DropIndex("dbo.ChatMember", new[] { "ChatId" });
            DropIndex("dbo.Message", new[] { "SenderId" });
            DropIndex("dbo.Message", new[] { "ChatId" });
            DropIndex("dbo.Contact", new[] { "ContactAccountId" });
            DropIndex("dbo.Contact", new[] { "OwnerAccountId" });
            DropIndex("dbo.Chat", new[] { "CreatorId" });
            DropTable("dbo.ChatMember");
            DropTable("dbo.Message");
            DropTable("dbo.Contact");
            DropTable("dbo.Users");
            DropTable("dbo.Chat");
        }
    }
}

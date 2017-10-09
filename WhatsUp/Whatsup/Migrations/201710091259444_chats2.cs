namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chats2 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.OwnerAccount_Id)
                .ForeignKey("dbo.Accounts", t => t.ReceiverId_Id)
                .ForeignKey("dbo.Accounts", t => t.SenderId_Id)
                .Index(t => t.OwnerAccount_Id)
                .Index(t => t.ReceiverId_Id)
                .Index(t => t.SenderId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chats", "SenderId_Id", "dbo.Accounts");
            DropForeignKey("dbo.Chats", "ReceiverId_Id", "dbo.Accounts");
            DropForeignKey("dbo.Chats", "OwnerAccount_Id", "dbo.Accounts");
            DropIndex("dbo.Chats", new[] { "SenderId_Id" });
            DropIndex("dbo.Chats", new[] { "ReceiverId_Id" });
            DropIndex("dbo.Chats", new[] { "OwnerAccount_Id" });
            DropTable("dbo.Chats");
        }
    }
}

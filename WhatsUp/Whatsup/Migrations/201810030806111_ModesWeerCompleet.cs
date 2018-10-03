namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModesWeerCompleet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Message", "Chat_Id", "dbo.Chat");
            DropIndex("dbo.Message", new[] { "Chat_Id" });
            RenameColumn(table: "dbo.Message", name: "Chat_Id", newName: "ChatId");
            AddColumn("dbo.Message", "SenderId", c => c.Int(nullable: false));
            AlterColumn("dbo.Message", "ChatId", c => c.Int(nullable: false));
            CreateIndex("dbo.Message", "ChatId");
            CreateIndex("dbo.Message", "SenderId");
            AddForeignKey("dbo.Message", "SenderId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Message", "ChatId", "dbo.Chat", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Message", "ChatId", "dbo.Chat");
            DropForeignKey("dbo.Message", "SenderId", "dbo.Users");
            DropIndex("dbo.Message", new[] { "SenderId" });
            DropIndex("dbo.Message", new[] { "ChatId" });
            AlterColumn("dbo.Message", "ChatId", c => c.Int());
            DropColumn("dbo.Message", "SenderId");
            RenameColumn(table: "dbo.Message", name: "ChatId", newName: "Chat_Id");
            CreateIndex("dbo.Message", "Chat_Id");
            AddForeignKey("dbo.Message", "Chat_Id", "dbo.Chat", "Id");
        }
    }
}

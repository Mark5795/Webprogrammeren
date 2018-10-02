namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Message", "ChatId", "dbo.Chat");
            DropIndex("dbo.Message", new[] { "ChatId" });
            RenameColumn(table: "dbo.Message", name: "ChatId", newName: "Chat_Id");
            AlterColumn("dbo.Message", "Chat_Id", c => c.Int());
            CreateIndex("dbo.Message", "Chat_Id");
            AddForeignKey("dbo.Message", "Chat_Id", "dbo.Chat", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Message", "Chat_Id", "dbo.Chat");
            DropIndex("dbo.Message", new[] { "Chat_Id" });
            AlterColumn("dbo.Message", "Chat_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Message", name: "Chat_Id", newName: "ChatId");
            CreateIndex("dbo.Message", "ChatId");
            AddForeignKey("dbo.Message", "ChatId", "dbo.Chat", "Id", cascadeDelete: true);
        }
    }
}

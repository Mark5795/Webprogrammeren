namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Message", "SenderId", "dbo.Users");
            DropIndex("dbo.Message", new[] { "SenderId" });
            DropColumn("dbo.Message", "SenderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "SenderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Message", "SenderId");
            AddForeignKey("dbo.Message", "SenderId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}

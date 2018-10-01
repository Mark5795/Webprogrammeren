namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namechange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Message", "TimeSend", c => c.DateTime(nullable: false));
            DropColumn("dbo.Message", "CreatedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "CreatedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.Message", "TimeSend");
        }
    }
}

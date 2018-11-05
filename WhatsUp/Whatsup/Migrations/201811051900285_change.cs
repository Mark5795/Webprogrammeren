namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Message", "CreatedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.Message", "TimeSend");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "TimeSend", c => c.DateTime(nullable: false));
            DropColumn("dbo.Message", "CreatedOn");
        }
    }
}

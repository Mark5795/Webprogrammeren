namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datetimeaangepastomerrorteverhelpen : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}

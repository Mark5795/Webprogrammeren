namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeaccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "MobileNumber", c => c.String());
            DropColumn("dbo.Accounts", "MobilNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "MobilNumber", c => c.String());
            DropColumn("dbo.Accounts", "MobileNumber");
        }
    }
}

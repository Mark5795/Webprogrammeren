namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class securitystamptijdelijkweg : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "SecurityStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "SecurityStamp", c => c.String());
        }
    }
}

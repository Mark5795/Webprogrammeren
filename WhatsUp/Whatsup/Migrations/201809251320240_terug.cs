namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class terug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "SecurityStamp", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "SecurityStamp");
        }
    }
}

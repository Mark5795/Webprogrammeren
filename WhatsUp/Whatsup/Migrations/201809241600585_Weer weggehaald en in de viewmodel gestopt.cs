namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Weerweggehaaldenindeviewmodelgestopt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DateCreated");
        }
    }
}

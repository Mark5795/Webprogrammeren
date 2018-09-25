namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "EmailConfirmed", c => c.Int());
            DropColumn("dbo.Users", "SecurityStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "SecurityStamp", c => c.String());
            AlterColumn("dbo.Users", "EmailConfirmed", c => c.Int(nullable: false));
        }
    }
}

namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VoegToeUitModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "EmailConfirmed", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "SecurityStamp", c => c.String());
            AddColumn("dbo.Users", "PhoneNumberConfirmed", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "TwoFactorEnabled", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "LockoutEnabled", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LockoutEnabled");
            DropColumn("dbo.Users", "TwoFactorEnabled");
            DropColumn("dbo.Users", "PhoneNumberConfirmed");
            DropColumn("dbo.Users", "SecurityStamp");
            DropColumn("dbo.Users", "EmailConfirmed");
        }
    }
}

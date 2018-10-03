namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTableAangepstVoorWatNuNodigIs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "EmailConfirmed");
            DropColumn("dbo.Users", "SecurityStamp");
            DropColumn("dbo.Users", "PhoneNumberConfirmed");
            DropColumn("dbo.Users", "TwoFactorEnabled");
            DropColumn("dbo.Users", "LockoutEndDateUtc");
            DropColumn("dbo.Users", "LockoutEnabled");
            DropColumn("dbo.Users", "AccessFailedCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "LockoutEnabled", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "LockoutEndDateUtc", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "TwoFactorEnabled", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "PhoneNumberConfirmed", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "SecurityStamp", c => c.String());
            AddColumn("dbo.Users", "EmailConfirmed", c => c.Int(nullable: false));
        }
    }
}

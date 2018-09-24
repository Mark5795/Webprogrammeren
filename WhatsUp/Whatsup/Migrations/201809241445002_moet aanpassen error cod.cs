namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moetaanpassenerrorcod : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "PasswordHash", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Users", "PasswordHash", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
        }
    }
}

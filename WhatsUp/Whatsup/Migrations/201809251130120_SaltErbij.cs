namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaltErbij : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Salt", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Salt");
        }
    }
}

namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "test", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contact", "test");
        }
    }
}

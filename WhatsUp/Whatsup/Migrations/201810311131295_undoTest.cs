namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class undoTest : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contact", "test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "test", c => c.Int(nullable: false));
        }
    }
}

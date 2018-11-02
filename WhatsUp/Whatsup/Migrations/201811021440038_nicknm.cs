namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nicknm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "NickName", c => c.String());
            DropColumn("dbo.Contact", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "Name", c => c.String());
            DropColumn("dbo.Contact", "NickName");
        }
    }
}

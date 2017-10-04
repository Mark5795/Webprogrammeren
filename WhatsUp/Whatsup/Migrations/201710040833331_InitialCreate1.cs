namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MobilNumber = c.String(),
                        EmailAddress = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contacts", "OwnerAccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "OwnerAccountId");
            AddForeignKey("dbo.Contacts", "OwnerAccountId", "dbo.Accounts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "OwnerAccountId", "dbo.Accounts");
            DropIndex("dbo.Contacts", new[] { "OwnerAccountId" });
            DropColumn("dbo.Contacts", "OwnerAccountId");
            DropTable("dbo.Accounts");
        }
    }
}

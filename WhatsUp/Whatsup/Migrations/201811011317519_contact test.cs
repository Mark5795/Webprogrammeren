namespace Whatsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contacttest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contact", "OwnerAccountId", "dbo.Users");
            DropForeignKey("dbo.Contact", "User_Id", "dbo.Users");
            DropIndex("dbo.Contact", new[] { "OwnerAccountId" });
            DropIndex("dbo.Contact", new[] { "ContactAccountId" });
            DropIndex("dbo.Contact", new[] { "User_Id" });
            DropColumn("dbo.Contact", "ContactAccountId");
            RenameColumn(table: "dbo.Contact", name: "User_Id", newName: "ContactAccountId");
            AlterColumn("dbo.Contact", "ContactAccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contact", "ContactAccountId");
            AddForeignKey("dbo.Contact", "ContactAccountId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Contact", "OwnerAccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "OwnerAccountId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Contact", "ContactAccountId", "dbo.Users");
            DropIndex("dbo.Contact", new[] { "ContactAccountId" });
            AlterColumn("dbo.Contact", "ContactAccountId", c => c.Int());
            RenameColumn(table: "dbo.Contact", name: "ContactAccountId", newName: "User_Id");
            AddColumn("dbo.Contact", "ContactAccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contact", "User_Id");
            CreateIndex("dbo.Contact", "ContactAccountId");
            CreateIndex("dbo.Contact", "OwnerAccountId");
            AddForeignKey("dbo.Contact", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Contact", "OwnerAccountId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}

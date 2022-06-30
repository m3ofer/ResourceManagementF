namespace ResourceManagementF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class starto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Computers", "ProvidersId_Id", "dbo.Providers");
            DropForeignKey("dbo.Printers", "ProvidersId_Id", "dbo.Providers");
            DropIndex("dbo.Computers", new[] { "ProvidersId_Id" });
            DropIndex("dbo.Printers", new[] { "ProvidersId_Id" });
            AlterColumn("dbo.Computers", "ProvidersId_Id", c => c.Int());
            AlterColumn("dbo.Printers", "ProvidersId_Id", c => c.Int());
            CreateIndex("dbo.Computers", "ProvidersId_Id");
            CreateIndex("dbo.Printers", "ProvidersId_Id");
            AddForeignKey("dbo.Computers", "ProvidersId_Id", "dbo.Providers", "Id");
            AddForeignKey("dbo.Printers", "ProvidersId_Id", "dbo.Providers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Printers", "ProvidersId_Id", "dbo.Providers");
            DropForeignKey("dbo.Computers", "ProvidersId_Id", "dbo.Providers");
            DropIndex("dbo.Printers", new[] { "ProvidersId_Id" });
            DropIndex("dbo.Computers", new[] { "ProvidersId_Id" });
            AlterColumn("dbo.Printers", "ProvidersId_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Computers", "ProvidersId_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Printers", "ProvidersId_Id");
            CreateIndex("dbo.Computers", "ProvidersId_Id");
            AddForeignKey("dbo.Printers", "ProvidersId_Id", "dbo.Providers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Computers", "ProvidersId_Id", "dbo.Providers", "Id", cascadeDelete: true);
        }
    }
}

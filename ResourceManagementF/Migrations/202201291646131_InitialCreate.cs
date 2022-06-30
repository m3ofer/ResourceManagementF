namespace ResourceManagementF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administratives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Isresp = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AcompDeps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Affecter = c.Boolean(nullable: false),
                        Panne = c.Boolean(nullable: false),
                        Comp_Id = c.Int(),
                        Deps_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Computers", t => t.Comp_Id)
                .ForeignKey("dbo.Departments", t => t.Deps_Id)
                .Index(t => t.Comp_Id)
                .Index(t => t.Deps_Id);
            
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DateLivraison = c.String(nullable: false),
                        Warranty = c.String(nullable: false),
                        Brand = c.String(),
                        Cpu = c.String(),
                        Ram = c.String(),
                        Storage = c.String(),
                        Monitor = c.String(),
                        ProvidersId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.ProvidersId_Id, cascadeDelete: true)
                .Index(t => t.ProvidersId_Id);
            
            CreateTable(
                "dbo.AcompTs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Affecter = c.Boolean(nullable: false),
                        Panne = c.Boolean(nullable: false),
                        Computers_Id = c.Int(),
                        Profs_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Computers", t => t.Computers_Id)
                .ForeignKey("dbo.Teachers", t => t.Profs_Id)
                .Index(t => t.Computers_Id)
                .Index(t => t.Profs_Id);
            
            CreateTable(
                "dbo.MaintenanceServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Services = c.Boolean(nullable: false),
                        AcompT_Id = c.Int(),
                        AprintT_Id = c.Int(),
                        AprintDep_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcompTs", t => t.AcompT_Id)
                .ForeignKey("dbo.AprintTs", t => t.AprintT_Id)
                .ForeignKey("dbo.AprintDeps", t => t.AprintDep_Id)
                .Index(t => t.AcompT_Id)
                .Index(t => t.AprintT_Id)
                .Index(t => t.AprintDep_Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Lab = c.String(nullable: false),
                        Ischef = c.Boolean(nullable: false),
                        DepartmentId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId_Id)
                .Index(t => t.DepartmentId_Id);
            
            CreateTable(
                "dbo.AprintTs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Affecter = c.Boolean(nullable: false),
                        Panne = c.Boolean(nullable: false),
                        Printers_Id = c.Int(),
                        Profs_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Printers", t => t.Printers_Id)
                .ForeignKey("dbo.Teachers", t => t.Profs_Id)
                .Index(t => t.Printers_Id)
                .Index(t => t.Profs_Id);
            
            CreateTable(
                "dbo.Printers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DateLivraison = c.String(nullable: false),
                        Warranty = c.String(nullable: false),
                        Brand = c.String(),
                        Speed = c.String(),
                        Resolution = c.String(),
                        ProvidersId_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.ProvidersId_Id, cascadeDelete: true)
                .Index(t => t.ProvidersId_Id);
            
            CreateTable(
                "dbo.AprintDeps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Affecter = c.Boolean(nullable: false),
                        Panne = c.Boolean(nullable: false),
                        Deps_Id = c.Int(),
                        Prints_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Deps_Id)
                .ForeignKey("dbo.Printers", t => t.Prints_Id)
                .Index(t => t.Deps_Id)
                .Index(t => t.Prints_Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Budget = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        CompanyName = c.String(nullable: false),
                        Adr = c.String(nullable: false),
                        Manager = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Computers", "ProvidersId_Id", "dbo.Providers");
            DropForeignKey("dbo.AprintTs", "Profs_Id", "dbo.Teachers");
            DropForeignKey("dbo.AprintTs", "Printers_Id", "dbo.Printers");
            DropForeignKey("dbo.Printers", "ProvidersId_Id", "dbo.Providers");
            DropForeignKey("dbo.AprintDeps", "Prints_Id", "dbo.Printers");
            DropForeignKey("dbo.MaintenanceServices", "AprintDep_Id", "dbo.AprintDeps");
            DropForeignKey("dbo.Teachers", "DepartmentId_Id", "dbo.Departments");
            DropForeignKey("dbo.AprintDeps", "Deps_Id", "dbo.Departments");
            DropForeignKey("dbo.AcompDeps", "Deps_Id", "dbo.Departments");
            DropForeignKey("dbo.MaintenanceServices", "AprintT_Id", "dbo.AprintTs");
            DropForeignKey("dbo.AcompTs", "Profs_Id", "dbo.Teachers");
            DropForeignKey("dbo.MaintenanceServices", "AcompT_Id", "dbo.AcompTs");
            DropForeignKey("dbo.AcompTs", "Computers_Id", "dbo.Computers");
            DropForeignKey("dbo.AcompDeps", "Comp_Id", "dbo.Computers");
            DropIndex("dbo.AprintDeps", new[] { "Prints_Id" });
            DropIndex("dbo.AprintDeps", new[] { "Deps_Id" });
            DropIndex("dbo.Printers", new[] { "ProvidersId_Id" });
            DropIndex("dbo.AprintTs", new[] { "Profs_Id" });
            DropIndex("dbo.AprintTs", new[] { "Printers_Id" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId_Id" });
            DropIndex("dbo.MaintenanceServices", new[] { "AprintDep_Id" });
            DropIndex("dbo.MaintenanceServices", new[] { "AprintT_Id" });
            DropIndex("dbo.MaintenanceServices", new[] { "AcompT_Id" });
            DropIndex("dbo.AcompTs", new[] { "Profs_Id" });
            DropIndex("dbo.AcompTs", new[] { "Computers_Id" });
            DropIndex("dbo.Computers", new[] { "ProvidersId_Id" });
            DropIndex("dbo.AcompDeps", new[] { "Deps_Id" });
            DropIndex("dbo.AcompDeps", new[] { "Comp_Id" });
            DropTable("dbo.Providers");
            DropTable("dbo.Departments");
            DropTable("dbo.AprintDeps");
            DropTable("dbo.Printers");
            DropTable("dbo.AprintTs");
            DropTable("dbo.Teachers");
            DropTable("dbo.MaintenanceServices");
            DropTable("dbo.AcompTs");
            DropTable("dbo.Computers");
            DropTable("dbo.AcompDeps");
            DropTable("dbo.Administratives");
        }
    }
}

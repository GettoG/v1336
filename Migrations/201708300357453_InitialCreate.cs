namespace v1336.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CommentThemeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommentThemes", t => t.CommentThemeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CommentThemeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CommentThemes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentThemeText = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nomenclatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        NomenclatureCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NomenclatureCategories", t => t.NomenclatureCategoryId, cascadeDelete: true)
                .Index(t => t.NomenclatureCategoryId);
            
            CreateTable(
                "dbo.NomenclatureCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(),
                        FatherName = c.String(),
                        Phone = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(),
                        FatherName = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Procent = c.Double(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Description = c.String(),
                        Number = c.Int(nullable: false),
                        Date_b = c.DateTime(nullable: false),
                        Date_e = c.DateTime(nullable: false),
                        ManagerPriority = c.Int(nullable: false),
                        AdminPriority = c.Int(),
                        ManagerId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId)
                .Index(t => t.ManagerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        NomenclatureId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nomenclatures", t => t.NomenclatureId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.NomenclatureId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DepartmentCommentThemes",
                c => new
                    {
                        Department_Id = c.Int(nullable: false),
                        CommentTheme_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Department_Id, t.CommentTheme_Id })
                .ForeignKey("dbo.Departments", t => t.Department_Id, cascadeDelete: true)
                .ForeignKey("dbo.CommentThemes", t => t.CommentTheme_Id, cascadeDelete: true)
                .Index(t => t.Department_Id)
                .Index(t => t.CommentTheme_Id);
            
            CreateTable(
                "dbo.NomenclatureDepartments",
                c => new
                    {
                        Nomenclature_Id = c.Int(nullable: false),
                        Department_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Nomenclature_Id, t.Department_Id })
                .ForeignKey("dbo.Nomenclatures", t => t.Nomenclature_Id, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_Id, cascadeDelete: true)
                .Index(t => t.Nomenclature_Id)
                .Index(t => t.Department_Id);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.User_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "StatusId", "dbo.Status");
            DropForeignKey("dbo.OrderRows", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderRows", "NomenclatureId", "dbo.Nomenclatures");
            DropForeignKey("dbo.Orders", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Employees", "Id", "dbo.Users");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Comments", "CommentThemeId", "dbo.CommentThemes");
            DropForeignKey("dbo.Nomenclatures", "NomenclatureCategoryId", "dbo.NomenclatureCategories");
            DropForeignKey("dbo.NomenclatureDepartments", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.NomenclatureDepartments", "Nomenclature_Id", "dbo.Nomenclatures");
            DropForeignKey("dbo.DepartmentCommentThemes", "CommentTheme_Id", "dbo.CommentThemes");
            DropForeignKey("dbo.DepartmentCommentThemes", "Department_Id", "dbo.Departments");
            DropIndex("dbo.RoleUsers", new[] { "User_Id" });
            DropIndex("dbo.RoleUsers", new[] { "Role_Id" });
            DropIndex("dbo.NomenclatureDepartments", new[] { "Department_Id" });
            DropIndex("dbo.NomenclatureDepartments", new[] { "Nomenclature_Id" });
            DropIndex("dbo.DepartmentCommentThemes", new[] { "CommentTheme_Id" });
            DropIndex("dbo.DepartmentCommentThemes", new[] { "Department_Id" });
            DropIndex("dbo.OrderRows", new[] { "NomenclatureId" });
            DropIndex("dbo.OrderRows", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "ManagerId" });
            DropIndex("dbo.Orders", new[] { "StatusId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", new[] { "Id" });
            DropIndex("dbo.Nomenclatures", new[] { "NomenclatureCategoryId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "CommentThemeId" });
            DropTable("dbo.RoleUsers");
            DropTable("dbo.NomenclatureDepartments");
            DropTable("dbo.DepartmentCommentThemes");
            DropTable("dbo.Status");
            DropTable("dbo.OrderRows");
            DropTable("dbo.Orders");
            DropTable("dbo.Managers");
            DropTable("dbo.Customers");
            DropTable("dbo.Roles");
            DropTable("dbo.Employees");
            DropTable("dbo.Users");
            DropTable("dbo.NomenclatureCategories");
            DropTable("dbo.Nomenclatures");
            DropTable("dbo.Departments");
            DropTable("dbo.CommentThemes");
            DropTable("dbo.Comments");
        }
    }
}

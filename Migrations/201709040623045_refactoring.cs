namespace v1336.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactoring : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 256),
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
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Nomenclatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomenclatureCategoryId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NomenclatureCategories", t => t.NomenclatureCategoryId, cascadeDelete: true)
                .Index(t => t.NomenclatureCategoryId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.NomenclatureCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.OrderRowHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderRowId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Procent = c.Double(nullable: false),
                        OrderRowStatusId = c.Int(nullable: false),
                        CommentId = c.Int(),
                        Worker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderRows", t => t.OrderRowId, cascadeDelete: true)
                .ForeignKey("dbo.OrderRowStatus", t => t.OrderRowStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.Worker_Id)
                .Index(t => t.OrderRowId)
                .Index(t => t.OrderRowStatusId)
                .Index(t => t.Worker_Id);
            
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
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Procent = c.Double(nullable: false),
                        Description = c.String(maxLength: 256),
                        Number = c.Int(nullable: false),
                        Date_b = c.DateTime(nullable: false),
                        Date_e = c.DateTime(nullable: false),
                        ManagerPriority = c.Int(nullable: false),
                        AdminPriority = c.Int(),
                        ManagerId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Comment = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderRowStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        FatherName = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 20),
                        EmployeePostId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.WorkerPosts", t => t.EmployeePostId, cascadeDelete: true)
                .Index(t => t.EmployeePostId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.WorkerPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
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
            DropForeignKey("dbo.OrderRowHistories", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.Workers", "EmployeePostId", "dbo.WorkerPosts");
            DropForeignKey("dbo.Workers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.OrderRowHistories", "OrderRowStatusId", "dbo.OrderRowStatus");
            DropForeignKey("dbo.OrderRowHistories", "OrderRowId", "dbo.OrderRows");
            DropForeignKey("dbo.OrderRows", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderRows", "NomenclatureId", "dbo.Nomenclatures");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_Id", "dbo.Roles");
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
            DropIndex("dbo.WorkerPosts", new[] { "Name" });
            DropIndex("dbo.Workers", new[] { "DepartmentId" });
            DropIndex("dbo.Workers", new[] { "EmployeePostId" });
            DropIndex("dbo.OrderRowStatus", new[] { "Name" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderRows", new[] { "NomenclatureId" });
            DropIndex("dbo.OrderRows", new[] { "OrderId" });
            DropIndex("dbo.OrderRowHistories", new[] { "Worker_Id" });
            DropIndex("dbo.OrderRowHistories", new[] { "OrderRowStatusId" });
            DropIndex("dbo.OrderRowHistories", new[] { "OrderRowId" });
            DropIndex("dbo.Customers", new[] { "Name" });
            DropIndex("dbo.Roles", new[] { "Name" });
            DropIndex("dbo.Users", new[] { "Name" });
            DropIndex("dbo.NomenclatureCategories", new[] { "Name" });
            DropIndex("dbo.Nomenclatures", new[] { "Name" });
            DropIndex("dbo.Nomenclatures", new[] { "NomenclatureCategoryId" });
            DropIndex("dbo.Departments", new[] { "Name" });
            DropIndex("dbo.CommentThemes", new[] { "Name" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "CommentThemeId" });
            DropTable("dbo.RoleUsers");
            DropTable("dbo.NomenclatureDepartments");
            DropTable("dbo.DepartmentCommentThemes");
            DropTable("dbo.WorkerPosts");
            DropTable("dbo.Workers");
            DropTable("dbo.OrderRowStatus");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderRows");
            DropTable("dbo.OrderRowHistories");
            DropTable("dbo.Customers");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.NomenclatureCategories");
            DropTable("dbo.Nomenclatures");
            DropTable("dbo.Departments");
            DropTable("dbo.CommentThemes");
            DropTable("dbo.Comments");
        }
    }
}

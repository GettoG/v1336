namespace v1336.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class managers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DepartmentCommentThemes", newName: "CommentThemeDepartments");
            DropForeignKey("dbo.Employees", "Id", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.Employees", new[] { "Id" });
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Employees");
            DropPrimaryKey("dbo.CommentThemeDepartments");
            AddColumn("dbo.Employees", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "FirstName", c => c.String());
            AddColumn("dbo.Employees", "FatherName", c => c.String());
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Employees", "Id");
            AddPrimaryKey("dbo.CommentThemeDepartments", new[] { "CommentTheme_Id", "Department_Id" });
            CreateIndex("dbo.Users", "Id");
            AddForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Id", "dbo.Employees", "Id");
            DropColumn("dbo.Employees", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            DropForeignKey("dbo.Users", "Id", "dbo.Employees");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Id" });
            DropPrimaryKey("dbo.CommentThemeDepartments");
            DropPrimaryKey("dbo.Employees");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Employees", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Employees", "FatherName");
            DropColumn("dbo.Employees", "FirstName");
            DropColumn("dbo.Employees", "LastName");
            AddPrimaryKey("dbo.CommentThemeDepartments", new[] { "Department_Id", "CommentTheme_Id" });
            AddPrimaryKey("dbo.Employees", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Employees", "Id");
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "Id", "dbo.Users", "Id");
            RenameTable(name: "dbo.CommentThemeDepartments", newName: "DepartmentCommentThemes");
        }
    }
}

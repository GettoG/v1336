namespace v1336.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Id", "dbo.Employees");
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Id" });
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Users", "Employee_Id", c => c.Int());
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Users", "Employee_Id");
            AddForeignKey("dbo.Users", "Employee_Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Users", new[] { "Employee_Id" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Employee_Id");
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Users", "Id");
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Id", "dbo.Employees", "Id");
        }
    }
}

namespace v1336.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Id", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.Employees", new[] { "Id" });
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Employees", "Id");
            CreateIndex("dbo.Users", "Id");
            AddForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Id", "dbo.Employees");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Id" });
            DropPrimaryKey("dbo.Employees");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Employees", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Employees", "Id");
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "Id", "dbo.Users", "Id");
        }
    }
}

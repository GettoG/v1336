namespace v1336.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Managers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Managers", "FirstName", c => c.String());
            AddColumn("dbo.Managers", "FatherName", c => c.String());
            AddColumn("dbo.Managers", "Phone", c => c.String());
            DropColumn("dbo.Managers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Managers", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Managers", "Phone");
            DropColumn("dbo.Managers", "FatherName");
            DropColumn("dbo.Managers", "FirstName");
            DropColumn("dbo.Managers", "LastName");
        }
    }
}

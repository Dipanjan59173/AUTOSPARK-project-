namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createcustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "City", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "PostalCode", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Password", c => c.String());
            AddColumn("dbo.Customers", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ConfirmPassword");
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Customers", "PostalCode");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "Address");
        }
    }
}

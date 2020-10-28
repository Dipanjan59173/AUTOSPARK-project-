namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkdeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Cars", new[] { "Customer_Id" });
            DropColumn("dbo.Cars", "CustId");
            DropColumn("dbo.Cars", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Customer_Id", c => c.Int());
            AddColumn("dbo.Cars", "CustId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "Customer_Id");
            AddForeignKey("dbo.Cars", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}

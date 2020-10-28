namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cartableadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VIN = c.String(),
                        BrandName = c.String(),
                        Color = c.String(),
                        Style = c.String(),
                        Year = c.DateTime(nullable: false),
                        Model = c.String(),
                        CustId = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Cars", new[] { "Customer_Id" });
            DropTable("dbo.Cars");
        }
    }
}

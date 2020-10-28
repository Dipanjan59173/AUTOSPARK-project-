namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviceavailtablecreatedandforeignkeyadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceAvails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceType = c.String(),
                        Car_Id = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Car_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceAvails", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.ServiceAvails", "Car_Id", "dbo.Cars");
            DropIndex("dbo.ServiceAvails", new[] { "Customer_Id" });
            DropIndex("dbo.ServiceAvails", new[] { "Car_Id" });
            DropTable("dbo.ServiceAvails");
        }
    }
}

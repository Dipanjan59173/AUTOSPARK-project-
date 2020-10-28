namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shoppingcartsadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Car_Id = c.Int(),
                        ServiceType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceType_Id)
                .Index(t => t.Car_Id)
                .Index(t => t.ServiceType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceShoppingCarts", "ServiceType_Id", "dbo.ServiceTypes");
            DropForeignKey("dbo.ServiceShoppingCarts", "Car_Id", "dbo.Cars");
            DropIndex("dbo.ServiceShoppingCarts", new[] { "ServiceType_Id" });
            DropIndex("dbo.ServiceShoppingCarts", new[] { "Car_Id" });
            DropTable("dbo.ServiceShoppingCarts");
        }
    }
}

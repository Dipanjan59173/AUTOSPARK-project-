namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "CustomerId");
            AddForeignKey("dbo.Cars", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Cars", new[] { "CustomerId" });
            DropColumn("dbo.Cars", "CustomerId");
        }
    }
}

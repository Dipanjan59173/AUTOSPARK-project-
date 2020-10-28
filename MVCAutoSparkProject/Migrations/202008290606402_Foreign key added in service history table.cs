namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foreignkeyaddedinservicehistorytable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceHistories", "CarId", c => c.Int(nullable: false));
            CreateIndex("dbo.ServiceHistories", "CarId");
            AddForeignKey("dbo.ServiceHistories", "CarId", "dbo.Cars", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceHistories", "CarId", "dbo.Cars");
            DropIndex("dbo.ServiceHistories", new[] { "CarId" });
            DropColumn("dbo.ServiceHistories", "CarId");
        }
    }
}

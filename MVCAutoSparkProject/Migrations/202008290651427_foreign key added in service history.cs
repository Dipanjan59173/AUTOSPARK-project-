namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeyaddedinservicehistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceHistories", "DetailId", c => c.Int(nullable: false));
            CreateIndex("dbo.ServiceHistories", "DetailId");
            AddForeignKey("dbo.ServiceHistories", "DetailId", "dbo.Details", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceHistories", "DetailId", "dbo.Details");
            DropIndex("dbo.ServiceHistories", new[] { "DetailId" });
            DropColumn("dbo.ServiceHistories", "DetailId");
        }
    }
}

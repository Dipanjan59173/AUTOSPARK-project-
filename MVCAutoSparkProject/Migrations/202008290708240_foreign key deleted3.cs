namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeydeleted3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceHistories", "DetailId", "dbo.Details");
            DropIndex("dbo.ServiceHistories", new[] { "DetailId" });
            DropColumn("dbo.ServiceHistories", "DetailId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceHistories", "DetailId", c => c.Int(nullable: false));
            CreateIndex("dbo.ServiceHistories", "DetailId");
            AddForeignKey("dbo.ServiceHistories", "DetailId", "dbo.Details", "Id", cascadeDelete: true);
        }
    }
}

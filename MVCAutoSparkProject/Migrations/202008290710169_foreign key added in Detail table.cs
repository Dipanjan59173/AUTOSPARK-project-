namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeyaddedinDetailtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Details", "ServiceHistoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Details", "ServiceHistoryId");
            AddForeignKey("dbo.Details", "ServiceHistoryId", "dbo.ServiceHistories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details", "ServiceHistoryId", "dbo.ServiceHistories");
            DropIndex("dbo.Details", new[] { "ServiceHistoryId" });
            DropColumn("dbo.Details", "ServiceHistoryId");
        }
    }
}

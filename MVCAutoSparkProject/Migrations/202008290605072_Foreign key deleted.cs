namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foreignkeydeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "ServiceHistoryId", "dbo.ServiceHistories");
            DropIndex("dbo.Cars", new[] { "ServiceHistoryId" });
            DropColumn("dbo.Cars", "ServiceHistoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "ServiceHistoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "ServiceHistoryId");
            AddForeignKey("dbo.Cars", "ServiceHistoryId", "dbo.ServiceHistories", "Id", cascadeDelete: true);
        }
    }
}

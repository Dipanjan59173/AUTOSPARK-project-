namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foreignkeyaddedincartableandservicehistorytablecreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Miles = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "ServiceHistoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "ServiceHistoryId");
            AddForeignKey("dbo.Cars", "ServiceHistoryId", "dbo.ServiceHistories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "ServiceHistoryId", "dbo.ServiceHistories");
            DropIndex("dbo.Cars", new[] { "ServiceHistoryId" });
            DropColumn("dbo.Cars", "ServiceHistoryId");
            DropTable("dbo.ServiceHistories");
        }
    }
}

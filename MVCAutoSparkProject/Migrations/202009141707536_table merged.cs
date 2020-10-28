namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablemerged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Details", "ServiceHistoryId", "dbo.ServiceHistories");
            DropIndex("dbo.Details", new[] { "ServiceHistoryId" });
            AddColumn("dbo.ServiceHistories", "ServiceType", c => c.String());
            AddColumn("dbo.ServiceHistories", "Price", c => c.Double(nullable: false));
            DropTable("dbo.Details");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceType = c.String(),
                        Price = c.Double(nullable: false),
                        ServiceHistoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.ServiceHistories", "Price");
            DropColumn("dbo.ServiceHistories", "ServiceType");
            CreateIndex("dbo.Details", "ServiceHistoryId");
            AddForeignKey("dbo.Details", "ServiceHistoryId", "dbo.ServiceHistories", "Id", cascadeDelete: true);
        }
    }
}

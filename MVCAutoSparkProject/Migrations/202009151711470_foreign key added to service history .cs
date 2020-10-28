namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeyaddedtoservicehistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceHistories", "ServiceTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ServiceHistories", "ServiceTypeId");
            AddForeignKey("dbo.ServiceHistories", "ServiceTypeId", "dbo.ServiceTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.ServiceHistories", "ServiceType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceHistories", "ServiceType", c => c.String());
            DropForeignKey("dbo.ServiceHistories", "ServiceTypeId", "dbo.ServiceTypes");
            DropIndex("dbo.ServiceHistories", new[] { "ServiceTypeId" });
            DropColumn("dbo.ServiceHistories", "ServiceTypeId");
        }
    }
}

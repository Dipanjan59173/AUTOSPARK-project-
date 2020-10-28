namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Summarytableadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceSummaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceType_Id)
                .Index(t => t.ServiceType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceSummaries", "ServiceType_Id", "dbo.ServiceTypes");
            DropIndex("dbo.ServiceSummaries", new[] { "ServiceType_Id" });
            DropTable("dbo.ServiceSummaries");
        }
    }
}

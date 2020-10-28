namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pricedeletedfromhistory : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ServiceHistories", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceHistories", "Price", c => c.Double(nullable: false));
        }
    }
}

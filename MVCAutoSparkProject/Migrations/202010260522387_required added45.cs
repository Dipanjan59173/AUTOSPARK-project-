namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredadded45 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ServiceTypes", "ServiceTpe", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceTypes", "ServiceTpe", c => c.String());
        }
    }
}

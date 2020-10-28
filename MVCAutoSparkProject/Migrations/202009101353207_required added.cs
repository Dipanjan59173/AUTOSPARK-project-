namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredadded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "VIN", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "BrandName", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "Color", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "Style", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "Model", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Model", c => c.String());
            AlterColumn("dbo.Cars", "Style", c => c.String());
            AlterColumn("dbo.Cars", "Color", c => c.String());
            AlterColumn("dbo.Cars", "BrandName", c => c.String());
            AlterColumn("dbo.Cars", "VIN", c => c.String());
        }
    }
}

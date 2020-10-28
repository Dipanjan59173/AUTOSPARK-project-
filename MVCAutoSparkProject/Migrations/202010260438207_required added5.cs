namespace MVCAutoSparkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredadded5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "EmailId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "EmailId", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}

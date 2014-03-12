namespace MissionPlanningWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationsMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DistributionRules", "ChrCond", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.DistributionRules", "ConstrCond", c => c.String(nullable: false, maxLength: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DistributionRules", "ConstrCond", c => c.String());
            AlterColumn("dbo.DistributionRules", "ChrCond", c => c.String());
        }
    }
}

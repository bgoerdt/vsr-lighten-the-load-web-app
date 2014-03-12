namespace MissionPlanningWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DistributionRules", "ChrCond", c => c.String());
            AddColumn("dbo.DistributionRules", "ConstrCond", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DistributionRules", "ConstrCond");
            DropColumn("dbo.DistributionRules", "ChrCond");
        }
    }
}

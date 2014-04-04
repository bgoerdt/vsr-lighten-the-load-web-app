namespace MissionPlanningWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EquimentandDist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DistributionRules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ChrIndex = c.Int(nullable: false),
                        ChrCond = c.String(),
                        ChrData = c.Int(nullable: false),
                        EquipIndex = c.Int(nullable: false),
                        ConstrCond = c.String(),
                        ConstrRHS = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EquipmentID = c.Int(nullable: false),
                        Weight = c.Single(nullable: false),
                        Firepower = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
            DropTable("dbo.DistributionRules");
            DropTable("dbo.Equipments");
        }
    }
}

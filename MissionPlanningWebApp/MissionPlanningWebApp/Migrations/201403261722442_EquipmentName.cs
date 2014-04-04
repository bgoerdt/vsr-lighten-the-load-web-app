namespace MissionPlanningWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EquipmentName : DbMigration
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
                        Fighter_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Fighters", t => t.Fighter_ID)
                .ForeignKey("dbo.Equipments", t => t.EquipIndex, cascadeDelete: true)
                .Index(t => t.Fighter_ID)
                .Index(t => t.EquipIndex);
            
            CreateTable(
                "dbo.Fighters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Toughness = c.Single(nullable: false),
                        Size = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        PerformanceFitnessTest = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.DistributionRules", new[] { "EquipIndex" });
            DropIndex("dbo.DistributionRules", new[] { "Fighter_ID" });
            DropForeignKey("dbo.DistributionRules", "EquipIndex", "dbo.Equipments");
            DropForeignKey("dbo.DistributionRules", "Fighter_ID", "dbo.Fighters");
            DropTable("dbo.Fighters");
            DropTable("dbo.DistributionRules");
        }
    }
}

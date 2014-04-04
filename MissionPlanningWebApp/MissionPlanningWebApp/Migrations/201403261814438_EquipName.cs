namespace MissionPlanningWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EquipName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                        EquipmentID = c.Int(nullable: false, identity: true),
                        Weight = c.Single(nullable: false),
                        Firepower = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentID);
            
            AddForeignKey("dbo.DistributionRules", "EquipIndex", "dbo.Equipments", "EquipmentID", cascadeDelete: true);
            CreateIndex("dbo.DistributionRules", "EquipIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.DistributionRules", new[] { "EquipIndex" });
            DropForeignKey("dbo.DistributionRules", "EquipIndex", "dbo.Equipments");
            DropTable("dbo.Equipments");
        }
    }
}

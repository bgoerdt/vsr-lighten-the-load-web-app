namespace MissionPlanningWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEquipmentID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipments", "EquipmentID", c => c.Int(nullable: false));
            DropColumn("dbo.Equipments", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Equipments", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Equipments", "EquipmentID");
        }
    }
}

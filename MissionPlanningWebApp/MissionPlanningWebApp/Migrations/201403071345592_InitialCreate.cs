namespace MissionPlanningWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Equipments",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Quantity = c.Int(nullable: false),
            //            Weight = c.Single(nullable: false),
            //            Firepower = c.Single(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);
        }

        public override void Down()
        {
            //DropTable("dbo.Equipments");
        }
    }
}

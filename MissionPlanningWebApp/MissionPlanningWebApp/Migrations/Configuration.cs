namespace MissionPlanningWebApp.Migrations
{
    using MissionPlanningWebApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MissionPlanningWebApp.Models.DistributionRulesDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MissionPlanningWebApp.Models.DistributionRulesDBContext context)
        {
            context.DistributionRules.AddOrUpdate(
                new DistributionRules()
                {
                    ChrIndex = 0,
                    ChrCond = "L",
                    ChrData = 6,
                    EquipIndex = 0,
                    ConstrCond = "L",
                    ConstrRHS = 6
                },

                new DistributionRules()
                {
                    ChrIndex = 0,
                    ChrCond = "G",
                    ChrData = 8,
                    EquipIndex = 0,
                    ConstrCond = "L",
                    ConstrRHS = 12
                }
                );
        }
    }
}

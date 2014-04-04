namespace MissionPlanningWebApp.Migrations
{
    using MissionPlanningWebApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    //internal sealed class Configuration : DbMigrationsConfiguration<MissionPlanningWebApp.Models.DistributionRulesDBContext>
    //{
    //    public Configuration()
    //    {
    //        AutomaticMigrationsEnabled = true;
    //    }

    //}

    internal sealed class Configuration : DbMigrationsConfiguration<MissionPlanningWebApp.Models.LtLDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LtLDbContext context)
        {
 	        base.Seed(context);

            var characteristics = new List<Characteristic>()
            { 
                //Toughness, Size/Strength, Experience, PFT Score
                new Characteristic { Char = "Toughness" },
                new Characteristic { Char = "Size/Strength"},
                new Characteristic { Char = "Experience" },
                new Characteristic { Char = "PFT Score" }
            };

            characteristics.ForEach(chr => context.Characteristics.AddOrUpdate(c => c.Char, chr));
            context.SaveChanges();
        }
    }
}

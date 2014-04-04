using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using MissionPlanningWebApp.Models;

namespace MissionPlanningWebApp.Models
{
    public class LtLDbContext : DbContext
    {
        public DbSet<DistributionRules> DistributionRules { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Fighter> Fighters { get; set; }
        public DbSet<FighterCharacteristic> FighterCharacteristics { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<MissionParameter> MissionParameters { get; set; }
        public DbSet<MissionRule> MissionRules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
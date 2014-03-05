using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MissionPlanningWebApp.Models
{
    public class Fighter
    {
        public int ID { get; set; }
        public float Toughness { get; set; }
        public int Size { get; set; }
        public int Experience { get; set; }
        public int PerformanceFitnessTest { get; set; }
    }

    public class FighterDBContext : DbContext
    {
        public DbSet<Fighter> Fighter { get; set; }
    }
}
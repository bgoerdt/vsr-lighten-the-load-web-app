using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MissionPlanningWebApp.Models
{
    public class DistributionRules
    {
        public int ID { get; set; }
        public int ChrIndex { get; set; }
        public char ChrCond { get; set; }
        public int ChrData { get; set; }
        public int EquipIndex { get; set; }
        public char ConstrCond { get; set; }
        public int ConstrRHS { get; set; }
    }

    public class DistributionRulesDBContext : DbContext
    {
        public DbSet<DistributionRules> DistributionRules { get; set; }
    }
}
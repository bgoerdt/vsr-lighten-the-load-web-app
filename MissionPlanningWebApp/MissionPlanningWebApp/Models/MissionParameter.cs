using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MissionPlanningWebApp.Models
{
    public class MissionParameter
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public Boolean IsSelected { get; set; } 
    }

    public class MissionParameterDbContext : DbContext
    {
        public DbSet<MissionParameter> MissionParameters { get; set; }
    }
}
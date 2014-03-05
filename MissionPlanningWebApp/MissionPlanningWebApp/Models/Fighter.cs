using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MissionPlanningWebApp.Models
{
    public class Fighter
    {
        public int ID { get; set; }
        public int Toughness { get; set; }
        public int Strength { get; set; }
        public int experience { get; set; }
        public int PFT { get; set; }
    }
    public class FighterDBContext : DbContext
    {

    }
}
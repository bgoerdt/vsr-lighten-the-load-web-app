using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MissionPlanningWebApp.Models
{
    public class DistributionRules
    {
        public int ID { get; set; }

        [ForeignKey("Chr")]
        public int ChrId { get; set; }
        public virtual Characteristic Chr { get; set; }

        public string ChrCond { get; set; }
        public int ChrData { get; set; }

        [ForeignKey("Equip")]
        public int EquipId { get; set; }
        public virtual Equipment Equip { get; set; }

        public string ConstrCond { get; set; }
        public int ConstrRHS { get; set; }
    }
}
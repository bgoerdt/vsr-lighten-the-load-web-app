using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace MissionPlanningWebApp.Models
{
    public class DistributionRules
    {
        public int ID { get; set; }

        [ForeignKey("Chr")]
        [Display(Name="Characteristic")]
        public int ChrId { get; set; }
        public virtual Characteristic Chr { get; set; }

        [Display(Name = "Condition")]
        public string ChrCond { get; set; }
        [Display(Name = "Value")]
        public string ChrData { get; set; }

        [ForeignKey("Equip")]
        [Display(Name="Equipment")]
        public int EquipId { get; set; }
        public virtual Equipment Equip { get; set; }

        [Display(Name = "Constraint")]
        public string ConstrCond { get; set; }
        [Display(Name = "Value")]
        public int ConstrRHS { get; set; }
    }
}
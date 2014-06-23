using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Resources;

namespace MissionPlanningWebApp.Models
{
    public class Warfighter
    {
        public int ID { get; set; }
        public string Name { get; set; }
		public double Weight { get; set; }
        public Boolean IsSelected { get; set; }
        public virtual ICollection<WarfighterCharacteristic> WarfighterCharacteristics { get; set; }
    }

    public class WarfighterCharacteristic
    {
        public WarfighterCharacteristic() { }
        public WarfighterCharacteristic(int fID, int cID, string cVal)
        {
            WarfighterID = fID;
            CharID = cID;
            CharValue = cVal;
        }

        public string CharValue { get; set; }

        [Key]
        [Column(Order = 0)]
        [ForeignKey("Warfighter")]
        public int WarfighterID { get; set; }
        public virtual Warfighter Warfighter { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Characteristic")]
        public int CharID { get; set; }
        public virtual Characteristic Characteristic { get; set; }
    }

    public class Characteristic
    {
        public int ID { get; set; }
        [Display(Name="Characteristic")]
        public string Char { get; set; }
    }
}
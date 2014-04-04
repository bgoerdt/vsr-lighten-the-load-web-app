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
    public class Fighter
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FighterCharacteristic> FighterCharacteristics { get; set; }
    }

    public class FighterCharacteristic
    {
		public FighterCharacteristic(){}
		public FighterCharacteristic(int fID, int cID, float cVal)
		{
			FighterID = fID;
			CharID = cID;
			CharValue = cVal;
		}

        public float CharValue { get; set; }

        [Key]
        [Column(Order = 0)]
        [ForeignKey("Fighter")]
        public int FighterID { get; set; }
        public virtual Fighter Fighter { get; set; }

        [Key][Column(Order = 1)]
        [ForeignKey("Characteristic")]
        public int CharID { get; set; }
        public virtual Characteristic Characteristic { get; set; }
    }

    public class Characteristic
    {
        public int ID { get; set; }
        public string Char { get; set; }
    }
}
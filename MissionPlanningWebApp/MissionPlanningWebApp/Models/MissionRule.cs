using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace MissionPlanningWebApp.Models
{
	public class MissionRule
	{
		// constructor
		public MissionRule() { }
		public MissionRule(int id, int pInd, string rCond, int rDat, int eInd, string constrCond, int constrRHS)
		{
			ID = id;
			ParamId = pInd;
			RuleCond = rCond;
			RuleData = rDat;
			EquipId = eInd;
			ConstrCond = constrCond;
			ConstrRHS = constrRHS;
		}

		//MParaIndex, RuleCond, RuleData, EquipIndex, ConstrCond, ConstrRHS
		public int ID { get; set; }

		[Required]
        [ForeignKey ("Param")]
		public int ParamId { get; set; }
        public virtual MissionParameter Param { get; set; }
		[DisplayName("Parameter")]
        public string ParamName
        {
            get
            {
                return Param.Name;
            }
        }

		[Required]
		public string RuleCond { get; set; }

		[Required]
		public int RuleData { get; set; }

		[Required]
        [ForeignKey("Equip")]
		public int EquipId { get; set; }
        public virtual Equipment Equip { get; set; }
		[DisplayName("Equipment")]
        public string EquipName
        {
            get
            {
                return Equip.Name;
            }
        }

		[Required]
		public string ConstrCond { get; set; }

		[Required]
		public int ConstrRHS { get; set; }
	}
}
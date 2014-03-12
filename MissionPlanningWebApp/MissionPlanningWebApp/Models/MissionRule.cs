using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MissionPlanningWebApp.Models
{
	public class MissionRule
	{
		// constructor
		public MissionRule() { }
		public MissionRule(int id, int pInd, string rCond, int rDat, int eInd, string constrCond, int constrRHS)
		{
			ID = id;
			ParamIndex = pInd;
			RuleCond = rCond;
			RuleData = rDat;
			EquipIndex = eInd;
			ConstrCond = constrCond;
			ConstrRHS = constrRHS;
		}

		//MParaIndex, RuleCond, RuleData, EquipIndex, ConstrCond, ConstrRHS
		public int ID { get; set; }

		[Required]
		public int ParamIndex { get; set; }

		[Required]
		public string RuleCond { get; set; }

		[Required]
		public int RuleData { get; set; }

		[Required]
		public int EquipIndex { get; set; }

		[Required]
		public string ConstrCond { get; set; }

		[Required]
		public int ConstrRHS { get; set; }
	}

	public class MissionRuleDbContext : DbContext
	{
		public DbSet<MissionRule> MissionRules { get; set; }
	}
}
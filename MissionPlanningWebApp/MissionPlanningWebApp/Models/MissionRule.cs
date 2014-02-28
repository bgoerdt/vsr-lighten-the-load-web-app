using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MissionPlanningWebApp.Models
{
	public class MissionRule
	{
		//MParaIndex, RuleCond, RuleData, EquipIndex, ConstrCond, ConstrRHS

		public int ID { get; set; }
		public int ParamIndex { get; set; }
		public char RuleCond { get; set; }
		public int RuleData { get; set; }
		public int EquipIndex { get; set; }
		public char ConstrCond { get; set; }
		public int ConstrRHS { get; set; }
	}

	public class MissionRuleDbContext : DbContext
	{
		public DbSet<MissionRule> MissionRules { get; set; }
	}
}
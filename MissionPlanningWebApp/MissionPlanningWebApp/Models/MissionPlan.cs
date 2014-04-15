using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MissionPlanningWebApp.Models;

namespace MissionPlanningWebApp.Models
{
	public class MissionPlan
	{
		public Dictionary<Equipment, int> EquipmentList { get; set; }

		private LtLDbContext db = new LtLDbContext();
		private string serverDir;

		public void planMission(string dir)
		{
			serverDir = dir;

			//export data
			// _exportEquipment();
			// _exportParameters();
			_exportMissionRules();

			// call exe on server

			_getMissionResults();
		}

		private void _getMissionResults()
		{
			// get results from MissionPlanning.txt and add to EquipmentList
			string path = serverDir + "Mission_Planning.txt";
			StreamReader reader = new StreamReader(path);
			string line = "";
			int i = 1;
			while ((line = reader.ReadLine()) != null)
			{
				EquipmentList.Add(db.Equipment.Find(i), Convert.ToInt32(line));
				i++;
			}
		}

		private void _exportMissionRules()
		{
			string path = serverDir + "Rules_Mission.txt";
			StreamWriter writer = new StreamWriter(path);
			var missionRules = db.MissionRules.ToList();
			foreach (var rule in missionRules)
			{
				Dictionary<string, string> conditions = new Dictionary<string, string>()
				{
					{ "<", "L" },
					{ "=", "E" },
					{ ">", "G" }
				};

				string ruleCond = conditions[rule.RuleCond];
				string constrCond = conditions[rule.ConstrCond];

				writer.WriteLine((rule.ParamId - 1) + "\t" + ruleCond + "\t" + rule.RuleData + "\t" + (rule.EquipId - 1) + "\t" + constrCond + "\t" + rule.ConstrRHS);
			}

			writer.Close();
		}
	}
}
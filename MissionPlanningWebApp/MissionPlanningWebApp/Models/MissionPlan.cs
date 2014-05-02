using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using MissionPlanningWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MissionPlanningWebApp.Models
{
	public class MissionPlan
	{
		public Dictionary<Equipment, int> EquipmentList { get; set; }

		[Display(Name = "Number of Warfighters")]  
        public int NumberOfWarfighters;

		[Display(Name = "Total Weight of Equipment")]
        public double TotalWeightOfEquipment;

        public double EquipmentWeightPerWarfighter;

        public MissionPlan()
        {
            EquipmentList=new Dictionary<Equipment,int>();

        }

       // private LtLDbContext db = new LtLDbContext();
        private string serverDir;

        public void planMission(string dir, List<Equipment> equipment, List<MissionParameter> missionParameter, List<MissionRule> missionRule)
        {
            serverDir = dir;

            //export data
            _exportEquipment(equipment);
            _exportParameters(missionParameter);
            _exportMissionRules(missionRule);

            // call exe on server

            _getMissionResults(equipment);
        }

        private void _getMissionResults(List<Equipment> equipment)
        {
            // get results from MissionPlanning.txt and add to EquipmentList
            string path = serverDir + "Mission_Planning.txt";
            StreamReader reader = new StreamReader(path);
            string line = "";
            int i = 1;
            char[] separators = { ' ' };

            string[] lines = reader.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            NumberOfWarfighters = Convert.ToInt32(lines[lines.Length - 1]);

            lines = reader.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            TotalWeightOfEquipment = Convert.ToDouble(lines[lines.Length - 1]);
            lines = reader.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            EquipmentWeightPerWarfighter = Convert.ToDouble(lines[lines.Length - 1]);
            reader.ReadLine();
            reader.ReadLine();
            EquipmentList = new Dictionary<Equipment, int>();
            while ((line = reader.ReadLine()) != null)
            {
                var val = Convert.ToInt32(line);
				if(val != 0)
				{
					EquipmentList.Add(equipment.Find(e => e.ID == i), val);
				}
                i++;
            }
        }

        private void _exportParameters(List<MissionParameter> missionParameter)
        {
            List<MissionParameter> missionParameters = missionParameter;

            string path = serverDir + "Mission_Parameters.txt";
            using (StreamWriter file = new StreamWriter(path))
            {
                string totalNumberParameters = missionParameters.Count.ToString();
                file.WriteLine("#number of mission parameters");
                file.WriteLine(totalNumberParameters);
                foreach (MissionParameter d in missionParameters)
                {

                    string line = string.Format("{0} {1} {2} {3}",
                        d.ID, d.Name, d.Value, d.IsSelected);
                    file.WriteLine("#{0}", d.Name);
                    file.WriteLine("{0}\t{1}",
                       (d.ID - 1), d.Value);
                }
            }
        }


        private void _exportEquipment(List<Equipment> equipment)
        {
            string path = serverDir + "Equipments.txt";
            using (StreamWriter file = new StreamWriter(path))
            {
                string totalNumberParameters = equipment.Count.ToString();
                file.WriteLine("#number of equipment");
                file.WriteLine(totalNumberParameters);
                foreach (Equipment d in equipment)
                {

                    string line = string.Format("{0} {1} {2} {3}",
                        d.ID, d.Name, d.Weight, d.Firepower);
                    file.WriteLine("#{0}", d.Name);
                    file.WriteLine("{0}\t{1}\t{2}",
                       (d.ID - 1), d.Weight, d.Firepower);
                }
            }
        }


        private void _exportMissionRules(List<MissionRule> missionRule)
        {
            string path = serverDir + "Rules_Mission.txt";
            StreamWriter writer = new StreamWriter(path);
            var missionRules = missionRule;
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using MissionPlanningWebApp.Models;

namespace MissionPlanningWebApp.Models
{
	public class MissionPlan
	{
		public Dictionary<Equipment, int> EquipmentList { get; set; }
        public int NumberOfWarfighters;
        public double TotalWeightOfEquipment;
        public double EquipmentWeightPerWarfighter; 
        

        private LtLDbContext db = new LtLDbContext();
        private string serverDir;

        public void planMission(string dir)
        {
            serverDir = dir;

            //export data
            _exportEquipment();
            _exportParameters();
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
                EquipmentList.Add(db.Equipment.Find(i), Convert.ToInt32(line));
                i++;
            }
        }

        private void _exportParameters()
        {
            List<MissionParameter> missionParameters = db.MissionParameters.ToList();

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


        private void _exportEquipment()
        {
            List<Equipment> equipment = db.Equipment.ToList();

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
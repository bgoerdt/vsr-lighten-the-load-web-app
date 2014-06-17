using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		
		public void planMission(string dir, List<Equipment> equipment, List<MissionParameter> missionParameter, List<MissionRule> missionRule, List<Warfighter> warfighters)
        {
            serverDir = dir;

            //export data
            _exportEquipment(equipment);
            _exportParameters(missionParameter);
            _exportMissionRules(missionRule);
			_exportWarfighters(warfighters);

            // call exe on server
			Process kProcess = new Process();

			// set up folder and EXE file
			kProcess.StartInfo.WorkingDirectory = serverDir;
			kProcess.StartInfo.FileName = serverDir + "mission_planning.exe";

			// comment in to hide window
			kProcess.StartInfo.CreateNoWindow = true;
			kProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

			// start the EXE
			kProcess.Start();

			// wait for the EXE to finish
			while (kProcess.HasExited == false)
			{
				System.Threading.Thread.Sleep(100);
			}

			kProcess.Close();

			// get results from file
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

			reader.Close();
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

		public void _exportWarfighters(List<Warfighter> warfighters) // TODO FighterCharacteristics must be in correct order to write to database
		{
			string path = serverDir + "Warfighter_Members.txt";
			int numChars = warfighters.First().WarfighterCharacteristics.Count;
			using (StreamWriter file = new StreamWriter(path))
			{
				file.WriteLine("# Number of warfighters");
				file.WriteLine(warfighters.Count);
				file.WriteLine("# Number of characteristics (Maximum is 20)");
				file.WriteLine(numChars);
				file.WriteLine("# Maximum weight of carriage per warfighter");
				file.WriteLine("10000");
				foreach (Warfighter f in warfighters)
				{
					file.WriteLine("# " + f.Name);
					string line = (f.ID - 1).ToString();
					foreach (WarfighterCharacteristic fChr in f.WarfighterCharacteristics)
					{
						if (fChr.CharID == 1)
							line = line + " " + getIDfromRole[fChr.CharValue];
						else
							line = line + " " + fChr.CharValue;
					}
					file.WriteLine(line);
				}
			}
		}

		public Dictionary<string, string> getIDfromRole = new Dictionary<string, string>()
		{
				{ "Squad Leader", "0" },
				{ "Fire Team Leader", "1" },
				{ "Assistant Automatic Rifleman", "2" },
				{ "Automatic Rifleman", "3" },
				{ "Rifleman", "4" },
				{ "Medical Corpsman", "5" }
		};
	}
}
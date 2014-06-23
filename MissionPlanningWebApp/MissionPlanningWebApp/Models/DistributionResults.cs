using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MissionPlanningWebApp.Models
{
    public class DistributionResults
    {

		public Dictionary<string, string> getIDfromRole = new Dictionary<string, string>()
		{
				{ "Squad Leader", "0" },
				{ "Fire Team Leader", "1" },
				{ "Assistant Automatic Rifleman", "2" },
				{ "Automatic Rifleman", "3" },
				{ "Rifleman", "4" },
				{ "Medical Corpsman", "5" }
		};

		public Dictionary<string, string> getRolefromID = new Dictionary<string, string>()
		{
				{ "0", "Squad Leader" },
				{ "1", "Fire Team Leader" },
				{ "2", "Assistant Automatic Rifleman" },
				{ "3", "Automatic Rifleman" },
				{ "4", "Rifleman" },
				{ "5", "Medical Corpsman" }
		};

		public int ID { get; set; }
        public virtual ICollection<WarfighterDistribution> Results { get; set; }

        public DistributionResults()
        {
            Results = new List<WarfighterDistribution>();
        }

        public void GetDistributionResults(List<DistributionRules> distributionRules, List<Warfighter> fighters, string path)
        {
            WriteDistributionRulesToFile(distributionRules, string.Concat(path, "Rules_Distribution.txt"));
            WriteFightersToFile(fighters, string.Concat(path, "Warfighter_Members.txt"));

			// call exe on server
			Process kProcess = new Process();

			// set up folder and EXE file
			kProcess.StartInfo.WorkingDirectory = path;
			kProcess.StartInfo.FileName = path + "equipment_distribution.exe";

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

			// TO DO: Check for error file here

            using (StreamReader file = new StreamReader(string.Concat(path, "Equipment_Distribution.txt")))
            {
                Results = new List<WarfighterDistribution>();

                WarfighterDistribution WarfighterDistribution = new WarfighterDistribution();
                WarfighterDistribution.Distributions = new List<EquipmentDistribution>();

                EquipmentDistribution equipDistribution;

                string line = null;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("Warfighter"))
                    {
                        string key = Regex.Match(line, @"^.*\[(.*)\].*$").Groups[1].Value;

                        int WarfighterID;
                        if (!int.TryParse(key, out WarfighterID))
                        {
                            Console.Write("ERROR - could not parse Equipment_Distribution.txt");
                            return;
                        }

                        WarfighterDistribution = new WarfighterDistribution();
                        WarfighterDistribution.WarfighterID = WarfighterID + 1;
                        WarfighterDistribution.Distributions = new List<EquipmentDistribution>();

                        Results.Add(WarfighterDistribution);
                    }
                    if (line.StartsWith("\tEquipment"))
                    {
                        string key = Regex.Match(line, @"^.*\[(.*)\].*$").Groups[1].Value;
                        string val = Regex.Match(line, @"^.*= (.*)$").Groups[1].Value;

                        int equipId = 0, equipVal = 0;

                        if (!int.TryParse(key, out equipId) || !int.TryParse(val, out equipVal))
                        {
                            Console.WriteLine("ERROR - could not parse Equipment_Distribution.txt");
                            return;
                        }

                        equipDistribution = new EquipmentDistribution();
                        equipDistribution.EquipID = equipId + 1;
                        equipDistribution.Distribution = equipVal;

						if (equipVal != 0)
							WarfighterDistribution.Distributions.Add(equipDistribution);
                    }
                }
            }

			File.Delete(path + "Equipment_Distribution.txt");
        }

        public void WriteDistributionRulesToFile(List<DistributionRules> distributionRules, string path)
        {
            using (StreamWriter file = new StreamWriter(path))
            {
                foreach (DistributionRules d in distributionRules)
                {
                    string chrCond = ParseLogicalSigns(d.ChrCond);
                    string constrCond = ParseLogicalSigns(d.ConstrCond);

					string charVal = "";
					if (d.ChrId == 1)
						charVal = getIDfromRole[d.ChrData];
					else
						charVal = d.ChrData;

                    string line = string.Format("{0} {1} {2} {3} {4} {5}",
                        d.ChrId - 1, chrCond, charVal, d.EquipId - 1, constrCond, d.ConstrRHS);
                    file.WriteLine(line);
                }
            }
        }

        private string ParseLogicalSigns(string inputString)
        {
            string returnVal;

            switch(inputString)
            {
                case "<":
                    returnVal = "L";
                    break;
                case ">":
                    returnVal = "G";
                    break;
                case "=":
                    returnVal = "E";
                    break;
                default:
                    returnVal = inputString;
                    break;
            }

            return returnVal;
        }

        public void WriteFightersToFile(List<Warfighter> warfighters, string path) // TODO FighterCharacteristics must be in correct order to write to database
        {
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
    }

    public class WarfighterDistribution
    {
        public int ID { get; set; }

        [ForeignKey("Warfighter")]
        public int WarfighterID { get; set; }
        public virtual Warfighter Warfighter { get; set; }

		public double TotalWeight { get; set; }

        public virtual ICollection<EquipmentDistribution> Distributions { get; set; }
    }

    public class EquipmentDistribution
    {
        public int ID { get; set; }
        public float Distribution { get; set; }

        [ForeignKey("Equipment")]
        public int EquipID { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}

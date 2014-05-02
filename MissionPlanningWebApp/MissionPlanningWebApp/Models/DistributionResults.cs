using System;
using System.Collections.Generic;
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
            //CALL SERVER

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

                        if (equipVal != 0) WarfighterDistribution.Distributions.Add(equipDistribution);
                    }
                }
            }
        }

        public void WriteDistributionRulesToFile(List<DistributionRules> distributionRules, string path)
        {
            using (StreamWriter file = new StreamWriter(path))
            {
                foreach (DistributionRules d in distributionRules)
                {
                    string chrCond = ParseLogicalSigns(d.ChrCond);
                    string constrCond = ParseLogicalSigns(d.ConstrCond);

                    string line = string.Format("{0} {1} {2} {3} {4} {5}",
                        d.ChrId, chrCond, d.ChrData, d.EquipId, constrCond, d.ConstrRHS);
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
			int numChars = warfighters.Count;
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
					string line = f.ID.ToString();
					foreach (WarfighterCharacteristic fChr in f.WarfighterCharacteristics)
					{
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

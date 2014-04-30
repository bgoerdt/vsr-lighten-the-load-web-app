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
        public virtual ICollection<FighterDistribution> Results { get; set; }

        public DistributionResults()
        {
            Results = new List<FighterDistribution>();
        }

        public void GetDistributionResults(List<DistributionRules> distributionRules, List<Fighter> fighters, string path)
        {
            WriteDistributionRulesToFile(distributionRules, string.Concat(path, "Rules_Distribution.txt"));
            WriteFightersToFile(fighters, string.Concat(path, "Warfighter_Members.txt"));
            //CALL SERVER

            using (StreamReader file = new StreamReader(string.Concat(path, "Equipment_Distribution.txt")))
            {
                Results = new List<FighterDistribution>();

                FighterDistribution fighterDistribution = new FighterDistribution();
                fighterDistribution.Distributions = new List<EquipmentDistribution>();

                EquipmentDistribution equipDistribution;

                string line = null;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("Warfighter"))
                    {
                        string key = Regex.Match(line, @"^.*\[(.*)\].*$").Groups[1].Value;

                        int fighterID;
                        if (!int.TryParse(key, out fighterID))
                        {
                            Console.Write("ERROR - could not parse Equipment_Distribution.txt");
                            return;
                        }

                        fighterDistribution = new FighterDistribution();
                        fighterDistribution.FighterID = fighterID + 1;
                        fighterDistribution.Distributions = new List<EquipmentDistribution>();

                        Results.Add(fighterDistribution);
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

                        if (equipVal != 0) fighterDistribution.Distributions.Add(equipDistribution);
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

        public void WriteFightersToFile(List<Fighter> fighters, string path) // TODO FighterCharacteristics must be in correct order to write to database
        {
            using (StreamWriter file = new StreamWriter(path))
            {
                foreach (Fighter f in fighters)
                {
                    string line = f.ID.ToString();
                    foreach (FighterCharacteristic fChr in f.FighterCharacteristics)
                    {
                        line = line + " " + fChr.CharValue;
                    }
                    file.WriteLine(line);
                }
            }
        }
    }

    public class FighterDistribution
    {
        public int ID { get; set; }

        [ForeignKey("Fighter")]
        public int FighterID { get; set; }
        public virtual Fighter Fighter { get; set; }

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

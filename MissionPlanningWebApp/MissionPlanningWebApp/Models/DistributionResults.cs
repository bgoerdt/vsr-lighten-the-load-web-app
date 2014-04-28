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

            //CALL EXE ON SERVER
			Process kProcess = new Process();

			// set up folder and EXE file
			kProcess.StartInfo.WorkingDirectory = path;
			kProcess.StartInfo.FileName = path + "equipment_distribution.exe";

			// comment in to hide window
			//kProcess.StartInfo.CreateNoWindow = true;
			//kProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

			// start the EXE
			kProcess.Start();

			// wait for the EXE to finish
			while (kProcess.HasExited == false)
			{
				System.Threading.Thread.Sleep(100);
			}

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
                    string line = string.Format("{0} {1} {2} {3} {4} {5}",
                        d.ChrId - 1, d.ChrCond, d.ChrData, d.EquipId - 1, d.ConstrCond, d.ConstrRHS);
                    file.WriteLine("{0} {1} {2} {3} {4} {5}",
                        d.ChrId - 1, d.ChrCond, d.ChrData, d.EquipId - 1, d.ConstrCond, d.ConstrRHS);
                }
            }
        }

        public void WriteFightersToFile(List<Fighter> fighters, string path) // TODO FighterCharacteristics must be in correct order to write to database
        {
            using (StreamWriter file = new StreamWriter(path))
            {
                foreach (Fighter f in fighters)
                {
                    string line = (f.ID-1).ToString();
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

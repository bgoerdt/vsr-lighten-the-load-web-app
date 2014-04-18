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

        public void GetDistributionResults()
        {
            using (StreamReader file = new StreamReader(@"C:\Users\Melanie\Documents\Equipment_Distribution.txt"))
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

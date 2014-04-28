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

        public void GetDistributionResults()
        {
            using (StreamReader file = new StreamReader(@"C:\Users\Melanie\Documents\Equipment_Distribution.txt"))
            {
                Results = new List<WarfighterDistribution>();

                WarfighterDistribution WarfighterDistribution = new WarfighterDistribution();
                WarfighterDistribution.Distributions = new List<EquipmentDistribution>();

                EquipmentDistribution equipDistribution;

                string line = null;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("WarWarfighter"))
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

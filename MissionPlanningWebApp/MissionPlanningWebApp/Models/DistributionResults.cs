using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text.RegularExpressions;

namespace MissionPlanningWebApp.Models
{
    public class DistributionResults
    {
        public int ID { get; set; }
        public virtual IDictionary<int, ICollection<Tuple<int, float>>> results { get; set; }

        public void GetDistributionResults()
        {
            using (StreamReader file = new StreamReader(@"C:\Users\Melanie\Documents\Equipment_Distribution.txt"))
            {
                int currentKey = 0;
                results = new Dictionary<int, ICollection<Tuple<int, float>>>();

                string line = null;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("Warfighter"))
                    {
                        string key = Regex.Match(line, @"^.*\[(.*)\].*$").Groups[1].Value;

                        if (!int.TryParse(key, out currentKey)) 
                        {
                            Console.Write("ERROR - could not parse Equipment_Distribution.txt");
                            return;
                        }

                        results[currentKey] = new List<Tuple<int, float>>();
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

                        if (equipVal != 0) results[currentKey].Add(new Tuple<int, float>(equipId, equipVal));
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MissionPlanningWebApp.Data
{
    public class FileIOHelper
    {
        // TODO add local string to Config file and read from there
        private static string local = "C:\\Users\\Melanie\\Documents\\vsr-lighten-the-load-web-app\\MissionPlanningWebApp\\MissionPlanningWebApp\\";

        public static List<string[]> ReadDataFile(string filename) 
        {
            List<string[]> returnVal = new List<string[]>();

            // read input file
            StreamReader reader = new StreamReader(local + filename);

            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                string[] vals;
                if (!line.StartsWith("#")) // ignore comment lines
                {
                    // remove unwanted white space
                    vals = line.Split(' ');
                    vals = vals.Where(s => !s.Equals(string.Empty)).ToArray();

                    returnVal.Add(vals); // add to list
                }
            }

            reader.Close();
            return returnVal;
        }
    }
}
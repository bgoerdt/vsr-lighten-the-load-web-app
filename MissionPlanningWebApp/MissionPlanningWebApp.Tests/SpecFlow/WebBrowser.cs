using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace MissionPlanningWebApp.Tests.SpecFlow
{
    public static class WebBrowser
    {
        private static Process process = new Process();

        private static string port = "63369";
        private static string iisExpressFile = @"C:\Program Files\IIS Express\iisexpress.exe";
        private static string configFile = Environment.CurrentDirectory.Replace(@".Tests\bin\Debug", "Web.config");

        public static IE Current
        {
            get
            {
                string key = "browser";

                if (!ScenarioContext.Current.ContainsKey(key))
                {
                    ScenarioContext.Current[key] = new IE();
                }

                return ScenarioContext.Current[key] as IE;
            }
        }

        public static string localhost = "http://localhost:63369/";

        public static void Setup()
        {
            process = new Process(); // iisExpress process

            // initialize properties
            process.StartInfo.FileName = iisExpressFile;
            process.StartInfo.Arguments = String.Format("/port:{0} /config:{1}", port, configFile);
            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;

            // start the process
            process.Start();
        }

        public static void Cleanup()
        {
            process.Close();
            
            WebBrowser.Current.Close();
            WebBrowser.Current.Dispose();
        }
    }
}

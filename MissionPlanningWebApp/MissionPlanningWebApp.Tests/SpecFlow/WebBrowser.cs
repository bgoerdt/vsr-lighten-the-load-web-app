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

        public static void Setup()
        {
            // create a new process to start
            // the ASP.Net Development Server

            Process p = new Process();

            // set the initial properties 

            //string path = Environment.CurrentDirectory.Replace(@"WebAppUITesting\bin", string.Empty);
            //string path = Environment.CurrentDirectory.Replace(@".Tests\bin", @"Web.config");
            string path = Environment.CurrentDirectory.Replace(@".Tests\bin", string.Empty);
            path = path.Replace(@"\Debug", string.Empty);
            p.StartInfo.FileName = @"C:\Program Files\IIS Express\iisexpress.exe";
            p.StartInfo.Arguments =
                   String.Format("/port:63369 /path:{0}", path);
            p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;

            // start the process

            p.Start();
        }

        public static void Cleanup()
        {
            WebBrowser.Current.Close();
            WebBrowser.Current.Dispose();
        }
    }
}

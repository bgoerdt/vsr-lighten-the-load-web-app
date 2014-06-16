using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using MissionPlanningWebApp.Models;

namespace MissionPlanningWebApp.Controllers
{
    public class MissionPlanController : Controller
    {
        private LtLDbContext db = new LtLDbContext();
        private MissionPlan plan = new MissionPlan();
        //
        // GET: /MissionPlan/

        public ActionResult Index()
        {
            plan.planMission(HttpContext.Server.MapPath("~/Mission Data/"), db.Equipment.ToList(), db.MissionParameters.ToList(), db.MissionRules.ToList());
			new LogEvent(HttpContext.Server.MapPath("~/Mission Data/")).Raise();
            return View(plan);
        }

		public class LogEvent : WebRequestErrorEvent
		{
			public LogEvent(string message)
				: base(null, null, 100001, new Exception(message))
			{
			}
		}

    }
}

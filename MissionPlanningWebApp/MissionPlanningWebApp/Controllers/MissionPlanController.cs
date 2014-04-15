using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MissionPlanningWebApp.Models;

namespace MissionPlanningWebApp.Controllers
{
    public class MissionPlanController : Controller
    {
        //
        // GET: /MissionPlan/

        public ActionResult Index(MissionPlan plan)
        {
            return View(plan);
        }

		[HttpPost]
		public ActionResult Create()
		{
			MissionPlan plan = new MissionPlan();
			plan.planMission();

			return RedirectToAction("Index", plan);
		}

    }
}

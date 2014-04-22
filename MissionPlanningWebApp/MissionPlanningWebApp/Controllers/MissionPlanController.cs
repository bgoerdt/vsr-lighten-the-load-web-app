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

        private MissionPlan plan = new MissionPlan();
        //
        // GET: /MissionPlan/

        public ActionResult Index()
        {
            plan.planMission(HttpContext.Server.MapPath("~/Mission Data/"));
            return View(plan);
        }

		[HttpGet]
		public ActionResult Create()
		{
			//MissionPlan plan = new MissionPlan();
			//plan.planMission(HttpContext.Server.MapPath("~/Mission Data/"));

			return RedirectToAction("Index");
		}

    }
}

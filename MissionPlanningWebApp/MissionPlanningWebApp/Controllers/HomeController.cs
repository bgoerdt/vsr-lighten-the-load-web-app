using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MissionPlanningWebApp.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Mission Planning Application";

			return View("Index");
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your app description page.";

			return View("About");
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View("Contact");
		}
	}
}

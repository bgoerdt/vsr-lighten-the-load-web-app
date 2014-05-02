using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MissionPlanningWebApp.Models;
using System.Net;
using System.Web.Routing;
using System.IO;

namespace MissionPlanningWebApp.Controllers
{
    public class DistributionResultsController : Controller
    {
        private LtLDbContext db = new LtLDbContext();

        //
        // GET: /DistributionResults/

        public ActionResult Index()
        {
            DistributionResults model = TempData["model"] as DistributionResults;
            return View(model);
        }

        public ActionResult Distribute()
        {
            DistributionResults results = new DistributionResults();
            results.GetDistributionResults(db.DistributionRules.ToList(), db.Fighters.ToList(),
                HttpContext.Server.MapPath("~/Mission Data/"));

            foreach (WarfighterDistribution fDist in results.Results)
            {
                int fId = fDist.WarfighterID;
                Warfighter fighter = db.Warfighters.ToList().Where(f => f.ID == fId).Single();
                if (fighter == null)
                {
                    return HttpNotFound();
                }
                fDist.Warfighter = fighter;

                foreach (EquipmentDistribution eDist in fDist.Distributions)
                {
                    int eId = eDist.EquipID;
                    Equipment equip = db.Equipment.ToList().Where(e => e.ID == eId).Single();
                    if (equip == null)
                    {
                        return HttpNotFound();
                    }
                    eDist.Equipment = equip;
                }
            }

            TempData["model"] = results;
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MissionPlanningWebApp.Models;
using System.IO;

namespace MissionPlanningWebApp.Controllers
{
    public class MissionRuleController : Controller
    {
        private LtLDbContext db = new LtLDbContext();

        //
        // GET: /MissionRule/

        public ActionResult Index()
        {
			ExportMissionRules();
            var missionrules = db.MissionRules.Include(m => m.Param).Include(m => m.Equip);
            return View(missionrules.ToList());
        }

        //
        // GET: /MissionRule/Details/5

        public ActionResult Details(int id = 0)
        {
            MissionRule missionrule = db.MissionRules.Find(id);
            if (missionrule == null)
            {
                return HttpNotFound();
            }
            return View(missionrule);
        }

        //
        // GET: /MissionRule/Create

        public ActionResult Create()
        {
            ViewBag.ParamId = new SelectList(db.MissionParameters, "ID", "Name");
            ViewBag.EquipId = new SelectList(db.Equipment, "ID", "Name");
            return View();
        }

        //
        // POST: /MissionRule/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MissionRule missionrule)
        {
            if (ModelState.IsValid)
            {
                db.MissionRules.Add(missionrule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParamId = new SelectList(db.MissionParameters, "ID", "Name", missionrule.ParamId);
            ViewBag.EquipId = new SelectList(db.Equipment, "ID", "Name", missionrule.EquipId);
            return View(missionrule);
        }

        //
        // GET: /MissionRule/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MissionRule missionrule = db.MissionRules.Find(id);
            if (missionrule == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParamId = new SelectList(db.MissionParameters, "ID", "Name", missionrule.ParamId);
            ViewBag.EquipId = new SelectList(db.Equipment, "ID", "Name", missionrule.EquipId);
            return View(missionrule);
        }

        //
        // POST: /MissionRule/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MissionRule missionrule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missionrule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParamId = new SelectList(db.MissionParameters, "ID", "Name", missionrule.ParamId);
            ViewBag.EquipId = new SelectList(db.Equipment, "ID", "Name", missionrule.EquipId);
            return View(missionrule);
        }

        //
        // GET: /MissionRule/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MissionRule missionrule = db.MissionRules.Find(id);
            if (missionrule == null)
            {
                return HttpNotFound();
            }
            return View(missionrule);
        }

        //
        // POST: /MissionRule/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MissionRule missionrule = db.MissionRules.Find(id);
            db.MissionRules.Remove(missionrule);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

		private void ExportMissionRules()
		{
			string path = HttpContext.Server.MapPath("~/App_Data/Rules_Mission.txt");
			StreamWriter writer = new StreamWriter(path);
			var missionRules = db.MissionRules.ToList();
			foreach (var rule in missionRules)
			{
				Dictionary<string, string> conditions = new Dictionary<string,string>()
				{
					{ "<", "L" },
					{ "=", "E" },
					{ ">", "G" }
				};

				string ruleCond = conditions[rule.RuleCond];
				string constrCond = conditions[rule.ConstrCond];

				writer.WriteLine((rule.ParamId-1) + "\t" + ruleCond + "\t" + rule.RuleData + "\t" + (rule.EquipId-1) + "\t"  + constrCond + "\t" + rule.ConstrRHS);
			}

			writer.Close();
		}
    }
}
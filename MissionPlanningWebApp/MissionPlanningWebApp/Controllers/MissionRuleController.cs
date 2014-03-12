using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MissionPlanningWebApp.Models;

namespace MissionPlanningWebApp.Controllers
{
    public class MissionRuleController : Controller
    {
        private MissionRuleDbContext db = new MissionRuleDbContext();

        //
        // GET: /MissionRule/

        public ActionResult Index()
        {
            return View(db.MissionRules.ToList());
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
    }
}
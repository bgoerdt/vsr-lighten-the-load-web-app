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
    public class MissionParameterController : Controller
    {
        private MissionParameterDbContext db = new MissionParameterDbContext();

        //
        // GET: /MissionParameter/

        public ActionResult Index()
        {
            return View(db.MissionParameters.ToList());
        }

        //
        // GET: /MissionParameter/Details/5

        public ActionResult Details(int id = 0)
        {
            MissionParameter missionparameter = db.MissionParameters.Find(id);
            if (missionparameter == null)
            {
                return HttpNotFound();
            }
            return View(missionparameter);
        }

        //
        // GET: /MissionParameter/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MissionParameter/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MissionParameter missionparameter)
        {
            if (ModelState.IsValid)
            {
                db.MissionParameters.Add(missionparameter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(missionparameter);
        }

        //
        // GET: /MissionParameter/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MissionParameter missionparameter = db.MissionParameters.Find(id);
            if (missionparameter == null)
            {
                return HttpNotFound();
            }
            return View(missionparameter);
        }

        //
        // POST: /MissionParameter/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MissionParameter missionparameter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missionparameter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(missionparameter);
        }

        //
        // GET: /MissionParameter/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MissionParameter missionparameter = db.MissionParameters.Find(id);
            if (missionparameter == null)
            {
                return HttpNotFound();
            }
            return View(missionparameter);
        }

        //
        // POST: /MissionParameter/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MissionParameter missionparameter = db.MissionParameters.Find(id);
            db.MissionParameters.Remove(missionparameter);
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
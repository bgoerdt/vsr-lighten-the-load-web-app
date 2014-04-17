using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MissionPlanningWebApp.Models;

namespace MissionPlanningWebApp.Controllers
{
    public class MissionParameterController : Controller
    {
        private LtLDbContext db = new LtLDbContext();

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
                WriteToFile();
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
        // POST: /MissionParameter/Edit/IsSelected

        public class CheckedInfo
        {
            public int ID { get; set; }
            public bool ck { get; set; }
        }

        [HttpPost]
        public ContentResult UpdateChecked(CheckedInfo info)//, bool Selected)
        {
            Fighter fighter = db.Fighters.Find(info.ID);
            fighter.IsSelected = info.ck;
            if (ModelState.IsValid)
            {
                db.Entry(fighter).State = EntityState.Modified;
                db.SaveChanges();
            }

            return new ContentResult { Content = "success" };
        }

        //
        // GET: /MissionParameter/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Fighter fighter = db.Fighters.Find(id);
            if (fighter == null)
            {
                return HttpNotFound();
            }
            return View(fighter);
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

        public void WriteToFile()
        {
            List<MissionParameter> missionParameters = db.MissionParameters.ToList();

            using (StreamWriter file = new StreamWriter(HttpContext.Server.MapPath("~/App_Data/MissionParameter.txt")))
            {
                string totalNumberParameters = missionParameters.Count.ToString();
                file.WriteLine("#number of mission parameters");
                file.WriteLine(totalNumberParameters);
                foreach (MissionParameter d in missionParameters)
                {
                   
                    string line = string.Format("{0} {1} {2} {3}",
                        d.ID, d.Name, d.Value, d.IsSelected);
                    file.WriteLine("#{0}", d.Name);
                    file.WriteLine("{0}\t{1}",
                       ( d.ID-1), d.Value);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
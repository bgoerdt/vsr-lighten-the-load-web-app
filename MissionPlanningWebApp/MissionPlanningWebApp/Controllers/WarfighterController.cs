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
    public class WarfighterController : Controller
    {
        private LtLDbContext db = new LtLDbContext();

        //
        // GET: /Warfighter/

        public ActionResult Index()
        {
            var characteristics = db.Characteristics.ToList();
            ViewData["characteristics"] = characteristics;

            return View(db.Warfighters.ToList());
        }

        //
        // GET: /Warfighter/Details/5

        public ActionResult Details(int id = 0)
        {
            Warfighter Warfighter = db.Warfighters.Find(id);
            if (Warfighter == null)
            {
                return HttpNotFound();
            }
            return View(Warfighter);
        }

        //
        // GET: /Warfighter/Create

        public ActionResult Create()
        {
            var WarfighterCharacteristics = new List<WarfighterCharacteristic>();
            foreach (Characteristic chr in db.Characteristics.ToList())
            {
                WarfighterCharacteristic fchr = new WarfighterCharacteristic();
                fchr.CharID = chr.ID;
                fchr.Characteristic = chr;
                fchr.CharValue = 0;

                WarfighterCharacteristics.Add(fchr);
            }

            ViewData["WarfighterCharacteristics"] = WarfighterCharacteristics;

            return View();
        }

        public class WarfighterData
        {
            public string name { get; set; }
            public string chars { get; set; }
        }

        //
        // POST: /Warfighter/Create
        [HttpPost]
        public ContentResult ManualCreate(WarfighterData data)
        {
            Warfighter Warfighter = new Warfighter();
            if (ModelState.IsValid)
            {
                Warfighter.Name = data.name;
                db.Warfighters.Add(Warfighter);

                char[] delims = { ',' };
                string[] charVals = data.chars.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                var chars = db.Characteristics.ToList();
                int i = 0;
                foreach (Characteristic characteristic in chars)
                {
                    db.WarfighterCharacteristics.Add(new WarfighterCharacteristic(Warfighter.ID, characteristic.ID, (float)Convert.ToDouble(charVals[i])));
                    i++;
                }
                db.SaveChanges();
            }

            return new ContentResult { Content = "success" };
        }

        //
        // GET: /Warfighter/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Warfighter Warfighter = db.Warfighters.Find(id);
            if (Warfighter == null)
            {
                return HttpNotFound();
            }
            return View(Warfighter);
        }

        //
        // POST: /Warfighter/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Warfighter Warfighter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Warfighter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Warfighter);
        }

        //
        // GET: /Warfighter/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Warfighter Warfighter = db.Warfighters.Find(id);
            if (Warfighter == null)
            {
                return HttpNotFound();
            }
            return View(Warfighter);
        }

        //
        // POST: /Warfighter/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Warfighter Warfighter = db.Warfighters.Find(id);
            db.Warfighters.Remove(Warfighter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public class CheckedInfo
        {
            public int ID { get; set; }
            public bool ck { get; set; }
        }

        [HttpPost]
        public ContentResult UpdateChecked(CheckedInfo info)//, bool Selected)
        {
            MissionParameter missionparameter = db.MissionParameters.Find(info.ID);
            missionparameter.IsSelected = info.ck;
            if (ModelState.IsValid)
            {
                db.Entry(missionparameter).State = EntityState.Modified;
                db.SaveChanges();
            }

            return new ContentResult { Content = "success" };
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public void WriteToFile() // TODO WarfighterCharacteristics must be in correct order to write to database
        {
            List<Warfighter> Warfighters = db.Warfighters.ToList();

            using (StreamWriter file = new StreamWriter(@"C:\Users\Melanie\Documents\Rules_Distribution.txt"))
            {
                foreach (Warfighter f in Warfighters)
                {
                    string line = f.ID.ToString();
                    foreach (WarfighterCharacteristic fChr in f.WarfighterCharacteristics)
                    {
                        line = line + " " + fChr.CharValue;
                    }
                    file.WriteLine(line);
                }
            }
        }

    }
}

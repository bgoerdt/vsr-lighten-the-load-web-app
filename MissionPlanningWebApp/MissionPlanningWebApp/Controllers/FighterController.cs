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
    public class FighterController : Controller
    {
        private LtLDbContext db = new LtLDbContext();

        //
        // GET: /Fighter/

        public ActionResult Index()
        {
            var characteristics = db.Characteristics.ToList();
            ViewData["characteristics"] = characteristics;

            return View(db.Fighters.ToList());
        }

        //
        // GET: /Fighter/Details/5

        public ActionResult Details(int id = 0)
        {
            Fighter fighter = db.Fighters.Find(id);
            if (fighter == null)
            {
                return HttpNotFound();
            }
            return View(fighter);
        }

        //
        // GET: /Fighter/Create

        public ActionResult Create()
        {
            var fighterCharacteristics = new List<FighterCharacteristic>();
            foreach(Characteristic chr in db.Characteristics.ToList()) {
                FighterCharacteristic fchr = new FighterCharacteristic();
                fchr.CharID = chr.ID;
                fchr.Characteristic = chr;
                fchr.CharValue = 0;

                fighterCharacteristics.Add(fchr);
            }

            ViewData["fighterCharacteristics"] = fighterCharacteristics;

            return View();
        }

		public class FighterData
		{
			public string name { get; set; }
			public string chars { get; set; }
		}

		//
		// POST: /Fighter/Create
		[HttpPost]
		public ContentResult ManualCreate(FighterData data)
		{
			Fighter fighter = new Fighter();
			if (ModelState.IsValid)
			{
				fighter.Name = data.name;
				db.Fighters.Add(fighter);

				char[] delims = { ',' };
				string[] charVals = data.chars.Split(delims,StringSplitOptions.RemoveEmptyEntries);
				var chars = db.Characteristics.ToList();
				int i = 0;
				foreach (Characteristic characteristic in chars)
				{
					db.FighterCharacteristics.Add(new FighterCharacteristic(fighter.ID, characteristic.ID, (float)Convert.ToDouble(charVals[i])));
					i++;
				}
				db.SaveChanges();
			}

			return new ContentResult { Content = "success"};
		}

        /*//
        // POST: /Fighter/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fighter fighter)
        {
            if (ModelState.IsValid)
            {
                db.Fighters.Add(fighter);
                db.SaveChanges();

                // create fighter characteristics
                fighter.FighterCharacteristics = new List<FighterCharacteristic>();
                db.Entry(fighter).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(fighter);
        }*/

        //
        // GET: /Fighter/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Fighter fighter = db.Fighters.Find(id);
            if (fighter == null)
            {
                return HttpNotFound();
            }
            return View(fighter);
        }

        //
        // POST: /Fighter/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fighter fighter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fighter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fighter);
        }

        //
        // GET: /Fighter/Delete/5

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
        // POST: /Fighter/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fighter fighter = db.Fighters.Find(id);
            db.Fighters.Remove(fighter);
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
    }
}
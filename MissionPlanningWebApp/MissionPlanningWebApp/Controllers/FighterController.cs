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

		/*private class FighterData
		{
			public int id;
			public string name;
			public ICollection<Tuple<int, int, int>> characteristics;
		}*/

		//
		// POST: /Fighter/Create
		[HttpPost]
		public ActionResult Create(string name, float char1, float char2, float char3, float char4)
		{
			if (ModelState.IsValid)
			{
				Fighter fighter = new Fighter();
				fighter.Name = name;
				db.Fighters.Add(fighter);
				db.SaveChanges();

				var chars = db.Characteristics.ToList();
				db.FighterCharacteristics.Add(new FighterCharacteristic(fighter.ID, chars[0].ID, char1));
				db.FighterCharacteristics.Add(new FighterCharacteristic(fighter.ID, chars[1].ID, char2));
				db.FighterCharacteristics.Add(new FighterCharacteristic(fighter.ID, chars[2].ID, char3));
				db.FighterCharacteristics.Add(new FighterCharacteristic(fighter.ID, chars[3].ID, char4));
				db.SaveChanges();
			}

			return View("Index","Fighter");
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
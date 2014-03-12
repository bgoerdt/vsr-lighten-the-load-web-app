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
    public class FightersController : Controller
    {
        private FighterDBContext db = new FighterDBContext();

        //
        // GET: /Fighters/

        public ActionResult Index()
        {
            return View(db.Fighter.ToList());
        }

        //
        // GET: /Fighters/Details/5

        public ActionResult Details(int id = 0)
        {
            Fighter fighter = db.Fighter.Find(id);
            if (fighter == null)
            {
                return HttpNotFound();
            }
            return View(fighter);
        }

        //
        // GET: /Fighters/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Fighters/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fighter fighter)
        {
            if (ModelState.IsValid)
            {
                db.Fighter.Add(fighter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fighter);
        }

        //
        // GET: /Fighters/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Fighter fighter = db.Fighter.Find(id);
            if (fighter == null)
            {
                return HttpNotFound();
            }
            return View(fighter);
        }

        //
        // POST: /Fighters/Edit/5

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
        // GET: /Fighters/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Fighter fighter = db.Fighter.Find(id);
            if (fighter == null)
            {
                return HttpNotFound();
            }
            return View(fighter);
        }

        //
        // POST: /Fighters/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fighter fighter = db.Fighter.Find(id);
            db.Fighter.Remove(fighter);
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
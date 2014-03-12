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
        private FighterDBContext db = new FighterDBContext();

        //
        // GET: /Fighter/

        public ActionResult Index()
        {
            return View(db.Fighter.ToList());
        }

        //
        // GET: /Fighter/Details/5

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
        // GET: /Fighter/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Fighter/Create

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
        // GET: /Fighter/Edit/5

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
            Fighter fighter = db.Fighter.Find(id);
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
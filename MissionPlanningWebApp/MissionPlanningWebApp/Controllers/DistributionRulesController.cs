using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MissionPlanningWebApp.Models
{
    public class DistributionRulesController : Controller
    {
        private LtLDbContext db = new LtLDbContext();

        //
        // GET: /DistributionRules/

        public ActionResult Index()
        {
            var distributionrules = db.DistributionRules.Include(d => d.Chr).Include(d => d.Equip);
            return View(distributionrules.ToList());
        }

        //
        // GET: /DistributionRules/Details/5

        public ActionResult Details(int id = 0)
        {
            DistributionRules distributionrules = db.DistributionRules.Find(id);
            if (distributionrules == null)
            {
                return HttpNotFound();
            }
            return View(distributionrules);
        }

        //
        // GET: /DistributionRules/Create

        public ActionResult Create()
        {
            ViewBag.ChrId = new SelectList(db.Characteristics, "ID", "Char");
            ViewBag.EquipId = new SelectList(db.Equipment, "ID", "Name");
            return View();
        }

        //
        // POST: /DistributionRules/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DistributionRules distributionrules)
        {
            if (ModelState.IsValid)
            {
                db.DistributionRules.Add(distributionrules);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChrId = new SelectList(db.Characteristics, "ID", "Char", distributionrules.ChrId);
            ViewBag.EquipId = new SelectList(db.Equipment, "ID", "Name", distributionrules.EquipId);
            return View(distributionrules);
        }

        //
        // GET: /DistributionRules/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DistributionRules distributionrules = db.DistributionRules.Find(id);
            if (distributionrules == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChrId = new SelectList(db.Characteristics, "ID", "Char", distributionrules.ChrId);
            ViewBag.EquipId = new SelectList(db.Equipment, "ID", "Name", distributionrules.EquipId);
            return View(distributionrules);
        }

        //
        // POST: /DistributionRules/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DistributionRules distributionrules)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distributionrules).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChrId = new SelectList(db.Characteristics, "ID", "Char", distributionrules.ChrId);
            ViewBag.EquipId = new SelectList(db.Equipment, "ID", "Name", distributionrules.EquipId);
            return View(distributionrules);
        }

        //
        // GET: /DistributionRules/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DistributionRules distributionrules = db.DistributionRules.Find(id);
            if (distributionrules == null)
            {
                return HttpNotFound();
            }
            return View(distributionrules);
        }

        //
        // POST: /DistributionRules/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DistributionRules distributionrules = db.DistributionRules.Find(id);
            db.DistributionRules.Remove(distributionrules);
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
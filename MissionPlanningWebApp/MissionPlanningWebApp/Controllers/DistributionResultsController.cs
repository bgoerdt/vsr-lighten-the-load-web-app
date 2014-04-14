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
    public class DistributionResultsController : Controller
    {
        //private LtLDbContext db = new LtLDbContext();

        //
        // GET: /DistributionResults/

        public ActionResult Index()
        {
            return View(new DistributionResults());
        }

        ////
        //// GET: /DistributionResults/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    DistributionResults distributionresults = db.DistributionResults.Find(id);
        //    if (distributionresults == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(distributionresults);
        //}

        ////
        //// GET: /DistributionResults/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /DistributionResults/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(DistributionResults distributionresults)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.DistributionResults.Add(distributionresults);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(distributionresults);
        //}

        ////
        //// GET: /DistributionResults/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    DistributionResults distributionresults = db.DistributionResults.Find(id);
        //    if (distributionresults == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(distributionresults);
        //}

        ////
        //// POST: /DistributionResults/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(DistributionResults distributionresults)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(distributionresults).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(distributionresults);
        //}

        ////
        //// GET: /DistributionResults/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    DistributionResults distributionresults = db.DistributionResults.Find(id);
        //    if (distributionresults == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(distributionresults);
        //}

        ////
        //// POST: /DistributionResults/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    DistributionResults distributionresults = db.DistributionResults.Find(id);
        //    db.DistributionResults.Remove(distributionresults);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}

        public void Distribute()
        {
            DistributionResults model = new DistributionResults();
            model.GetDistributionResults();
        }
    }
}
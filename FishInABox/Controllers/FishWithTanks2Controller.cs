using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FishInABox.Models;

namespace FishInABox.Controllers
{
    public class FishWithTanks2Controller : Controller
    {
        private FishTestEntities db = new FishTestEntities();

        // GET: FishWithTanks2
        public ActionResult Index()
        {
            return View(db.FishWithTanks.ToList());
        }

        // GET: FishWithTanks2/Details/5
        public ActionResult Details(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FishWithTank fishWithTank = db.FishWithTanks.Find(id);
            if (fishWithTank == null)
            {
                return HttpNotFound();
            }
            return View(fishWithTank);
        }

        // GET: FishWithTanks2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FishWithTanks2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Species,Stock_On_Hand,Tank_Number,Location")] FishWithTank fishWithTank)
        {
            if (ModelState.IsValid)
            {
                db.FishWithTanks.Add(fishWithTank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fishWithTank);
        }

        // GET: FishWithTanks2/Edit/5
        public ActionResult Edit(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FishWithTank fishWithTank = db.FishWithTanks.Find(id);
            if (fishWithTank == null)
            {
                return HttpNotFound();
            }
            return View(fishWithTank);
        }

        // POST: FishWithTanks2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Species,Stock_On_Hand,Tank_Number,Location")] FishWithTank fishWithTank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fishWithTank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fishWithTank);
        }

        // GET: FishWithTanks2/Delete/5
        public ActionResult Delete(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FishWithTank fishWithTank = db.FishWithTanks.Find(id);
            if (fishWithTank == null)
            {
                return HttpNotFound();
            }
            return View(fishWithTank);
        }

        // POST: FishWithTanks2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(double id)
        {
            FishWithTank fishWithTank = db.FishWithTanks.Find(id);
            db.FishWithTanks.Remove(fishWithTank);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

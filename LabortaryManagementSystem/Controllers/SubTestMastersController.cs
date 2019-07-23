using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabortaryManagementSystem.Models;

namespace LabortaryManagementSystem.Controllers
{
    public class SubTestMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubTestMasters
        public ActionResult Index()
        {
            var subTestMasters = db.SubTestMasters.Include(s => s.TestMaster);
            return View(subTestMasters.ToList());
        }

        // GET: SubTestMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTestMaster subTestMaster = db.SubTestMasters.Find(id);
            if (subTestMaster == null)
            {
                return HttpNotFound();
            }
            return View(subTestMaster);
        }

        // GET: SubTestMasters/Create
        public ActionResult Create()
        {
            ViewBag.TestMasterId = new SelectList(db.TestMasters, "TestMasterId", "TestMasterName");
            return View();
        }

        // POST: SubTestMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubTestMasterId,TestMasterId,SubTestName")] SubTestMaster subTestMaster)
        {
            if (ModelState.IsValid)
            {
                db.SubTestMasters.Add(subTestMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TestMasterId = new SelectList(db.TestMasters, "TestMasterId", "TestMasterName", subTestMaster.TestMasterId);
            return View(subTestMaster);
        }

        // GET: SubTestMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTestMaster subTestMaster = db.SubTestMasters.Find(id);
            if (subTestMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.TestMasterId = new SelectList(db.TestMasters, "TestMasterId", "TestMasterName", subTestMaster.TestMasterId);
            return View(subTestMaster);
        }

        // POST: SubTestMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubTestMasterId,TestMasterId,SubTestName")] SubTestMaster subTestMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subTestMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TestMasterId = new SelectList(db.TestMasters, "TestMasterId", "TestMasterName", subTestMaster.TestMasterId);
            return View(subTestMaster);
        }

        // GET: SubTestMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTestMaster subTestMaster = db.SubTestMasters.Find(id);
            if (subTestMaster == null)
            {
                return HttpNotFound();
            }
            return View(subTestMaster);
        }

        // POST: SubTestMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubTestMaster subTestMaster = db.SubTestMasters.Find(id);
            db.SubTestMasters.Remove(subTestMaster);
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

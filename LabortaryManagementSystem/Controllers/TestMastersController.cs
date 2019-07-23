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
    public class TestMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestMasters
        public ActionResult Index()
        {
            return View(db.TestMasters.ToList());
        }

        // GET: TestMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestMaster testMaster = db.TestMasters.Find(id);
            if (testMaster == null)
            {
                return HttpNotFound();
            }
            return View(testMaster);
        }

        // GET: TestMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestMasterId,TestMasterName")] TestMaster testMaster)
        {
            if (ModelState.IsValid)
            {
                db.TestMasters.Add(testMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testMaster);
        }

        // GET: TestMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestMaster testMaster = db.TestMasters.Find(id);
            if (testMaster == null)
            {
                return HttpNotFound();
            }
            return View(testMaster);
        }

        // POST: TestMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestMasterId,TestMasterName")] TestMaster testMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testMaster);
        }

        // GET: TestMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestMaster testMaster = db.TestMasters.Find(id);
            if (testMaster == null)
            {
                return HttpNotFound();
            }
            return View(testMaster);
        }

        // POST: TestMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestMaster testMaster = db.TestMasters.Find(id);
            db.TestMasters.Remove(testMaster);
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

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
    public class TestOrderDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestOrderDetails
        public ActionResult Index()
        {
            var testOrderDetails = db.TestOrderDetails.Include(t => t.mainTest).Include(t => t.patientMaster).Include(t => t.subTestMaster).Include(t => t.testMaster);
            return View(testOrderDetails.ToList());
        }

        // GET: TestOrderDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestOrderDetail testOrderDetail = db.TestOrderDetails.Find(id);
            if (testOrderDetail == null)
            {
                return HttpNotFound();
            }
            return View(testOrderDetail);
        }

        // GET: TestOrderDetails/Create
        public ActionResult Create()
        {
            ViewBag.MainTestId = new SelectList(db.MainTests, "MainTestId", "MainTestName");
            ViewBag.PatientId = new SelectList(db.PatientMasters, "PatientId", "PatientName");
            ViewBag.SubTestMasterId = new SelectList(db.SubTestMasters, "SubTestMasterId", "SubTestName");
            ViewBag.TestMasterId = new SelectList(db.TestMasters, "TestMasterId", "TestMasterName");
            return View();
        }

        // POST: TestOrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DetailId,OrderId,PatientId,TestMasterId,SubTestMasterId,MainTestId,TechnologyId,PriceReceived,testValue,Status")] TestOrderDetail testOrderDetail)
        {
            if (ModelState.IsValid)
            {
                db.TestOrderDetails.Add(testOrderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MainTestId = new SelectList(db.MainTests, "MainTestId", "MainTestName", testOrderDetail.MainTestId);
            ViewBag.PatientId = new SelectList(db.PatientMasters, "PatientId", "PatientName", testOrderDetail.PatientId);
            ViewBag.SubTestMasterId = new SelectList(db.SubTestMasters, "SubTestMasterId", "SubTestName", testOrderDetail.SubTestMasterId);
            ViewBag.TestMasterId = new SelectList(db.TestMasters, "TestMasterId", "TestMasterName", testOrderDetail.TestMasterId);
            return View(testOrderDetail);
        }

        // GET: TestOrderDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestOrderDetail testOrderDetail = db.TestOrderDetails.Find(id);
            if (testOrderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.MainTestId = new SelectList(db.MainTests, "MainTestId", "MainTestName", testOrderDetail.MainTestId);
            ViewBag.PatientId = new SelectList(db.PatientMasters, "PatientId", "PatientName", testOrderDetail.PatientId);
            ViewBag.SubTestMasterId = new SelectList(db.SubTestMasters, "SubTestMasterId", "SubTestName", testOrderDetail.SubTestMasterId);
            ViewBag.TestMasterId = new SelectList(db.TestMasters, "TestMasterId", "TestMasterName", testOrderDetail.TestMasterId);
            return View(testOrderDetail);
        }

        // POST: TestOrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DetailId,OrderId,PatientId,TestMasterId,SubTestMasterId,MainTestId,TechnologyId,PriceReceived,testValue,Status")] TestOrderDetail testOrderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testOrderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MainTestId = new SelectList(db.MainTests, "MainTestId", "MainTestName", testOrderDetail.MainTestId);
            ViewBag.PatientId = new SelectList(db.PatientMasters, "PatientId", "PatientName", testOrderDetail.PatientId);
            ViewBag.SubTestMasterId = new SelectList(db.SubTestMasters, "SubTestMasterId", "SubTestName", testOrderDetail.SubTestMasterId);
            ViewBag.TestMasterId = new SelectList(db.TestMasters, "TestMasterId", "TestMasterName", testOrderDetail.TestMasterId);
            return View(testOrderDetail);
        }

        // GET: TestOrderDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestOrderDetail testOrderDetail = db.TestOrderDetails.Find(id);
            if (testOrderDetail == null)
            {
                return HttpNotFound();
            }
            return View(testOrderDetail);
        }

        // POST: TestOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestOrderDetail testOrderDetail = db.TestOrderDetails.Find(id);
            db.TestOrderDetails.Remove(testOrderDetail);
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

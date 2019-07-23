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
    public class TestOrderMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestOrderMasters
        public ActionResult Index()
        {
            var testOrderMasters = db.TestOrderMasters.Include(t => t.PatientMaster);
            return View(testOrderMasters.ToList());
        }

        // GET: TestOrderMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestOrderMaster testOrderMaster = db.TestOrderMasters.Find(id);
            if (testOrderMaster == null)
            {
                return HttpNotFound();
            }
            return View(testOrderMaster);
        }

        // GET: TestOrderMasters/Create
        public ActionResult Create()
        {
            TestOrderMaster testOrderMaster = new TestOrderMaster();
            var abc = db.TestOrderMasters.Max(x => x.OrderNo);
            if (abc == null)
            {
                testOrderMaster.OrderNo = 1;
            }
            else
            {
                testOrderMaster.OrderNo = abc + 1;
            }

            ViewBag.Order = testOrderMaster.OrderNo;
            ViewBag.PatientId = new SelectList(db.PatientMasters, "PatientId", "PatientName");
            ViewBag.TestMaster = new SelectList(db.TestMasters, "TestMasterId", "TestMasterName");
            ViewBag.SubTestMaster = new SelectList(db.SubTestMasters, "SubTestMasterId", "SubTestName");
            ViewBag.MainTestMaster = new SelectList(db.MainTests, "MainTestId", "MainTestName");
            //ViewBag.Main11 = db.MainTests.ToList();
            return View();
        }
        public JsonResult GetPrice(int MainTestId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var MainTestId1 = db.MainTests.Where(x => x.MainTestId == MainTestId);
            return Json(MainTestId1, JsonRequestBehavior.AllowGet);
        }

        // POST: TestOrderMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        //public ActionResult Create([Bind(Include = "TestOrderId,OrderNo,PatientId,ReferBy,OrderDate")] TestOrderMaster testOrderMaster)
        //{

        //    testOrderMaster.OrderDate = DateTime.Now; 
        //    if (ModelState.IsValid)
        //    {
        //        db.TestOrderMasters.Add(testOrderMaster);
        //        db.SaveChanges();
        //        //int id = testOrderMaster.TestOrderId;
        //        //TestOrderDetail testOrderDetail = new TestOrderDetail();

        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.PatientId = new SelectList(db.PatientMasters, "PatientId", "PatientName", testOrderMaster.PatientId);
        //    return View(testOrderMaster);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestOrderWithView testOrderWithView)
        {

            //testOrderWithView.OrderDate = DateTime.Now;
            TestOrderMaster testOrderMaster = new TestOrderMaster();
                ViewBag.PatientId = new SelectList(db.PatientMasters, "PatientId", "PatientName", testOrderMaster.PatientId);
            testOrderMaster.OrderNo = testOrderWithView.OrderNo;
                testOrderMaster.PatientId = testOrderWithView.PatientId;
                testOrderMaster.ReferBy = testOrderWithView.ReferBy;
                testOrderMaster.OrderDate = DateTime.Now;
                db.TestOrderMasters.Add(testOrderMaster);
                db.SaveChanges();
            int ordno = Convert.ToInt32(testOrderMaster.OrderNo);
            TestOrderDetail testOrderDetail = new TestOrderDetail();
            testOrderDetail.OrderId = ordno;
            testOrderDetail.PatientId = testOrderMaster.PatientId;
            testOrderDetail.TestMasterId = testOrderWithView.TestMasterId;
            testOrderDetail.SubTestMasterId = testOrderWithView.SubTestMasterId;
            testOrderDetail.MainTestId = testOrderWithView.MainTestId;
            testOrderDetail.PriceReceived = testOrderWithView.Price;
            testOrderDetail.testValue = 0;
            testOrderDetail.Status = 1;
            db.TestOrderDetails.Add(testOrderDetail);
            db.SaveChanges();

            //int id = testOrderMaster.TestOrderId;
            //TestOrderDetail testOrderDetail = new TestOrderDetail();

            return RedirectToAction("Index");
            

            
            //return View(testOrderMaster);
        }

        // GET: TestOrderMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestOrderMaster testOrderMaster = db.TestOrderMasters.Find(id);
            if (testOrderMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.PatientMasters, "PatientId", "PatientName", testOrderMaster.PatientId);
            return View(testOrderMaster);
        }

        // POST: TestOrderMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestOrderId,OrderNo,PatientId,ReferBy,OrderDate")] TestOrderMaster testOrderMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testOrderMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientId = new SelectList(db.PatientMasters, "PatientId", "PatientName", testOrderMaster.PatientId);
            return View(testOrderMaster);
        }

        // GET: TestOrderMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestOrderMaster testOrderMaster = db.TestOrderMasters.Find(id);
            if (testOrderMaster == null)
            {
                return HttpNotFound();
            }
            return View(testOrderMaster);
        }

        // POST: TestOrderMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestOrderMaster testOrderMaster = db.TestOrderMasters.Find(id);
            db.TestOrderMasters.Remove(testOrderMaster);
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

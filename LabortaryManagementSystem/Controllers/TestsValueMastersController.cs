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
    public class TestsValueMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestsValueMasters
        public ActionResult Index()
        {
            var testsValueMasters = db.TestsValueMasters.Include(t => t.MainTest).Include(t => t.SubTestMaster).Include(t => t.TestMaster);
            return View(testsValueMasters.ToList());
        }

        // GET: TestsValueMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestsValueMaster testsValueMaster = db.TestsValueMasters.Find(id);
            if (testsValueMaster == null)
            {
                return HttpNotFound();
            }
            return View(testsValueMaster);
        }

        // GET: TestsValueMasters/Create
        public ActionResult Create()
        {
            ViewBag.MainTestId = new SelectList(db.MainTests, "MainTestId", "MainTestName");
            ViewBag.SubTestMasterId = new SelectList(db.SubTestMasters, "SubTestMasterId", "SubTestName");
            ViewBag.TestMasterId = new SelectList(db.TestMasters, "TestMasterId", "TestMasterName");
            return View();
        }

        public JsonResult SubTestMasterList(int TestMasterId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<SubTestMaster> SubTestList = db.SubTestMasters.Where(x => x.TestMasterId == TestMasterId).ToList();
            return Json(SubTestList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MainTestList(int SubTestMasterId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<MainTest> MainTestList = db.MainTests.Where(x => x.SubTestMasterId == SubTestMasterId).ToList();
            return Json(MainTestList, JsonRequestBehavior.AllowGet);
        }

        // POST: TestsValueMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestsValueId,TestMasterId,SubTestMasterId,MainTestId,Gender,AgeGroupLessThan,AgeGroupGreaterThan,TestMinimumValue,TestMaximumValue")] TestsValueMaster testsValueMaster)
        {
            if (ModelState.IsValid)
            {
                db.TestsValueMasters.Add(testsValueMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MainTestId = new SelectList(db.MainTests, "MainTestId", "MainTestName", testsValueMaster.MainTestId);
            ViewBag.SubTestMasterId = new SelectList(db.SubTestMasters, "SubTestMasterId", "SubTestName", testsValueMaster.SubTestMasterId);
            ViewBag.TestMasterId = new SelectList(db.TestMasters, "TestMasterId", "TestMasterName", testsValueMaster.TestMasterId);
            return View(testsValueMaster);
        }

        // GET: TestsValueMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestsValueMaster testsValueMaster = db.TestsValueMasters.Find(id);
            if (testsValueMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.MainTestId = new SelectList(db.MainTests, "MainTestId", "MainTestName", testsValueMaster.MainTestId);
            ViewBag.SubTestMasterId = new SelectList(db.SubTestMasters, "SubTestMasterId", "SubTestName", testsValueMaster.SubTestMasterId);
            ViewBag.TestMasterId = new SelectList(db.TestMasters, "TestMasterId", "TestMasterName", testsValueMaster.TestMasterId);
            return View(testsValueMaster);
        }

        // POST: TestsValueMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestsValueId,TestMasterId,SubTestMasterId,MainTestId,Gender,AgeGroupLessThan,AgeGroupGreaterThan,TestMinimumValue,TestMaximumValue")] TestsValueMaster testsValueMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testsValueMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MainTestId = new SelectList(db.MainTests, "MainTestId", "MainTestName", testsValueMaster.MainTestId);
            ViewBag.SubTestMasterId = new SelectList(db.SubTestMasters, "SubTestMasterId", "SubTestName", testsValueMaster.SubTestMasterId);
            ViewBag.TestMasterId = new SelectList(db.TestMasters, "TestMasterId", "TestMasterName", testsValueMaster.TestMasterId);
            return View(testsValueMaster);
        }

        // GET: TestsValueMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestsValueMaster testsValueMaster = db.TestsValueMasters.Find(id);
            if (testsValueMaster == null)
            {
                return HttpNotFound();
            }
            return View(testsValueMaster);
        }

        // POST: TestsValueMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestsValueMaster testsValueMaster = db.TestsValueMasters.Find(id);
            db.TestsValueMasters.Remove(testsValueMaster);
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

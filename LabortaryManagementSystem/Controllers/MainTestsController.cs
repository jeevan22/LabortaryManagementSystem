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
    public class MainTestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MainTests
        public ActionResult Index()
        {
            var mainTests = db.MainTests.Include(m => m.SubTestMaster).Include(m => m.TestMaster);
            return View(mainTests.ToList());
        }

        // GET: MainTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainTest mainTest = db.MainTests.Find(id);
            if (mainTest == null)
            {
                return HttpNotFound();
            }
            return View(mainTest);
        }

        // GET: MainTests/Create
        public ActionResult Create()
        {
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

        // POST: MainTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MainTestId,TestMasterId,SubTestMasterId,MainTestName,Units,Price")] MainTest mainTest)
        {
            if (ModelState.IsValid)
            {
                db.MainTests.Add(mainTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubTestMasterId = new SelectList(db.SubTestMasters, "SubTestMasterId", "SubTestName", mainTest.SubTestMasterId);
            ViewBag.TestMasterId = new SelectList(db.TestMasters, "TestMasterId", "TestMasterName", mainTest.TestMasterId);
            return View(mainTest);
        }

        // GET: MainTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainTest mainTest = db.MainTests.Find(id);
            if (mainTest == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubTestMasterId = new SelectList(db.SubTestMasters, "SubTestMasterId", "SubTestName", mainTest.SubTestMasterId);
            ViewBag.TestMasterId = new SelectList(db.TestMasters, "TestMasterId", "TestMasterName", mainTest.TestMasterId);
            return View(mainTest);
        }

        // POST: MainTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MainTestId,TestMasterId,SubTestMasterId,MainTestName,Units,Price")] MainTest mainTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubTestMasterId = new SelectList(db.SubTestMasters, "SubTestMasterId", "SubTestName", mainTest.SubTestMasterId);
            ViewBag.TestMasterId = new SelectList(db.TestMasters, "TestMasterId", "TestMasterName", mainTest.TestMasterId);
            return View(mainTest);
        }

        // GET: MainTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainTest mainTest = db.MainTests.Find(id);
            if (mainTest == null)
            {
                return HttpNotFound();
            }
            return View(mainTest);
        }

        // POST: MainTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MainTest mainTest = db.MainTests.Find(id);
            db.MainTests.Remove(mainTest);
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

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
    public class PatientMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PatientMasters
        public ActionResult Index()
        {
            return View(db.PatientMasters.ToList());
        }

        // GET: PatientMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientMaster patientMaster = db.PatientMasters.Find(id);
            if (patientMaster == null)
            {
                return HttpNotFound();
            }
            return View(patientMaster);
        }

        // GET: PatientMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientId,PatientName,PatientAge,Gender,DateOfRegister,Mobile,Address")] PatientMaster patientMaster)
        {
            patientMaster.DateOfRegister = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.PatientMasters.Add(patientMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patientMaster);
        }

        // GET: PatientMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientMaster patientMaster = db.PatientMasters.Find(id);
            if (patientMaster == null)
            {
                return HttpNotFound();
            }
            return View(patientMaster);
        }

        // POST: PatientMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientId,PatientName,PatientAge,Gender,DateOfRegister,Mobile,Address")] PatientMaster patientMaster)
        {
            patientMaster.DateOfRegister = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(patientMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patientMaster);
        }

        // GET: PatientMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientMaster patientMaster = db.PatientMasters.Find(id);
            if (patientMaster == null)
            {
                return HttpNotFound();
            }
            return View(patientMaster);
        }

        // POST: PatientMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientMaster patientMaster = db.PatientMasters.Find(id);
            db.PatientMasters.Remove(patientMaster);
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

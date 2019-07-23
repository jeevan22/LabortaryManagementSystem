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
    public class TechnologiesMastersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TechnologiesMasters
        public ActionResult Index()
        {
            return View(db.TechnologiesMasters.ToList());
        }

        // GET: TechnologiesMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologiesMaster technologiesMaster = db.TechnologiesMasters.Find(id);
            if (technologiesMaster == null)
            {
                return HttpNotFound();
            }
            return View(technologiesMaster);
        }

        // GET: TechnologiesMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TechnologiesMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TechnologiesId,TechnologiesName")] TechnologiesMaster technologiesMaster)
        {
            if (ModelState.IsValid)
            {
                db.TechnologiesMasters.Add(technologiesMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(technologiesMaster);
        }

        // GET: TechnologiesMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologiesMaster technologiesMaster = db.TechnologiesMasters.Find(id);
            if (technologiesMaster == null)
            {
                return HttpNotFound();
            }
            return View(technologiesMaster);
        }

        // POST: TechnologiesMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TechnologiesId,TechnologiesName")] TechnologiesMaster technologiesMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technologiesMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technologiesMaster);
        }

        // GET: TechnologiesMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologiesMaster technologiesMaster = db.TechnologiesMasters.Find(id);
            if (technologiesMaster == null)
            {
                return HttpNotFound();
            }
            return View(technologiesMaster);
        }

        // POST: TechnologiesMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TechnologiesMaster technologiesMaster = db.TechnologiesMasters.Find(id);
            db.TechnologiesMasters.Remove(technologiesMaster);
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

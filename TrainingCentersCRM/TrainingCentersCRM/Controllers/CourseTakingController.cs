using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingCentersCRM.Infrastructure;
using TrainingCentersCRM.Models;

namespace TrainingCentersCRM.Controllers
{
    public class CourseTakingController : RoutingTrainingCenterController
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();

        // GET: /CourseTaking/
        public ActionResult Index()
        {
            return View(db.CourseTakings.ToList());
        }

        // GET: /CourseTaking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTaking coursetaking = db.CourseTakings.Find(id);
            if (coursetaking == null)
            {
                return HttpNotFound();
            }
            return View(coursetaking);
        }

        // GET: /CourseTaking/Create
        [TCAuthorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CourseTaking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TCAuthorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "Id,IdStudent,IdTrainingCourse,Status,AmountPaid,Debt,Description,IdObecjt")] CourseTaking coursetaking)
        {
            if (ModelState.IsValid)
            {
                db.CourseTakings.Add(coursetaking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coursetaking);
        }

        // GET: /CourseTaking/Edit/5
        [TCAuthorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTaking coursetaking = db.CourseTakings.Find(id);
            if (coursetaking == null)
            {
                return HttpNotFound();
            }
            return View(coursetaking);
        }

        // POST: /CourseTaking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TCAuthorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,IdStudent,IdTrainingCourse,Status,AmountPaid,Debt,Description,IdObecjt")] CourseTaking coursetaking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursetaking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coursetaking);
        }

        // GET: /CourseTaking/Delete/5
        [TCAuthorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTaking coursetaking = db.CourseTakings.Find(id);
            if (coursetaking == null)
            {
                return HttpNotFound();
            }
            return View(coursetaking);
        }

        // POST: /CourseTaking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [TCAuthorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseTaking coursetaking = db.CourseTakings.Find(id);
            db.CourseTakings.Remove(coursetaking);
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

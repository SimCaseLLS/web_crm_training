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
    public class ScheduleTtrainingCoursController : RoutingTrainingCenterController
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();

        // GET: /ScheduleTtrainingCours/
        public ActionResult Index()
        {
            var schedulettrainingcourses = db.ScheduleTtrainingCourses.Include(s => s.TrainingCenter).Include(s => s.TrainingCours);
            var tcUrl = RouteData.Values["tc"];
            var tc = db.TrainingCenters.SingleOrDefault(a => a.Url == tcUrl);
            var shedule = schedulettrainingcourses.Where(a => a.IdTrainingCenter == tc.Id);
            return View(shedule.ToList());
        }

        // GET: /ScheduleTtrainingCours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleTtrainingCours schedulettrainingcours = db.ScheduleTtrainingCourses.Find(id);
            if (schedulettrainingcours == null)
            {
                return HttpNotFound();
            }
            return View(schedulettrainingcours);
        }

        // GET: /ScheduleTtrainingCours/Create
        [TCAuthorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.IdTrainingCenter = new SelectList(db.TrainingCenters, "Id", "Addres");
            ViewBag.IdTrainingCourse = new SelectList(db.TrainingCourses, "Id", "Title");
            return View();
        }

        // POST: /ScheduleTtrainingCours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TCAuthorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "Id,Title,Description,DateStart,DateEnd,IdTrainingCenter,IdTrainingCourse")] ScheduleTtrainingCours schedulettrainingcours)
        {
            if (ModelState.IsValid)
            {
                db.ScheduleTtrainingCourses.Add(schedulettrainingcours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTrainingCenter = new SelectList(db.TrainingCenters, "Id", "Addres", schedulettrainingcours.IdTrainingCenter);
            ViewBag.IdTrainingCourse = new SelectList(db.TrainingCourses, "Id", "Title", schedulettrainingcours.IdTrainingCourse);
            return View(schedulettrainingcours);
        }

        // GET: /ScheduleTtrainingCours/Edit/5
        [TCAuthorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleTtrainingCours schedulettrainingcours = db.ScheduleTtrainingCourses.Find(id);
            if (schedulettrainingcours == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTrainingCenter = new SelectList(db.TrainingCenters, "Id", "Addres", schedulettrainingcours.IdTrainingCenter);
            ViewBag.IdTrainingCourse = new SelectList(db.TrainingCourses, "Id", "Title", schedulettrainingcours.IdTrainingCourse);
            return View(schedulettrainingcours);
        }

        // POST: /ScheduleTtrainingCours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TCAuthorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,DateStart,DateEnd,IdTrainingCenter,IdTrainingCourse")] ScheduleTtrainingCours schedulettrainingcours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedulettrainingcours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTrainingCenter = new SelectList(db.TrainingCenters, "Id", "Addres", schedulettrainingcours.IdTrainingCenter);
            ViewBag.IdTrainingCourse = new SelectList(db.TrainingCourses, "Id", "Title", schedulettrainingcours.IdTrainingCourse);
            return View(schedulettrainingcours);
        }

        // GET: /ScheduleTtrainingCours/Delete/5
        [TCAuthorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleTtrainingCours schedulettrainingcours = db.ScheduleTtrainingCourses.Find(id);
            if (schedulettrainingcours == null)
            {
                return HttpNotFound();
            }
            return View(schedulettrainingcours);
        }

        // POST: /ScheduleTtrainingCours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [TCAuthorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduleTtrainingCours schedulettrainingcours = db.ScheduleTtrainingCourses.Find(id);
            db.ScheduleTtrainingCourses.Remove(schedulettrainingcours);
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

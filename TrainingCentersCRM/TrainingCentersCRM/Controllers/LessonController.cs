using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingCentersCRM.Models;

namespace TrainingCentersCRM.Controllers
{
    public class LessonController : RoutingTrainingCenterController
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();

        // GET: /Lesson/
        public ActionResult Index()
        {
            return View(db.Lessons.ToList());
        }

        // GET: /Lesson/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // GET: /Lesson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Lesson/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Time,Duration,IdObject")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Lessons.Add(lesson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lesson);
        }

        // GET: /Lesson/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // POST: /Lesson/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Time,Duration,IdObject")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lesson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lesson);
        }

        // GET: /Lesson/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // POST: /Lesson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lesson lesson = db.Lessons.Find(id);
            db.Lessons.Remove(lesson);
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

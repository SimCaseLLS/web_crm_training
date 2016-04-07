using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
=======
using TrainingCentersCRM.Infrastructure;
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
using TrainingCentersCRM.Models;

namespace TrainingCentersCRM.Controllers
{
<<<<<<< HEAD
    public class TrainingModuleController : Controller
=======
    public class TrainingModuleController : RoutingTrainingCenterController
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();

        // GET: /TrainingModule/
        public ActionResult Index()
        {
            return View(db.TrainingModules.ToList());
        }

        // GET: /TrainingModule/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingModule trainingmodule = db.TrainingModules.Find(id);
            if (trainingmodule == null)
            {
                return HttpNotFound();
            }
            return View(trainingmodule);
        }

        // GET: /TrainingModule/Create
<<<<<<< HEAD
        public ActionResult Create()
        {
=======
        [TCAuthorize(Roles = "admin")]
        public ActionResult Create(int id)
        {
            ViewBag.TrainingCenterId = id;
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
            return View();
        }

        // POST: /TrainingModule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Create([Bind(Include="Id,Title,ShortDescription,Numbers,Hours,Topics,IdTrainingCenter")] TrainingModule trainingmodule)
=======
        [TCAuthorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "Id,Title,ShortDescription,Numbers,Hours,Topics,IdTrainingCenter,IdTrainingCourse")] TrainingModule trainingmodule, int IdTrainingCourse)
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        {
            if (ModelState.IsValid)
            {
                db.TrainingModules.Add(trainingmodule);
                db.SaveChanges();
<<<<<<< HEAD
                return RedirectToAction("Index");
=======
                db.CourseModules.Add(new CourseModule { IdTrainingCourse = IdTrainingCourse, IdTrainingModule = trainingmodule.Id });
                db.SaveChanges();
                return RedirectToAction("Details", "TrainingCours", new { id = IdTrainingCourse });
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
            }

            return View(trainingmodule);
        }

        // GET: /TrainingModule/Edit/5
<<<<<<< HEAD
=======
        [TCAuthorize(Roles = "admin")]
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingModule trainingmodule = db.TrainingModules.Find(id);
            if (trainingmodule == null)
            {
                return HttpNotFound();
            }
            return View(trainingmodule);
        }

        // POST: /TrainingModule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Edit([Bind(Include="Id,Title,ShortDescription,Numbers,Hours,Topics,IdTrainingCenter")] TrainingModule trainingmodule)
=======
        [TCAuthorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,Title,ShortDescription,Numbers,Hours,Topics,IdTrainingCenter")] TrainingModule trainingmodule)
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingmodule).State = EntityState.Modified;
                db.SaveChanges();
<<<<<<< HEAD
                return RedirectToAction("Index");
=======
                int? tcId = db.CourseModules.Where(a => a.IdTrainingModule == trainingmodule.Id).First().IdTrainingCourse;
                return RedirectToAction("Details", "TrainingCours", new { id = tcId });
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
            }
            return View(trainingmodule);
        }

        // GET: /TrainingModule/Delete/5
<<<<<<< HEAD
=======
        [TCAuthorize(Roles = "admin")]
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingModule trainingmodule = db.TrainingModules.Find(id);
            if (trainingmodule == null)
            {
                return HttpNotFound();
            }
            return View(trainingmodule);
        }

        // POST: /TrainingModule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingModule trainingmodule = db.TrainingModules.Find(id);
            db.TrainingModules.Remove(trainingmodule);
            db.SaveChanges();
            return RedirectToAction("Index");
=======
        [TCAuthorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingModule trainingmodule = db.TrainingModules.Find(id);
            int? courseId = trainingmodule.CourseModules.First().IdTrainingCourse;
            if (trainingmodule.CourseModules.Count() > 0)
                db.CourseModules.RemoveRange(trainingmodule.CourseModules);
            db.TrainingModules.Remove(trainingmodule);
            db.SaveChanges();
            return RedirectToAction("Details", "TrainingCours", new { id = courseId });
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
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

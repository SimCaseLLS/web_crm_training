using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingCentersCRM.Models;
using TrainingCentersCRM.Models.ViewModels;

namespace TrainingCentersCRM.Controllers
{
    public class TrainingCoursController : RoutingTrainingCenterController
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();

        // GET: /TrainingCours/
        public ActionResult Index()
        {
            TrainingCours[] res;
            if (trainingCenter.Url == "empty")
                res = db.TrainingCourses.ToArray();
            else
                res = db.TrainingCourses.Where(a => a.TrainingCenterCourses.Where(b => b.IdTrainingCenter == trainingCenter.Id).Select(c => c.IdTrainingCourse).Contains(a.Id)).ToArray();
            ViewBag.Key = this.trainingCenter.Url;
            return View(res);
        }

        public JsonResult GetAll(int? id)
        {
            return Json(db.TrainingCourses.Select(a => new
            {
                Id = a.Id,
                Title = a.Title,
                Checked = db.RelatedCourses.Where(b => b.IdTrainingCourse == id && b.IdTrainingCourseRelated == a.Id).Count() > 0 ? true : false
            }).ToArray(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllTeachers(int? id)
        {
            var teachers = db.Teachers.OrderBy(o => o.LastName).ToList();
            var res = teachers.Select(a => new
            {
                Id = a.Id,
                Title = a.LastName + " " + a.FirstName + " " + a.Patronymic,
                Checked = db.TrainingCourseTeachers.Where(b => b.IdTrainingCourse == id && b.IdTeacher == a.Id).Count() > 0 ? true : false
            });
            return Json(res, JsonRequestBehavior.AllowGet);
            
        }

        [HttpPost]
        public string AddRelated(int? id, string[] checkedRelated)
        {
            db.RelatedCourses.RemoveRange(db.RelatedCourses.Where(a => a.IdTrainingCourse == id));
            if (checkedRelated != null)
                foreach (var s in checkedRelated)
                {
                    int si = Convert.ToInt32(s);
                    //if (db.RelatedCourses.Where(a => a.IdTrainingCourse == si && a.IdTrainingCourseRelated == id).Count() > 0)
                    //    continue;
                    db.RelatedCourses.Add(new RelatedCours { IdTrainingCourse = id, IdTrainingCourseRelated = si });
                }
            db.SaveChanges();
            return "ok";
        }
        [HttpPost]
        public string AddRelatedTeacher(int? id, string[] checkedRelatedTeacher)
        {
            db.TrainingCourseTeachers.RemoveRange(db.TrainingCourseTeachers.Where(a => a.IdTrainingCourse == id));
            if (checkedRelatedTeacher != null)
                foreach (var s in checkedRelatedTeacher)
                {
                    int si = Convert.ToInt32(s);
                    db.TrainingCourseTeachers.Add(new TrainingCourseTeacher { IdTrainingCourse = id, IdTeacher = si });
                }
            db.SaveChanges();
            return "ok";
        }

        // GET: /TrainingCours/Details/5
        public ActionResult Details(int? id)
        {
            var tcUrl = RouteData.Values["tc"];
            var tc = db.TrainingCenters.SingleOrDefault(a => a.Url == tcUrl);
            var trainingCourseTeacher = db.TrainingCourseTeachers.Where(a => a.IdTrainingCourse == id).Select(b => b.Teacher);
            ViewBag.trainingCourseTeacher = trainingCourseTeacher;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCours trainingcours = db.TrainingCourses.Find(id);
            trainingcours.QualificationTrainingCours = new List<QualificationTrainingCour>();
            PopulateRelatedTagData(trainingcours);
            if (trainingcours == null)
            {
                return HttpNotFound();
            }
            return View(trainingcours);
        }

        // GET: /TrainingCours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TrainingCours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ShortDescription,Hourse,PriceForOrganizations,PriceForIndividuals,CostOfOneHourForOrganizations,CostOfOneHourForIndividuals,LevelOfDifficulty,RequiredPreliminaryPreparation,MandatoryPreliminaryPreparation,IdTraningCenter,IdObject")] TrainingCours trainingcours)
        {
            if (ModelState.IsValid)
            {
                trainingcours.IdTraningCenter = trainingCenter.Id;
                db.TrainingCourses.Add(trainingcours);
                db.SaveChanges();
                db.TrainingCenterCourses.Add(new TrainingCenterCours { IdTrainingCenter = trainingCenter.Id, IdTrainingCourse = trainingcours.Id});
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainingcours);
        }

        // GET: /TrainingCours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCours trainingcours = db.TrainingCourses.Find(id);
            if (trainingcours == null)
            {
                return HttpNotFound();
            }
            return View(trainingcours);
        }

        // POST: /TrainingCours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ShortDescription,Hourse,PriceForOrganizations,PriceForIndividuals,CostOfOneHourForOrganizations,CostOfOneHourForIndividuals,LevelOfDifficulty,RequiredPreliminaryPreparation,MandatoryPreliminaryPreparation,IdTraningCenter,IdObject")] TrainingCours trainingcours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingcours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingcours);
        }

        // GET: /TrainingCours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCours trainingcours = db.TrainingCourses.Find(id);
            if (trainingcours == null)
            {
                return HttpNotFound();
            }
            return View(trainingcours);
        }

        // POST: /TrainingCours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingCours trainingcours = db.TrainingCourses.Find(id);
            db.TrainingCourses.Remove(trainingcours);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult Qualifications(int? id)
        {
            var res = db.QualificationTrainingCours.Include(a => a.Qualification).Where(a => a.IdTrainingCours == id).Select(b => b.Qualification.Title);
            return Json(res.ToArray(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string SetQualifications(int Id, string[] selectedQualifications)
        {
            db.QualificationTrainingCours.RemoveRange(db.QualificationTrainingCours.Where(a => a.IdTrainingCours == Id));
            db.SaveChanges();
            foreach (var s in selectedQualifications)
            {
                QualificationTrainingCour c = new QualificationTrainingCour { IdQualification = Convert.ToInt32(s), IdTrainingCours = Id };
                db.QualificationTrainingCours.Add(c);
            }
            db.SaveChanges();
            return "ok";
        }

        private void PopulateRelatedTagData(TrainingCours course)
        {
            var allQualifications = db.Qualifications;
            var instructionTags = course.QualificationTrainingCours.Where(a => a.IdTrainingCours == course.Id).Select(c => c.IdQualification).ToList();
            var viewModel = new List<RelatedQualifications>();
            foreach (var qualification in allQualifications)
            {
                viewModel.Add(new RelatedQualifications
                {
                    QualificationID = qualification.Id,
                    Title = qualification.Title,
                    Assigned = instructionTags.Contains(qualification.Id)
                });
            }
            ViewBag.Qualifications = viewModel;
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

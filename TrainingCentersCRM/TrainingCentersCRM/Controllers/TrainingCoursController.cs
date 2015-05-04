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

        public ActionResult ShortList()
        {
            return View(db.TrainingCourses);
        }

        public JsonResult GetAll(int? id)
        {
            var relBuf = db.TrainingCenterCourses.Where(a => a.IdTrainingCenter == trainingCenter.Id && a.IdTrainingCourse == id);
            var related = from a in db.RelatedCourses from b in relBuf where a.IdTrainingCourseRelated == b.Id select a.TrainingCours.TrainingCours;
            var allowed = from a in db.TrainingCourses from b in db.TrainingCenterCourses where b.IdTrainingCenter == trainingCenter.Id && a.Id == b.IdTrainingCourse select a;
            return Json(allowed.Select(a => new
            {
                Id = a.Id,
                Title = a.Title,
                Checked = related.Where(b => b.Id == a.Id).Count() > 0
            }).ToArray(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Calendar()
        {
            if (trainingCenter == null || trainingCenter.Url == "empty")
                return View(db.ScheduleTtrainingCourses.Where(a => a.DateEnd >= DateTime.Today.Date));
            else
            {
                var res = db.ScheduleTtrainingCourses.Where(a => a.IdTrainingCenter == this.trainingCenter.Id && a.DateEnd >= DateTime.Today.Date);
                return View(res);
            }
        }
        public JsonResult GetAllTeachers(int? id)
        {
            var teachers = from a in db.TrainingCenterTeachers from b in db.Teachers where a.IdTrainingCenter == trainingCenter.Id && a.IdTeacher == b.Id select b;
            var res = teachers.Select(a => new
            {
                Id = a.Id,
                Title = a.LastName + " " + a.FirstName + " " + a.Patronymic,
                Checked = db.TrainingCourseTeachers.Where(b => b.IdTrainingCourse == id && b.IdTeacher == a.Id && b.TrainingCours.IdTrainingCenter == trainingCenter.Id).Count() > 0 ? true : false
            });
            return Json(res, JsonRequestBehavior.AllowGet);
            
        }

        [HttpPost]
        public string AddRelated(int? id, string[] checkedRelated)
        {
            var related = from a in db.TrainingCenterCourses where a.IdTrainingCenter == trainingCenter.Id && a.IdTrainingCourse == id select a;
            db.RelatedCourses.RemoveRange(from a in db.RelatedCourses from b in related where a.IdTrainingCourseRelated == b.Id select a);
            var relCourse = db.TrainingCenterCourses.FirstOrDefault(e => e.IdTrainingCourse == id && e.IdTrainingCenter == trainingCenter.Id);
            if (checkedRelated != null)
                foreach (var s in checkedRelated)
                {
                    int si = Convert.ToInt32(s);
                    var trCourse = db.TrainingCenterCourses.FirstOrDefault(e => e.IdTrainingCourse == si && e.IdTrainingCenter == trainingCenter.Id);
                    db.RelatedCourses.Add(new RelatedCourse 
                    { 
                        TrainingCours = trCourse,
                        IdTrainingCourseRelated = relCourse.Id 
                    });
                }
            db.SaveChanges();
            return "ok";
        }

        [HttpPost]
        public string AddRelatedTeacher(int? id, string[] checkedRelatedTeacher)
        {
            var tcCourses = from a in db.TrainingCenterCourses where a.IdTrainingCourse == id && a.IdTrainingCenter == trainingCenter.Id select a;
            var teachers = from a in db.TrainingCourseTeachers from b in tcCourses where a.IdTrainingCourse == b.IdTrainingCourse select a;
            IEnumerable<TrainingCourseTeacher> toDelete = (from a in db.TrainingCourses 
                        from b in db.TrainingCourseTeachers 
                        from c in db.TrainingCenterCourses 
                        where b.IdTrainingCourse == a.Id 
                        && c.IdTrainingCourse == a.Id 
                        && c.IdTrainingCenter == trainingCenter.Id 
                        select b).AsEnumerable();
            //    db.TrainingCourseTeachers.Where(a => a.TrainingCours.TrainingCours.Id == id && a.TrainingCours.IdTrainingCenter == trainingCenter.Id);
            db.TrainingCourseTeachers.RemoveRange(teachers);
            db.SaveChanges();
            if (checkedRelatedTeacher != null)
                foreach (var s in checkedRelatedTeacher)
                {
                    int si = Convert.ToInt32(s);
                    db.TrainingCourseTeachers.Add(new TrainingCourseTeacher 
                    { 
                        IdTrainingCourse = db.TrainingCenterCourses.Single(a => a.IdTrainingCenter == trainingCenter.Id && a.IdTrainingCourse == id).Id, 
                        IdTeacher = si 
                    });
                }
            db.SaveChanges();
            return "ok";
        }
        
        [HttpPost]
        public string AddTime([Bind(Include = "IdTrainingCourse,IdTrainingCenter,Description,DateStart,DateEnd")]ScheduleTtrainingCours stc)
        {
            db.ScheduleTtrainingCourses.Add(stc);
            db.SaveChanges();
            return "ok";
        }
        // GET: /TrainingCours/Details/5
        public ActionResult Details(int? id)
        {
            var tcUrl = RouteData.Values["tc"];
            var tc = db.TrainingCenters.SingleOrDefault(a => a.Url == tcUrl);

            var buf = from a in db.TrainingCenterCourses where a.IdTrainingCourse == id && a.IdTrainingCenter == trainingCenter.Id select a;

            var trainingCourseTeacher = from a in db.TrainingCourseTeachers from b in buf where a.IdTrainingCourse == b.Id select a.Teacher;
            ViewBag.trainingCourseTeacher = trainingCourseTeacher;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCours trainingcours = db.TrainingCourses.Find(id);
            trainingcours.QualificationTrainingCours = new List<QualificationTrainingCour>();
            var related = db.TrainingCenterCourses.Where(a => a.IdTrainingCenter == trainingCenter.Id && a.IdTrainingCourse == id);
            ViewBag.RelatedCourses = from a in db.RelatedCourses from b in related where a.IdTrainingCourseRelated == b.Id select a.TrainingCours.TrainingCours;
            PopulateRelatedTagData(trainingcours);
            ViewBag.Dates = db.ScheduleTtrainingCourses.Where(a => a.IdTrainingCourse == id && a.DateEnd > DateTime.Now).Include(b => b.TrainingCenter);
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
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Title,ShortDescription,Hourse,PriceForOrganizations,PriceForIndividuals,CostOfOneHourForOrganizations,CostOfOneHourForIndividuals,LevelOfDifficulty,RequiredPreliminaryPreparation,MandatoryPreliminaryPreparation,IdObject")] TrainingCours trainingcours)
        {
            if (ModelState.IsValid)
            {
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
        [ValidateInput(false)]
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

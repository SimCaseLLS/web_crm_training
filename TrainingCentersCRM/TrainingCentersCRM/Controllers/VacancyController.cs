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
using TrainingCentersCRM.Models.ViewModels;

namespace TrainingCentersCRM.Controllers
{
    public class VacancyController : RoutingTrainingCenterController
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();

        // GET: /Vacancy/
        public ActionResult Index()
        {
            return View(db.Vacancies.Where(a => a.IdTrainingCenter == trainingCenter.Id || a.IdTrainingCenter == db.TrainingCenters.FirstOrDefault(b => b.Url == "empty").Id).ToList());
        }

        // GET: /Vacancy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = db.Vacancies.Where(c => c.Id == id).Include(c => c.Qualifications).Single();
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        // GET: /Vacancy/Create
        [TCAuthorize(Roles = "admin")]
        public ActionResult Create()
        {
            var vacancy = new Vacancy();
            vacancy.Qualifications = new List<Qualification>();
            PopulateRelatedTagData(vacancy);
            return View();
        }

        // POST: /Vacancy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TCAuthorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "Id,IdTrainingCenter,Description,Organization,Wages,Additionally,Link")] Vacancy vacancy, string[] selectedQualifications)
        {
            if (selectedQualifications != null)
            {
                vacancy.Qualifications = new List<Qualification>();
                foreach (var qualification in selectedQualifications)
                {
                    var qualificationToAdd = db.Qualifications.Find(int.Parse(qualification));
                    vacancy.Qualifications.Add(qualificationToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                db.Vacancies.Add(vacancy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateRelatedTagData(vacancy);
            return View(vacancy);
        }

        private void PopulateRelatedTagData(Vacancy vacancy)
        {
            var allQualifications = db.Qualifications;
            var instructionTags = new HashSet<int>(vacancy.Qualifications.Select(c => c.Id));
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

        // GET: /Vacancy/Edit/5
        [TCAuthorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = db.Vacancies.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            PopulateRelatedTagData(vacancy);
            return View(vacancy);
        }

        // POST: /Vacancy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TCAuthorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,Description,Organization,Wages,Additionally,Link")] Vacancy vacancy, string[] selectedQualifications)
        {
            var vacancyToupdate = db.Vacancies.Where(i => i.Id == vacancy.Id).Include(i => i.Qualifications).Single();
            if (ModelState.IsValid)
            {
                UpdateInstructionTags(selectedQualifications, vacancyToupdate);
                db.Entry(vacancyToupdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vacancyToupdate);
        }

        private void UpdateInstructionTags(string[] selectedQualifications, Vacancy vacancyToUpdate)
        {
            if (selectedQualifications == null)
            {
                vacancyToUpdate.Qualifications = new List<Qualification>();
                return;
            }

            var selectedQualificationsHS = new HashSet<string>(selectedQualifications);
            var VacancyQualifications = new HashSet<int>
                (vacancyToUpdate.Qualifications.Select(c => c.Id));
            foreach (var qualification in db.Qualifications)
            {
                if (selectedQualificationsHS.Contains(qualification.Id.ToString()))
                {
                    if (!VacancyQualifications.Contains(qualification.Id))
                    {
                        vacancyToUpdate.Qualifications.Add(qualification);
                    }
                }
                else
                {
                    if (VacancyQualifications.Contains(qualification.Id))
                    {
                        vacancyToUpdate.Qualifications.Remove(qualification);
                    }
                }
            }
        }

        // GET: /Vacancy/Delete/5
        [TCAuthorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = db.Vacancies.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        // POST: /Vacancy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [TCAuthorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacancy vacancy = db.Vacancies.Find(id);
            db.Vacancies.Remove(vacancy);
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

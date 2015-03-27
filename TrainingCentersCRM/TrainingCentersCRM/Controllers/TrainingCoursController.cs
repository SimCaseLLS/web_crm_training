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
    public class TrainingCoursController : RoutingTrainingCenterController
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();

        // GET: /TrainingCours/
        public ActionResult Index()
        {
            ViewBag.Key = this.trainingCenter.Url;
            return View(db.TrainingCourses.ToList());
        }

        // GET: /TrainingCours/Details/5
        public ActionResult Details(int? id)
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
        public ActionResult Create([Bind(Include="Id,Title,ShortDescription,Hourse,PriceForOrganizations,PriceForIndividuals,CostOfOneHourForOrganizations,CostOfOneHourForIndividuals,LevelOfDifficulty,RequiredPreliminaryPreparation,MandatoryPreliminaryPreparation,IdTraningCenter,IdObject")] TrainingCours trainingcours)
        {
            if (ModelState.IsValid)
            {
                trainingcours.IdTraningCenter = trainingCenter.Id;
                db.TrainingCourses.Add(trainingcours);
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
        public ActionResult Edit([Bind(Include="Id,Title,ShortDescription,Hourse,PriceForOrganizations,PriceForIndividuals,CostOfOneHourForOrganizations,CostOfOneHourForIndividuals,LevelOfDifficulty,RequiredPreliminaryPreparation,MandatoryPreliminaryPreparation,IdTraningCenter,IdObject")] TrainingCours trainingcours)
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

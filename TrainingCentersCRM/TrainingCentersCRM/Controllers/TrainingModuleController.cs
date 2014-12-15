﻿using System;
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
    public class TrainingModuleController : RoutingTrainingCenterController
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TrainingModule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title,ShortDescription,Numbers,Hours,Topics,IdTrainingCenter")] TrainingModule trainingmodule)
        {
            if (ModelState.IsValid)
            {
                db.TrainingModules.Add(trainingmodule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainingmodule);
        }

        // GET: /TrainingModule/Edit/5
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
        public ActionResult Edit([Bind(Include="Id,Title,ShortDescription,Numbers,Hours,Topics,IdTrainingCenter")] TrainingModule trainingmodule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingmodule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingmodule);
        }

        // GET: /TrainingModule/Delete/5
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
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingModule trainingmodule = db.TrainingModules.Find(id);
            db.TrainingModules.Remove(trainingmodule);
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

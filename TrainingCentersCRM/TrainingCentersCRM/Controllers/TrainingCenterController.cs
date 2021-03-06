﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingCentersCRM.Models;
using TrainingCentersCRM.Infrastructure;

namespace TrainingCentersCRM.Controllers
{
    public class TrainingCenterController : RoutingTrainingCenterController
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();
        public JsonResult Centers() {
            var tcs = db.TrainingCenters.Where(a => a.Url != "empty");
            return Json(tcs.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShortList()
        {
            return View(db.TrainingCenters.Where(a => a.Url != "empty"));
        }

        // GET: /TrainingCenter/
        public ActionResult Index()
        {
            return View(db.TrainingCenters.ToList());
            //if (TCHelper.GetCurrentTCName() == "" || TCHelper.GetCurrentTCName() == "empty")
            //    return View(db.TrainingCenters.ToList());
            //else
            //    return View("Index", "TrainingCenterLayout", db.TrainingCenters.ToList());
        }

        [HttpPost]
        public string AddRelatedCourse(int? id, string[] checkedRelatedCourse)
        {
            if (id == null)
                return "error";
            if (checkedRelatedCourse != null)
            {
                db.TrainingCenterCourses.RemoveRange(db.TrainingCenterCourses.Where(a => a.IdTrainingCenter == id));
                foreach (var s in checkedRelatedCourse)
                {
                    int si = Convert.ToInt32(s);
                    db.TrainingCenterCourses.Add(new TrainingCenterCours { IdTrainingCourse = si, IdTrainingCenter = id });
                }
                db.SaveChanges();
            }
            return "ok";
        }

        public JsonResult GetAllLinkedCourses(int? id)
        {
            var teachers = db.TrainingCourses.ToList();
            var res = teachers.Select(a => new
            {
                Id = a.Id,
                Title = a.Title,
                Checked = db.TrainingCenterCourses.Where(b => b.IdTrainingCourse == a.Id && b.IdTrainingCenter == id).Count() > 0 ? true : false
            });
            return Json(res, JsonRequestBehavior.AllowGet);

        }




        // GET: /TrainingCenter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            TrainingCenter trainingcenter = db.TrainingCenters.Find(id);
            if (trainingcenter == null)
            {
                return HttpNotFound();
            }
            return View(trainingcenter);
        }

        // GET: /TrainingCenter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TrainingCenter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Addres,Phone,Email,Organization,Description,Logo,Url")] TrainingCenter trainingcenter)
        {
            if (ModelState.IsValid)
            {
                db.TrainingCenters.Add(trainingcenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainingcenter);
        }

        // GET: /TrainingCenter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCenter trainingcenter = db.TrainingCenters.Find(id);
            if (trainingcenter == null)
            {
                return HttpNotFound();
            }
            return View(trainingcenter);
        }

        // POST: /TrainingCenter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Addres,Phone,Email,Organization,Description,Logo,Url,HHCityId")] TrainingCenter trainingcenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingcenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingcenter);
        }

        // GET: /TrainingCenter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCenter trainingcenter = db.TrainingCenters.Find(id);
            if (trainingcenter == null)
            {
                return HttpNotFound();
            }
            return View(trainingcenter);
        }

        // POST: /TrainingCenter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingCenter trainingcenter = db.TrainingCenters.Find(id);
            db.TrainingCenters.Remove(trainingcenter);
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

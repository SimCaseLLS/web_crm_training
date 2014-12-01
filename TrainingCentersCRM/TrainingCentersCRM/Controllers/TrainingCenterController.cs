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
    public class TrainingCenterController : Controller
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();

        // GET: /TrainingCenter/
        public ActionResult Index()
        {
            return View(db.TrainingCenters.ToList());
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
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Addres,Phone,Email,Organization,Description,Logo,Url")] TrainingCenter trainingcenter)
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

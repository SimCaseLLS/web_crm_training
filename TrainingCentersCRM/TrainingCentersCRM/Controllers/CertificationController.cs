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
    public class CertificationController : Controller
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();

        // GET: /Certification/
        public ActionResult Index()
        {
            var certifications = db.Certifications.Include(c => c.CertificationProvider);
            return View(certifications.ToList());
        }

        // GET: /Certification/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certification certification = db.Certifications.Find(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            return View(certification);
        }

        // GET: /Certification/Create
<<<<<<< HEAD
=======
        [TCAuthorize(Roles = "admin")]
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        public ActionResult Create()
        {
            ViewBag.IdProvider = new SelectList(db.CertificationProviders, "Id", "Title");
            return View();
        }

        // POST: /Certification/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Create([Bind(Include="Id,IdProvider,Title,Description")] Certification certification)
=======
        [TCAuthorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "Id,IdProvider,Title,Description")] Certification certification)
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        {
            if (ModelState.IsValid)
            {
                db.Certifications.Add(certification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProvider = new SelectList(db.CertificationProviders, "Id", "Title", certification.IdProvider);
            return View(certification);
        }

        // GET: /Certification/Edit/5
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
            Certification certification = db.Certifications.Find(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProvider = new SelectList(db.CertificationProviders, "Id", "Title", certification.IdProvider);
            return View(certification);
        }

        // POST: /Certification/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Edit([Bind(Include="Id,IdProvider,Title,Description")] Certification certification)
=======
        [TCAuthorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,IdProvider,Title,Description")] Certification certification)
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        {
            if (ModelState.IsValid)
            {
                db.Entry(certification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProvider = new SelectList(db.CertificationProviders, "Id", "Title", certification.IdProvider);
            return View(certification);
        }

        // GET: /Certification/Delete/5
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
            Certification certification = db.Certifications.Find(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            return View(certification);
        }

        // POST: /Certification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
=======
        [TCAuthorize(Roles = "admin")]
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        public ActionResult DeleteConfirmed(int id)
        {
            Certification certification = db.Certifications.Find(id);
            db.Certifications.Remove(certification);
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

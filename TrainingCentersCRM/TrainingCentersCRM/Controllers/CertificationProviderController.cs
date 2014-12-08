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
    public class CertificationProviderController : Controller
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();

        // GET: /CertificationProvider/
        public ActionResult Index()
        {
            return View(db.CertificationProviders.ToList());
        }

        // GET: /CertificationProvider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CertificationProvider certificationprovider = db.CertificationProviders.Find(id);
            if (certificationprovider == null)
            {
                return HttpNotFound();
            }
            return View(certificationprovider);
        }

        // GET: /CertificationProvider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CertificationProvider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title,Addres,Phone,Email")] CertificationProvider certificationprovider)
        {
            if (ModelState.IsValid)
            {
                db.CertificationProviders.Add(certificationprovider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(certificationprovider);
        }

        // GET: /CertificationProvider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CertificationProvider certificationprovider = db.CertificationProviders.Find(id);
            if (certificationprovider == null)
            {
                return HttpNotFound();
            }
            return View(certificationprovider);
        }

        // POST: /CertificationProvider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Title,Addres,Phone,Email")] CertificationProvider certificationprovider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certificationprovider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(certificationprovider);
        }

        // GET: /CertificationProvider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CertificationProvider certificationprovider = db.CertificationProviders.Find(id);
            if (certificationprovider == null)
            {
                return HttpNotFound();
            }
            return View(certificationprovider);
        }

        // POST: /CertificationProvider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CertificationProvider certificationprovider = db.CertificationProviders.Find(id);
            db.CertificationProviders.Remove(certificationprovider);
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

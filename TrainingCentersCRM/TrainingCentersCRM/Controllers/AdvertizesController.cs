using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingCentersCRM.Models;

namespace TrainingCentersCRM.Controllers
{
    public class AdvertizesController : Controller
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();

        // GET: Advertizes
        public ActionResult Index()
        {
            return View(db.Advs.ToList());
        }

        public ActionResult Slider()
        {
            return View(db.Advs.Where(a => a.Enabled));
        }

        // GET: Advertizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertize advertize = db.Advs.Find(id);
            if (advertize == null)
            {
                return HttpNotFound();
            }
            return View(advertize);
        }

        [OutputCache(Duration = 3000, VaryByParam = "id")]
        public ActionResult Image(int id)
        {
            Advertize adv = db.Advs.SingleOrDefault(a => a.Id == id);
            byte[] imageData = adv.Image;
            return File(imageData, adv.ImageType);
        }


        // GET: Advertizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Advertizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Image")] Advertize advertize, HttpPostedFileBase uploadImage, string Enabled)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                if (Enabled != null && Enabled.Equals("on"))
                    advertize.Enabled = true;

                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    // считываем переданный файл в массив байтов
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    // установка массива байтов
                    advertize.Image = imageData;
                    advertize.ImageType = uploadImage.ContentType;
                }

                db.Advs.Add(advertize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advertize);
        }

        // GET: Advertizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertize advertize = db.Advs.Find(id);
            if (advertize == null)
            {
                return HttpNotFound();
            }
            return View(advertize);
        }

        // POST: Advertizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Image")] Advertize advertize, HttpPostedFileBase uploadImage, string Enabled)
        {
            if (ModelState.IsValid)
            {
                if (Enabled != null && Enabled.Equals("on"))
                    advertize.Enabled = true;
                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    // считываем переданный файл в массив байтов
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    // установка массива байтов
                    advertize.Image = imageData;
                    advertize.ImageType = uploadImage.ContentType;
                }

                db.Entry(advertize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advertize);
        }

        // GET: Advertizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertize advertize = db.Advs.Find(id);
            if (advertize == null)
            {
                return HttpNotFound();
            }
            return View(advertize);
        }

        // POST: Advertizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertize advertize = db.Advs.Find(id);
            db.Advs.Remove(advertize);
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

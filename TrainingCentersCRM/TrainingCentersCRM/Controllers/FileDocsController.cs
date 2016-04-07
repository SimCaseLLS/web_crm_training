using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingCentersCRM.Infrastructure;
using TrainingCentersCRM.Models;

namespace TrainingCentersCRM.Controllers
{
    public class FileDocsController : Controller
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();

        // GET: FileDocs
        public ActionResult Index(int id)
        {
            ViewBag.ArticleId = id;
            var fileDocuments = db.FileDocuments.Where(a => a.ArticleId == id);
            return PartialView(fileDocuments.ToList());
        }

        // GET: FileDocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileDocument fileDocument = db.FileDocuments.Find(id);
            if (fileDocument == null)
            {
                return HttpNotFound();
            }
            return View(fileDocument);
        }

        // GET: FileDocs/Create
        [TCAuthorize(Roles = "admin")]
        public ActionResult Create(int id)
        {
            ViewBag.ArticleId = id;
            return View();
        }

        public ActionResult Download(int id)
        {
            var doc = db.FileDocuments.FirstOrDefault(a => a.Id == id);
            return File(doc.Data, doc.ContentType, doc.Title);
        }

        // POST: FileDocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TCAuthorize(Roles = "admin")]
        public string Create([Bind(Include = "Id,Title,Description,Data,ContentType,ArticleId")] FileDocument fileDocument, HttpPostedFileBase uploadedFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadedFile != null)
                {
                    byte[] imageData = null;
                    // считываем переданный файл в массив байтов
                    using (var binaryReader = new BinaryReader(uploadedFile.InputStream))
                        imageData = binaryReader.ReadBytes(uploadedFile.ContentLength);
                    // установка массива байтов
                    fileDocument.Data = imageData;
                    fileDocument.ContentType = uploadedFile.ContentType;
                    db.FileDocuments.Add(fileDocument);
                    db.SaveChanges();
                }
                return "ok";
            }
            return "fail";
        }

        // GET: FileDocs/Edit/5
        [TCAuthorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileDocument fileDocument = db.FileDocuments.Find(id);
            if (fileDocument == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleId = new SelectList(db.Articles, "Id", "Title", fileDocument.ArticleId);
            return View(fileDocument);
        }

        // POST: FileDocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TCAuthorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,Title,Description")] FileDocument fileDocument)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fileDocument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Article", new { id = fileDocument.ArticleId});
            }
            ViewBag.ArticleId = new SelectList(db.Articles, "Id", "Title", fileDocument.ArticleId);
            return View(fileDocument);
        }

        // GET: FileDocs/Delete/5
        [TCAuthorize(Roles = "admin")]
        public ActionResult Delete(int? id, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileDocument fileDocument = db.FileDocuments.Find(id);
            if (fileDocument == null)
            {
                return HttpNotFound();
            }
            return View(fileDocument);
        }

        // POST: FileDocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [TCAuthorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id, string returnUrl)
        {
            FileDocument fileDocument = db.FileDocuments.Find(id);
            db.FileDocuments.Remove(fileDocument);
            db.SaveChanges();
            return Redirect(returnUrl);
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

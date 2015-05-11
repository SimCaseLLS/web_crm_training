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
using PagedList;
using System.IO;

namespace TrainingCentersCRM.Controllers
{
    public class ArticlesController : RoutingTrainingCenterController
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();

        // GET: Articles
        public ActionResult Index(int? id, bool? partial, int? page)
        {
            IQueryable<Article> result = db.Articles.OrderByDescending(a => a.PublishDate);
            if (TCHelper.GetCurrentTCName() != "" && TCHelper.GetCurrentTCName() != "empty")
            {
                ViewBag.TrainingCenter = TCHelper.GetCurrentTc(db);
                result = result.Where(a => a.TrainingCenter.Id == this.trainingCenter.Id);
            }
            if (id != null)
            {
                ViewBag.Type = id;
                result = result.Where(a => a.Type == (Article.ArticleType)id);
            }

            //int pageSize = page == null ? Int32.MaxValue : (Int32)HttpContext.Application["PageSize"];
            int pageSize = (Int32)HttpContext.Application["PageSize"];
            int pageNumber = (page ?? 1);
            var pagedRes = result.ToPagedList(pageNumber, pageSize);
            if (partial != null && partial == true)
                return PartialView(pagedRes);
            return View(pagedRes);
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create(int? type)
        {
            if (type == null)
                type = 1;
            ViewBag.Type = type;
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Title,Annotation,Text,UserId,PublishDate,Type")] Article article, HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                // установка массива байтов
                article.Image = imageData;
                article.ContentType = uploadImage.ContentType;
            }
            article.TrainingCenterId = this.trainingCenter.Id;
            db.Articles.Add(article);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = (int)article.Type });
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        
        public ActionResult Image(int id)
        {
            var doc = db.Articles.FirstOrDefault(a => a.Id == id);
            return File(doc.Image, doc.ContentType);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Annotation,Text,UserId,PublishDate,Type")] Article article, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                var old = db.Articles.FirstOrDefault(a => a.Id == article.Id);
                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    // считываем переданный файл в массив байтов
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    // установка массива байтов
                    old.Image = imageData;
                    old.ContentType = uploadImage.ContentType;
                }
                old.Title = article.Title;
                old.Annotation = article.Annotation;
                old.Text = article.Text;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = article.Type });
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            int type = (int)article.Type;
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = type });
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

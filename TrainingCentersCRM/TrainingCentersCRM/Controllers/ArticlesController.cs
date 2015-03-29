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

namespace TrainingCentersCRM.Controllers
{
    public class ArticlesController : RoutingTrainingCenterController
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();

        // GET: Articles
        public ActionResult Index(int? id)
        {
            IQueryable<Article> result = db.Articles;
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
            return View(result);
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
        public ActionResult Create([Bind(Include = "Id,Title,Annotation,Text,UserId,PublishDate,Type")] Article article)
        {
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

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Annotation,Text,UserId,PublishDate,Type")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
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
            return RedirectToAction("Index", new { id = type});
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

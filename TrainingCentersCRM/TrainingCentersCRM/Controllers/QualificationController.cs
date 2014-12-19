using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using TrainingCentersCRM.Infrastructure;
using TrainingCentersCRM.Models;

namespace TrainingCentersCRM.Controllers
{
    public class QualificationController : RoutingTrainingCenterController
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();
        private List<ExtendedSelectListItem> areasList = HeadHunterHelper.GetHHSelectList();
        // GET: /Qualification/
        public ActionResult Index()
        {
            return View(db.Qualifications.ToList());
        }

        // GET: /Qualification/ChildNodes/5
        public JsonResult ChildNodes(int? id)
        {
            var items = db.Qualifications.Where(a => a.ParentId == id);
            List<object> res = new List<object>();
            if (id == 0)
            {
                res.Add(new
                {
                    id = 0,
                    text = "root",
                    parent = "#",
                    state = new { opened = false }
                });
            }
            foreach (var item in items)
            {
                res.Add(new
                {
                    id = item.Id,
                    text = item.Title,
                    parent = item.ParentId.ToString(),
                    state = new { opened = false },
                    children = true
                });
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        // GET: /Qualification/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }

            return PartialView(qualification);
        }

        // GET: /Qualification/Create
        public ActionResult Create(int id)
        {
            ViewData["ParentId"] = id;
            ViewBag.AreasSelectList = areasList;
            return PartialView();
        }

        // POST: /Qualification/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Type,ParentId,HeadHunterId,HeadHunterName,HeadHunterKeys")] Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                db.Qualifications.Add(qualification);
                db.SaveChanges();
                return PartialView("Details", qualification);
            }
            return PartialView(qualification);
        }

        // GET: /Qualification/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreasSelectList = areasList;
            return PartialView(qualification);
        }

        // POST: /Qualification/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Type,ParentId,HeadHunterId,HeadHunterName,HeadHunterKeys")] Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qualification).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("Details", qualification);
            }
            return PartialView(qualification);
        }

        // GET: /Qualification/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return PartialView(qualification);
        }

        // POST: /Qualification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Qualification qualification = db.Qualifications.Find(id);
            db.Qualifications.Remove(qualification);
            db.SaveChanges();
            if (qualification.ParentId != 0)
            {
                return RedirectToAction("Details", new { id = qualification.ParentId });
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
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

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
    public class TeachersController : RoutingTrainingCenterController
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();

        // GET: /Teacher/
        public ActionResult Index()
        {
            var teacher = db.Teachers.ToList();
            var tcUrl = RouteData.Values["tc"];
            var tc = db.TrainingCenters.SingleOrDefault(a => a.Url == tcUrl);
            var trainingCenterTeachers = db.TrainingCenterTeachers.Where(a => a.IdTrainingCenter == tc.Id).Select(b => b.Teacher);
            return View(trainingCenterTeachers);
        }

        // GET: /Teacher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: /Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Teacher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,Patronymic,Email,Description,Phone")] Teacher teacher, HttpPostedFileBase uploadImage)
        {
            var tcUrl = RouteData.Values["tc"];
            var tc = db.TrainingCenters.SingleOrDefault(a => a.Url == tcUrl);

            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                // установка массива байтов
                teacher.Image = imageData;

                db.Users.Add(teacher);
                db.SaveChanges();
                var teach = db.Teachers.SingleOrDefault(a => a.Email == teacher.Email);
                TrainingCenterTeacher trainingCenterTeacher = new TrainingCenterTeacher() { IdTeacher = teach.Id, IdTrainingCenter = tc.Id };
                db.TrainingCenterTeachers.Add(trainingCenterTeacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        [OutputCache(Duration=3000, VaryByParam="id")]
        public ActionResult Image(int id)
        {
            byte[] imageData = db.Teachers.SingleOrDefault(a => a.Id == id).Image;
            return File(imageData, "image/jpeg");
        }

        // GET: /Teacher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: /Teacher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,Patronymic,Email,Description,Phone")] Teacher teacher, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                var old =  db.Teachers.Single(a => a.Id == teacher.Id);
                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    // считываем переданный файл в массив байтов
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    // установка массива байтов
                    old.Image = imageData;
                }
                old.Description = teacher.Description;
                old.Email = teacher.Email;
                old.FirstName = teacher.FirstName;
                old.LastName = teacher.LastName;
                old.Patronymic = teacher.Patronymic;
                old.Phone = teacher.Phone;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        // GET: /Teacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: /Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Users.Remove(teacher);
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

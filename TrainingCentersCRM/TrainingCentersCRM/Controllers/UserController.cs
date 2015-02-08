using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TrainingCentersCRM.Models;

namespace TrainingCentersCRM.Controllers
{
    public class UserController : RoutingTrainingCenterController
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();

        // GET: /User/
        public ActionResult Index()
        {
            var aspnetusers = db.AspNetUsers.Include(a => a.User);
            return View(aspnetusers.ToList());
        }

        // GET: /User/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspnetuser = db.AspNetUsers.SingleOrDefault(a => a.Id == id);


            UserMan user = new UserMan();
            user.UserName = aspnetuser.UserName;

            Student student = db.Students.SingleOrDefault(a => a.Id == aspnetuser.UserId);
            Teacher teacher = db.Teachers.SingleOrDefault(a => a.Id == aspnetuser.UserId);
            if (student != null)
            {
                user.DateOfBirth = "" + student.DateOfBirth;
                user.Description = student.Description;
                user.Email = student.Email;
                user.FirstName = student.FirstName;
                user.LastName = student.LastName;
                user.Patronymic = student.Patronymic;
                user.PassportData = student.PassportData;
                user.Id = student.Id;
            }
            else if (teacher != null)
            {
                user.Description = teacher.Description;
                user.Email = teacher.Email;
                user.FirstName = teacher.FirstName;
                user.LastName = teacher.LastName;
                user.Patronymic = teacher.Patronymic;
                user.PassportData = teacher.Phone;
                user.Id = teacher.Id;
            }
            else
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,Password,TypeUser,LastName,FirstName,Patronymic,Email,Description,Phone,DateOfBirth,PassportData")] UserMan user)
        {
            if (ModelState.IsValid)
            {
                var anu = new RegisterViewModel();
                anu.UserName = user.UserName;
                anu.Password = user.Password;
                anu.ConfirmPassword = user.Password;

                if (user.TypeUser == "teacher")
                {
                    var teacher = new Teacher();
                    teacher.Description = user.Description;
                    teacher.Email = user.Email;
                    teacher.FirstName = user.FirstName;
                    teacher.LastName = user.LastName;
                    teacher.Patronymic = user.Patronymic;

                    teacher.Phone = user.Phone;

                    db.Teachers.Add(teacher);
                    db.SaveChanges();

                    var teach = db.Teachers.SingleOrDefault(a => a.Email == user.Email);
                    anu.UserId = teach.Id;
                }
                if (user.TypeUser == "student")
                {
                    var student = new Student();
                    student.Description = user.Description;
                    student.Email = user.Email;
                    student.FirstName = user.FirstName;
                    student.LastName = user.LastName;
                    student.Patronymic = user.Patronymic;

                    student.DateOfBirth = Int32.Parse(user.DateOfBirth);
                    student.PassportData = user.PassportData;

                    db.Students.Add(student);
                    db.SaveChanges();

                    var stud = db.Students.SingleOrDefault(a => a.Email == user.Email);
                    anu.UserId = stud.Id;
                }

                AccountController q = new AccountController();
                q.Register(anu);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspnetuser = db.AspNetUsers.Find(id);
            UserManEditing user = new UserManEditing();
            user.UserName = aspnetuser.UserName;

            Student student = db.Students.SingleOrDefault(a => a.Id == aspnetuser.UserId);
            Teacher teacher = db.Teachers.SingleOrDefault(a => a.Id == aspnetuser.UserId);
            if (student != null)
            {
                user.DateOfBirth = "" + student.DateOfBirth;
                user.Description = student.Description;
                user.Email = student.Email;
                user.FirstName = student.FirstName;
                user.LastName = student.LastName;
                user.Patronymic = student.Patronymic;
                user.PassportData = student.PassportData;
                user.Id = student.Id;
                user.TypeUser = "student";
            }
            else if (teacher != null)
            {
                user.Description = teacher.Description;
                user.Email = teacher.Email;
                user.FirstName = teacher.FirstName;
                user.LastName = teacher.LastName;
                user.Patronymic = teacher.Patronymic;
                user.PassportData = teacher.Phone;
                user.Id = teacher.Id;
                user.TypeUser = "teacher";
            }
            else
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserName,Password,TypeUser,LastName,FirstName,Patronymic,Email,Description,Phone,DateOfBirth,PassportData")] UserManEditing user)
        {
            if (ModelState.IsValid)
            {
                var aspNetUser = db.AspNetUsers.SingleOrDefault(a => a.UserName == user.UserName);

                if (user.TypeUser == "teacher")
                {
                    var teacher = db.Teachers.SingleOrDefault(a => a.Id == aspNetUser.UserId);
                    teacher.Description = user.Description;
                    teacher.Email = user.Email;
                    teacher.FirstName = user.FirstName;
                    teacher.LastName = user.LastName;
                    teacher.Patronymic = user.Patronymic;
                    teacher.Phone = user.Phone;
                    db.Entry(teacher).State = EntityState.Modified;
                    db.SaveChanges();
                }
                if (user.TypeUser == "student")
                {
                    var student = db.Students.SingleOrDefault(a => a.Id == aspNetUser.UserId);
                    student.Description = user.Description;
                    student.Email = user.Email;
                    student.FirstName = user.FirstName;
                    student.LastName = user.LastName;
                    student.Patronymic = user.Patronymic;
                    student.DateOfBirth = Int32.Parse(user.DateOfBirth);
                    student.PassportData = user.PassportData;;
                    db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspnetuser = db.AspNetUsers.Find(id);
            if (aspnetuser == null)
            {
                return HttpNotFound();
            }
            return View(aspnetuser);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AspNetUser aspnetuser = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(aspnetuser);
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

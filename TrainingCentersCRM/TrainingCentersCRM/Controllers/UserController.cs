using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrainingCentersCRM.Models;

namespace TrainingCentersCRM.Controllers
{
    public class UserController : RoutingTrainingCenterController
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();
        private ApplicationDbContext appDb = new ApplicationDbContext();

        // GET: /User/
        public ActionResult Index()
        {
            var users = appDb.Users;
            return View(users.ToList());
        }

        public ActionResult Teachers()
        {
            return View();
        }

        // GET: /User/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser aspnetuser = appDb.Users.SingleOrDefault(a => a.Id == id);


            UserMan user = new UserMan();
            user.UserName = aspnetuser.UserName;

            Student student = db.Students.SingleOrDefault(a => a.AspNetUserId == aspnetuser.Id);
            Teacher teacher = db.Teachers.SingleOrDefault(a => a.AspNetUserId == aspnetuser.Id);
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
        public async Task<ActionResult> Create([Bind(Include = "UserName,Password,TypeUser,LastName,FirstName,Patronymic,Email,Description,Phone,DateOfBirth,PassportData")] UserMan user)
        {
            if (ModelState.IsValid)
            {
                var tcUrl = RouteData.Values["tc"];
                var tc = db.TrainingCenters.SingleOrDefault(a => a.Url == tcUrl);

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
                    //anu.UserId = teach.Id;

                    TrainingCenterTeacher trainingCenterTeacher = new TrainingCenterTeacher() { IdTeacher = teach.Id, IdTrainingCenter = tc.Id };
                    db.TrainingCenterTeachers.Add(trainingCenterTeacher);
                    db.SaveChanges();
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
                    //anu.UserId = stud.Id;
                }

                AccountController q = new AccountController();
                await q.Register(anu);

                var savedUser = db.Users.SingleOrDefault(a => a.Email == user.Email);
                var savedAspNetUser = appDb.Users.SingleOrDefault(a => a.UserName == user.UserName);

                savedUser.AspNetUserId = savedAspNetUser.Id;

                db.Entry(savedUser).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser aspnetuser = appDb.Users.Find(id);
            UserManEditing user = new UserManEditing();
            user.UserName = aspnetuser.UserName;

            Student student = db.Students.SingleOrDefault(a => a.AspNetUserId == aspnetuser.Id);
            Teacher teacher = db.Teachers.SingleOrDefault(a => a.AspNetUserId == aspnetuser.Id);
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
        public ActionResult Edit([Bind(Include = "AspNetUserId,UserName,Password,TypeUser,LastName,FirstName,Patronymic,Email,Description,Phone,DateOfBirth,PassportData")] UserManEditing user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser aspNetUser = appDb.Users.SingleOrDefault(a => a.Id == user.AspNetUserId);

                if (user.TypeUser == "teacher")
                {
                    var teacher = db.Teachers.SingleOrDefault(a => a.AspNetUserId == aspNetUser.Id);
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
                    var student = db.Students.SingleOrDefault(a => a.AspNetUserId == aspNetUser.Id);
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
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser aspnetuser = appDb.Users.Find(id);
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
            ApplicationUser aspnetuser = appDb.Users.Find(id);
            appDb.Users.Remove(aspnetuser);
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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingCentersCRM.Models;

namespace TrainingCentersCRM.Controllers
{
    public class UserMan
    {
        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Тип")]
        public string TypeUser { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Display(Name = "E-mail")]
        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        public string Email { get; set; }

        [StringLength(1023, ErrorMessage = "Длина строки должна быть менее 1024 символов")]
        [Display(Name = "Дополнительная информация")]
        public string Description { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Дата рождения")]
        public string DateOfBirth { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна быть менее 256 символов")]
        [Display(Name = "Паспортные данные")]
        public string PassportData { get; set; }
    }

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
        public ActionResult Details(int? id)
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

        // GET: /User/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.Users, "Id", "LastName");
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

            //ViewBag.UserId = new SelectList(db.Users, "Id", "LastName", user.AspNetUser.UserId);
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
            if (aspnetuser == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserId = new SelectList(db.Users, "Id", "LastName", aspnetuser.UserId);
            return View(aspnetuser);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserName,Password,TypeUser,LastName,FirstName,Patronymic,Email,Description,Phone,DateOfBirth,PassportData")] UserMan user)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(userteacher).State = EntityState.Modified;
                var anu = new AspNetUser();
                anu.UserName = user.UserName;
                anu.PasswordHash = user.Password;

                var teacher = new Teacher();
                teacher.Description = user.Description;
                teacher.Email = user.Email;
                teacher.FirstName = user.FirstName;
                teacher.LastName = user.LastName;
                teacher.Patronymic = user.Patronymic;
                teacher.Phone = user.Phone;

                db.Teachers.Add(teacher);


                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UserId = new SelectList(db.Users, "Id", "LastName", userteacher.AspNetUser.UserId);
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

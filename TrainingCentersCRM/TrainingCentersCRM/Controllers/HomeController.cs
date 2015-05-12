using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingCentersCRM.Models;
using TrainingCentersCRM.Infrastructure;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TrainingCentersCRM.Controllers
{
    public class HomeController : Controller
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();


        public ActionResult Index()
        {
            //db.TrainingCenters.Add(new TrainingCenter { Url = "empty" });
            //db.SaveChanges();
            ViewBag.TrainingCenter = TCHelper.GetCurrentTc();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.teachers = db.Teachers.Count();
            ViewBag.centers = db.TrainingCenters.Count();
            ViewBag.courses = db.TrainingCourses.Count();
            return View();
        }

        //[TCAuthorize(Roles = "admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]
        public ActionResult UploadFromEditor(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            string url; // url to return
            string message; // message to display (optional)

            using (Stream file = System.IO.File.Create(Path.Combine(Server.MapPath("~/Content/uploads"), upload.FileName)))
            {
                upload.InputStream.CopyTo(file);
            }

            url = Url.Content("~/Content/uploads/" + upload.FileName);

            // passing message success/failure
            message = "";

            // since it is an ajax request it requires this string
            string output = @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" +
              url + "\", \"" + message + "\");</script></body></html>";
            return Content(output);
        }

        public ActionResult ImageBrowser()
        {
            var images = new List<string>();
            foreach (string image in Directory.GetFiles(Server.MapPath("~/Content/uploads")))
            {
                images.Add(new FileInfo(image).Name);
            }

            return View(images);
        }
    }
}
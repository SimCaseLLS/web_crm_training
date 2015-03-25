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
                return View();
        }

        public ActionResult Contact()
        {

            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
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
            if (TCHelper.GetCurrentTCName() == "" || TCHelper.GetCurrentTCName() == "empty")
                return View();
            else
                return View("Index", "TrainingCenterLayout");
        }

        public ActionResult About()
        {
            if (TCHelper.GetCurrentTCName() == "" || TCHelper.GetCurrentTCName() == "empty")
                return View();
            else
                return View("About", "TrainingCenterLayout");
        }

        public ActionResult Contact()
        {

            ViewBag.Message = "Your contact page.";

            if (TCHelper.GetCurrentTCName() == "" || TCHelper.GetCurrentTCName() == "empty")
                return View();
            else
                return View("Contact", "TrainingCenterLayout");
        }
    }
}
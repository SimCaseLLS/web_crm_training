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
            var areas = HeadHunterHelper.GetHHList();
            var areas_list = areas.Select(a => new ExtendedSelectListItem
            {
                Selected = false,
                Value = a.Id,
                Text = a.Name,
                HtmlAttributes = new { data_specializations = String.Join("", a.Specializations.Select(
                    s => String.Format("<option value = '{0}'> {1} </option>", s.Id, s.Name))) }
            }).ToList();
            ViewBag.Areas = areas_list;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
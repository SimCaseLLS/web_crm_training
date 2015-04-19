using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Xml.Serialization;
using TrainingCentersCRM.Models.Moodle;

namespace TrainingCentersCRM.Controllers
{
    public class MoodleController : RoutingTrainingCenterController
    {

        // GET: Moodle
        /// <summary>
        /// Генерация списка курсов для учебного центра из Moodle
        /// </summary>
        /// <param name="id">Id категории в Moodle (опционально)</param>
        /// <returns></returns>
        public ActionResult Index(string key)
        {
            // core_course_get_courses
            // core_course_get_categories
            var res = MoodleRequestManager.InvokeMethod("core_course_get_categories", HttpContext);
            SingleResult root;
            if (trainingCenter != null)
                key = trainingCenter.Url;
            if (key == null)
            {
                root = new SingleResult()
                {
                    KeyValues = new Key[] 
                    {
                        new Key() { Name = "name", Value="Все курсы"},
                        new Key() { Name = "id", Value = "0"},
                        new Key() { Name = "shortname", Value = "Все курсы"}
                    }
                };
            }
            else
                root = res.MultiValue.Where(a => a["idnumber"] == key).Single();
            MoodleCategory cat = new MoodleCategory(root, res.MultiValue, HttpContext);
            //var model = MoodleCategory.BuildCategories(root, res.MultiValue, HttpContext);
            return View(cat);
        }

        public ActionResult CourseTeachers(int courseid)
        {
            return View();
        }

        public ActionResult CenterTeachers(int centerid)
        { 
            return View();
        }

        public ActionResult Category(MoodleCategory cat)
        {
            ViewBag.MoodleAddress = ConfigurationManager.AppSettings["MoodleBaseAddress"];
            return View(cat);
        }

        public string TestSer()
        {
            var res = new Models.Moodle.MoodleRestResponse
            {
                MultiValue = new SingleResult[] 
                {
                    new SingleResult
                    {  
                        KeyValues = new Key[] 
                        {
                            new Key { Name = "name1", Value = "val1"},
                            new Key { Name = "name2", Value = "val2"}
                        }

                    },
                    new SingleResult
                    {  
                        KeyValues = new Key[] 
                        {
                            new Key { Name = "name3", Value = "val3"},
                            new Key { Name = "name4", Value = "val4"}
                        }
                    }  
                }
            };
            XmlSerializer ser = new XmlSerializer(typeof(MoodleRestResponse));
            HttpContext.Response.ContentType = "text/xml";
            MemoryStream ms = new MemoryStream();
            ser.Serialize(ms, res);

            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}
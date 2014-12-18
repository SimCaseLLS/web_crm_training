using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TrainingCentersCRM.Models;

namespace TrainingCentersCRM.Infrastructure
{
    public class HeadHunterHelper
    {
        public static List<HHProffessionalArea> GetHHList() {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("User-Agent", "MyApp/1.2 (haudvd@gmail.com)");
            webClient.Encoding = Encoding.UTF8;

            string response = webClient.DownloadString("https://api.hh.ru/specializations/");

            var specs = JsonConvert.DeserializeObject<List<HHProffessionalArea>>(response);
            // var i = specs.Where(t => t.Name == "Информационные технологии, интернет, телеком").First();
            return specs;
            /*foreach (var spec in specs)
            {
                areas.Add
            }
            new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Selected = false, Text = string.Empty, Value = "-1"},
                new SelectListItem { Selected = false, Text = "Homeowner", Value = ((int)UserType.Homeowner).ToString()},
                new SelectListItem { Selected = false, Text = "Contractor", Value = ((int)UserType.Contractor).ToString()},
            });*/
        }
    }
}
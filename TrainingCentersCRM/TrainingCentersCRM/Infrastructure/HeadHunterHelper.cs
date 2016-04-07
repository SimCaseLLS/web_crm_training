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
            webClient.Headers.Add("User-Agent", "MyApp/1.3 (haudvd@gmail.com)");
            webClient.Encoding = Encoding.UTF8;

            try
            {
                string response = webClient.DownloadString("https://api.hh.ru/specializations/");

                var specs = JsonConvert.DeserializeObject<List<HHProffessionalArea>>(response);
                // var i = specs.Where(t => t.Name == "Информационные технологии, интернет, телеком").First();
                return specs;
            }
            catch (Exception e)
            {
                return new List<HHProffessionalArea>();
            }
        }

        public static List<ExtendedSelectListItem> GetHHSelectList()
        {
            var areas = HeadHunterHelper.GetHHList();
            var areas_list = areas.Select(a => new ExtendedSelectListItem
            {
                Selected = false,
                Value = a.Id,
                Text = a.Name,
                HtmlAttributes = new
                {
                    data_specializations = String.Join("", a.Specializations.Select(
                        s => String.Format("<option value = '{0}'> {1} </option>", s.Id, s.Name)))
                }
            }).ToList();
            return areas_list;
        }
    }
}
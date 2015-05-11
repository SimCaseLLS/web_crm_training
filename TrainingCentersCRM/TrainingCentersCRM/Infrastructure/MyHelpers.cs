using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingCentersCRM.Infrastructure;

namespace TrainingCentersCRM
{
    public static class MyHelpers
    {
        public static MvcHtmlString Menu()
        {
            var IdTrainingCenter = TCHelper.GetCurrentTCName();
            // TrainingCentersCRM.Models.ApplicationDbContext db = new Models.ApplicationDbContext();
            TrainingCentersCRM.Models.TrainingCentersDBEntities db1 = new Models.TrainingCentersDBEntities();

            //Rec_menu(0, db1);
            return new MvcHtmlString(Rec_menu(0, db1, IdTrainingCenter));
        }

        static string Rec_menu(int Parent_ID, Models.TrainingCentersDBEntities db, string IdTrainingCenter, string curDropdownId = null)
        {
            string str = "";
            TagBuilder ul = new TagBuilder("ul");
            if (curDropdownId != null)
            {
                // если этот пункт меню - dropdown
                ul.MergeAttribute("id", curDropdownId);
                ul.MergeAttribute("class", "f-dropdown");
                ul.MergeAttribute("data-dropdown-content", "");
                ul.MergeAttribute("aria-hidden", "true");
            }
            else
            {
                // если этот пункт меню - не dropdown
                ul.MergeAttribute("class", "clear-fix navigation");
            }

            IQueryable<TrainingCentersCRM.Models.Menu> SaM;
            if (IdTrainingCenter == "empty" || IdTrainingCenter == null)
            {
                SaM = db.Menu.Where(p => p.IdTrainingCenter == "empty" || p.IdTrainingCenter == "other").OrderBy(a => a.Ord_Id);
                if (Parent_ID == 0)
                {
                    ul.InnerHtml += TcDropdown(db);
                }
            }
            else
            {
                if (Parent_ID == 0)
                {
                    var tclocal = db.TrainingCenters.SingleOrDefault(a => a.Url == IdTrainingCenter);
                    ul.InnerHtml += "<li><a href='/" + IdTrainingCenter + "/TrainingCenter/Details/" + tclocal.Id + "'>" + tclocal.Organization + "</a></li>";
                }
                SaM = db.Menu.Where(p => p.IdTrainingCenter == IdTrainingCenter || p.IdTrainingCenter == "other" || p.IdTrainingCenter == "empty").OrderBy(a => a.Ord_Id);
            }

            var first_sam = SaM.Where(p => p.Parent_Id == Parent_ID).OrderBy(a => a.Ord_Id);
            foreach (var samp in first_sam)
            {
                if (((IdTrainingCenter == null || IdTrainingCenter == "empty") && samp.IdTrainingCenter == "other" && samp.NotBindInTrainingCenter) ||
                     (IdTrainingCenter != null && IdTrainingCenter != "empty" && samp.IdTrainingCenter == "empty" && !samp.NotBindInTrainingCenter))
                    continue;
                string str_temp = "";
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                string icon = "";
                if (SaM.Where(p => p.Parent_Id == samp.Id).Count() > 0)
                {
                    // текущий элемент имеет dropdown
                    icon = "<i class='fa fa-caret-down'></i>";
                    a.MergeAttribute("aria-expanded", "false");
                    var newDropdownId = "dropdown" + IdTrainingCenter + samp.Id.ToString();
                    a.MergeAttribute("data-dropdown", newDropdownId);
                    a.MergeAttribute("aria-controls", newDropdownId);
                    str_temp = Rec_menu(samp.Id, db, IdTrainingCenter, newDropdownId);
                }
                a.MergeAttribute("title", samp.Description);
                a.InnerHtml = samp.Title + icon;
                if (samp.NotBindInTrainingCenter && samp.IdTrainingCenter == "empty")
                {
                    a.MergeAttribute("href", samp.Link);
                }
                else
                {
                    a.MergeAttribute("href", "/" + IdTrainingCenter + samp.Link);
                }
                li.InnerHtml = a.ToString() + str_temp;
                str_temp = li.ToString();
                str += str_temp;
            }
            ul.InnerHtml += str;
            return ul.ToString();
        }


        public static string GetSiteUrl()
        {
            string url = string.Empty;
            HttpRequest request = HttpContext.Current.Request;

            if (request.IsSecureConnection)
                url = "https://";
            else
                url = "http://";

            url += request["HTTP_HOST"] + "/";

            return url;
        }

        static string TcDropdown(Models.TrainingCentersDBEntities db)
        {
            var tcs = db.TrainingCenters.Where(a => !a.Url.Equals("empty"));
            var html = "<li><a href='#!' data-dropdown='TrainingCentersDropdown' aria-controls='TrainingCentersDropdown' aria-expanded='false'>Учебные центры<i class='fa fa-caret-down'></i></a></li>";
            TagBuilder ul = new TagBuilder("ul");
            ul.MergeAttribute("id", "TrainingCentersDropdown");
            ul.MergeAttribute("class", "f-dropdown");
            ul.MergeAttribute("data-dropdown-content", "");
            ul.MergeAttribute("data-options", "is_hover:true; hover_timeout:5000");
            foreach (var tc in tcs)
            {
                ul.InnerHtml += "<li><a href='/" + tc.Url + "/TrainingCenter/Details/" + tc.Id + "'>" + tc.Organization + "</a></li>";
            }
            html += ul.ToString();
            return html;
        }
    }
}
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
                ul.MergeAttribute("class", "dropdown-content");
            }
            else
            {
                // если этот пункт меню - не dropdown
                ul.MergeAttribute("class", "left side-nav");
            }

            IQueryable<TrainingCentersCRM.Models.Menu> SaM;
            if (IdTrainingCenter.Equals("empty"))
            {
                SaM = db.Menu.Where(p => p.IdTrainingCenter == IdTrainingCenter);
                if (Parent_ID == 0)
                {
                    ul.InnerHtml += TcDropdown(db);
                }
            }
            else
                SaM = db.Menu.Where(p => p.IdTrainingCenter == IdTrainingCenter || p.IdTrainingCenter == "other"); 

            var first_sam = SaM.Where(p => p.Parent_Id == Parent_ID);
            foreach (var samp in first_sam) {
                string str_temp = "";
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                a.MergeAttribute("title", samp.Description);
                a.InnerHtml = samp.Title;
                if (SaM.Where(p => p.Parent_Id == samp.Ord_Id).Count() > 0)
                {
                    // текущий элемент имеет dropdown
                    a.MergeAttribute("class", "dropdown-button");
                    var newDropdownId = "dropdown" + IdTrainingCenter + samp.Ord_Id.ToString();
                    a.MergeAttribute("data-activates", newDropdownId);
                    str_temp = Rec_menu(samp.Ord_Id, db, IdTrainingCenter, newDropdownId);
                    a.InnerHtml += "<i class=\"mdi-navigation-arrow-drop-down right\"></i>";
                }
                else
                {
                    if (samp.NotBindInTrainingCenter)
                    {
                        a.MergeAttribute("href", samp.Link);
                    }
                    else
                    {
                        a.MergeAttribute("href", "/" + IdTrainingCenter + samp.Link);
                    }
                }
                li.InnerHtml = a.ToString()+str_temp;
                str_temp = li.ToString();
                str += str_temp;
            }
            ul.InnerHtml += str;

            return ul.ToString();
        }

        static string TcDropdown(Models.TrainingCentersDBEntities db)
        {
            var tcs = db.TrainingCenters.Where(a => a.Url != "empty").ToList();
            var html = "<li><a class='dropdown-button' href='#!' data-activates='TrainingCentersDropdown'>Учебные центры<i class='mdi-navigation-arrow-drop-down right'></i></a></li>";
                    
            TagBuilder ul = new TagBuilder("ul");
            ul.MergeAttribute("id", "TrainingCentersDropdown");
            ul.MergeAttribute("class", "dropdown-content");
            foreach (var tc in tcs)
            {
                ul.InnerHtml += "<li><a href='/" + tc.Url + "'>" + tc.Organization + "</a></li>";
            }
            html += ul.ToString();
            return html;
        }
    }
}
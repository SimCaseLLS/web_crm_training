using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainingCentersCRM
{
    public static class MyHelpers
    {
        public static MvcHtmlString Menu(string IdTrainingCenter)
        {
           // TrainingCentersCRM.Models.ApplicationDbContext db = new Models.ApplicationDbContext();
            TrainingCentersCRM.Models.TrainingCentersDBEntities db1 = new Models.TrainingCentersDBEntities();
           
                //Rec_menu(0, db1);
            return new MvcHtmlString(Rec_menu(0, db1, IdTrainingCenter));
        }

        static string Rec_menu(int Parent_ID, Models.TrainingCentersDBEntities db, string IdTrainingCenter)
        {
            string str = "";
            var sampling = db.Menu.Where(p => p.IdTrainingCenter == IdTrainingCenter).Where(p => p.Parent_Id == Parent_ID); 
            TagBuilder ul = new TagBuilder("ul");
            foreach (var samp in sampling) {
                string str_temp = "";
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                a.MergeAttribute("href",samp.Link);
                a.MergeAttribute("title", samp.Description);
                a.InnerHtml = samp.Title;
                if (db.Menu.Where(p => p.IdTrainingCenter == IdTrainingCenter).Where(p => p.Parent_Id == samp.Ord_Id).Count() > 0)
                    str_temp = Rec_menu(samp.Ord_Id, db, IdTrainingCenter);
                li.InnerHtml = a.ToString()+str_temp;
                str_temp = li.ToString();
                str += str_temp;
            }
            ul.MergeAttribute("class", "level 1");
            ul.InnerHtml = str;

            return ul.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingCentersCRM.Models;

namespace TrainingCentersCRM.Infrastructure
{
    public static class TCHelper
    {
        public static string GetCurrentTCName()
        {
            var name = HttpContext.Current.Request.RequestContext.RouteData.Values["tc"].ToString();
            if (name == "") name = "empty";
            return name;
        }

        public static TrainingCenter GetCurrentTc(TrainingCentersDBEntities db)
        {
            return getTc(GetCurrentTCName(), db);
        }
        public static TrainingCenter GetCurrentTc()
        {
            TrainingCentersDBEntities db = new TrainingCentersDBEntities();
            return getTc(GetCurrentTCName(), db);
        }
//@HttpContext.Current.Request.RequestContext.RouteData.Values["tc"].ToString() + 
        [HandleError]
        public static TrainingCenter getTc(string tcUrl, TrainingCentersDBEntities db) {
            try
            {
                TrainingCenter tc = db.TrainingCenters.Where(a => a.Url == tcUrl).ToList().First();
                if (tc == null)
                {
                    throw new HttpException(404, "NotFound");
                }
                return tc;
            }
            catch (Exception ex)
            {
                throw new HttpException(404, "NotFound");
            }
        }

        public static string TruncateString(string text)
        {
            if (text.Length > 200)
                return text.Substring(0, 200) + "...";
            else
                return text;
        }
    }
}
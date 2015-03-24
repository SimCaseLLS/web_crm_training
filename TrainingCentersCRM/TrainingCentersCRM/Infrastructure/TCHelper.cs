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
            return HttpContext.Current.Request.RequestContext.RouteData.Values["tc"].ToString();
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
            TrainingCenter tc = db.TrainingCenters.Where(a => a.Url == tcUrl).ToList().First();
            if(tc == null) {
                throw new HttpException(404, "NotFound");
            }
            return tc;
        } 
    }
}
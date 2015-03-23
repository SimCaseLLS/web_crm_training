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

        public static IQueryable<TrainingCenter> GetCurrentTc(TrainingCentersDBEntities db)
        {
            return getTc(GetCurrentTCName(), db);
        }
//@HttpContext.Current.Request.RequestContext.RouteData.Values["tc"].ToString() + 
        [HandleError]
        public static IQueryable<TrainingCenter> getTc(string tcUrl, TrainingCentersDBEntities db) {
            var tc = db.TrainingCenters.Where(a => a.Url == tcUrl); 
            if(tc.Count() == 0) {
                throw new HttpException(404, "NotFound");
            }
            return tc;
        } 
    }
}
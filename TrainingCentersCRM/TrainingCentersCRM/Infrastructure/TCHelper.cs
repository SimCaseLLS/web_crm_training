﻿using System;
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
            var a = HttpContext.Current.Request.Url.AbsolutePath;// /TESTERS/Default6.aspx
            var pathArray = a.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            // TODO Нужны логи сюда!
            if (pathArray.Length < 2) throw new ArgumentException("Path not have Trenning Center slug(aka mini name in url)");
            if (pathArray[0] != "TC") throw new ArgumentException("Path not have /TC/");
            return pathArray[1];
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
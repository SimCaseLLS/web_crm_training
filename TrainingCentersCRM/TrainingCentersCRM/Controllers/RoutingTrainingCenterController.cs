using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingCentersCRM.Infrastructure;
using TrainingCentersCRM.Models;
namespace TrainingCentersCRM.Controllers
{
    public class RoutingTrainingCenterController : Controller
    {
        private TrainingCentersDBEntities db = new TrainingCentersDBEntities();
        public TrainingCenter trainingCenter;
        protected override void OnActionExecuting(ActionExecutingContext ctx)
        {
            trainingCenter = TCHelper.getTc(RouteData.Values["tc"].ToString(), db);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TrainingCentersCRM.Models;

namespace TrainingCentersCRM
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            Application["PageSize"] = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<TrainingCentersDBEntities>());
            if (ConfigurationManager.AppSettings["EnableLucene"] == "1")
            {

            }
        }

        void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();
            Logger.Error("Error", error);
            //We clear the response
            Response.Clear();

            //We check if we have an AJAX request and return JSON in this case
            if (IsAjaxRequest())
            {
                Response.Write("Your JSON here");
            }
            else
            {
                //We don`t have an AJAX request, redirect to an error page
                //Response.Redirect("/Error404.htm");
            }
            //We clear the error
            //Server.ClearError();
        }

        //This method checks if we have an AJAX request or not
        private bool IsAjaxRequest()
        {
            //The easy way
            bool isAjaxRequest = (Request["X-Requested-With"] == "XMLHttpRequest")
            || ((Request.Headers != null)
            && (Request.Headers["X-Requested-With"] == "XMLHttpRequest"));

            //If we are not sure that we have an AJAX request or that we have to return JSON 
            //we fall back to Reflection
            if (!isAjaxRequest)
            {
                try
                {
                    //The controller and action
                    string controllerName = Request.RequestContext.
                                            RouteData.Values["controller"].ToString();
                    string actionName = Request.RequestContext.
                                        RouteData.Values["action"].ToString();

                    //We create a controller instance
                    DefaultControllerFactory controllerFactory = new DefaultControllerFactory();
                    Controller controller = controllerFactory.CreateController(
                    Request.RequestContext, controllerName) as Controller;

                    //We get the controller actions
                    ReflectedControllerDescriptor controllerDescriptor =
                    new ReflectedControllerDescriptor(controller.GetType());
                    ActionDescriptor[] controllerActions =
                    controllerDescriptor.GetCanonicalActions();

                    //We search for our action
                    foreach (ReflectedActionDescriptor actionDescriptor in controllerActions)
                    {
                        if (actionDescriptor.ActionName.ToUpper().Equals(actionName.ToUpper()))
                        {
                            //If the action returns JsonResult then we have an AJAX request
                            if (actionDescriptor.MethodInfo.ReturnType
                            .Equals(typeof(JsonResult)))
                                return true;
                        }
                    }
                }
                catch
                {

                }
            }

            return isAjaxRequest;
        }
    }
}

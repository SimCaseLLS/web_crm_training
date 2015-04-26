using System.Web;
using System.Web.Optimization;

namespace TrainingCentersCRM
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/foundation.css",
                      "~/Content/header.css",
                      "~/Content/footer.css",
                      "~/Content/main.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.min.css"));
            bundles.Add(new ScriptBundle("~/bundles/jstree").Include(
                        "~/Scripts/jstree.js"));
            bundles.Add(new ScriptBundle("~/bundles/foundation").Include(
                      "~/Scripts/foundation.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/coursedetails").Include(
                        "~/Scripts/CourseDetails.js"));

        }
    }
}

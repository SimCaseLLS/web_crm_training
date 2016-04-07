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
<<<<<<< HEAD
=======
            bundles.Add(new ScriptBundle("~/bundles/jqueryform").Include(
                        "~/Scripts/jquery.form.min.js"));
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
<<<<<<< HEAD

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/themes/default/style.css"));
            bundles.Add(new ScriptBundle("~/bundles/jstree").Include(
                        "~/Scripts/jstree.js"));
=======
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/foundation.css",
                      "~/Content/themes/default/style.min.css",
                      "~/Content/header.css",
                      "~/Content/footer.css",
                      "~/Content/main.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/foundation-datepicker.css"));
            bundles.Add(new ScriptBundle("~/bundles/jstree").Include(
                        "~/Scripts/jstree.js"));
            bundles.Add(new ScriptBundle("~/bundles/foundation").Include(
                      "~/Scripts/foundation.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/date-picker").Include(
                      "~/Scripts/foundation-datepicker.js"));
            bundles.Add(new ScriptBundle("~/bundles/coursedetails").Include(
                        "~/Scripts/CourseDetails.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-ui_js").Include(
                        "~/Scripts/jquery-ui/jquery-ui.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-ui_css").Include(
                        "~/Scripts/jquery-ui/jquery-ui.css"));

>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        }
    }
}

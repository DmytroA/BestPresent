using System.Web;
using System.Web.Optimization;

namespace TourSite2
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

          

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr"));

            //bundles.Add(new ScriptBundle("~/bundles/script")
            //    .Include("~/Scripts/jquery-2.1.4.js")
            //            .Include("~/Scripts/jquery-ui.js")
            //            .Include("~/Scripts/tabslide.js")
            //            .Include("~/Scripts/jquery.searcher.js")
            //            .Include("~/Scripts/bootstrap.js")
            //            .Include("~/Scripts/jquery.mousewheel-3.0.6.pack.js")
            //            .Include("~/Scripts/respond.js")
            //            .Include("~/Scripts/scroll.js")
            //            .Include("~/Scripts/datatables.js"));

        //    bundles.Add(new StyleBundle("~/Content/css")
        //            .Include("~/Content/site.css")  /* не перепутайте порядок */
        //            .Include("~/Content/bootstrap*")
        //            .Include("~/Content/jquery-ui.css")
        //            .Include("~/Content/jquery.fancybox.css")
        //            .Include("~/Content/datatables.css"));
        }
    }
}
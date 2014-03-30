using System.Web.Optimization;

namespace SurfStoreApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/styles/css")
                .Include("~/content/css/bootstrap.css", "~/content/css/bootstrap-responsive.css"));

            bundles.Add(new ScriptBundle("~/scripts/js")
                .Include("~/Scripts/jquery-1.7.2.js", "~/Scripts/bootstrap.alert.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
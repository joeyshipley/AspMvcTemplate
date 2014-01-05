using System.Web.Optimization;

namespace ThinkCraft.WebClient
{
    public class BundleConfig
    {
        private const string ASSET_FOLDER = "~/Assets";

        public static void RegisterBundles(BundleCollection bundles)
        {
            registerScriptsModernizr(bundles);
            registerScriptsCore(bundles);
            registerScriptsPages(bundles);
            registerStylesCore(bundles);

            // BundleTable.EnableOptimizations = true;
        }

        private static void registerScriptsModernizr(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/modernizr").Include(
                ASSET_FOLDER + "/Scripts/Dependencies/modernizr.custom.js"
            ));
        }

        private static void registerScriptsCore(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/core").Include(
                ASSET_FOLDER + "/Scripts/Dependencies/jquery-2.0.3.js",
                ASSET_FOLDER + "/Scripts/Dependencies/knockout-3.0.0.js"
            ));
        }

        private static void registerScriptsPages(BundleCollection bundles)
        {
            const string path = ASSET_FOLDER + "/Scripts/PageScripts";

            bundles.Add(new ScriptBundle("~/Scripts/LoginPage").Include(
                path + "/LoginPage.js"
            ));
        }

        private static void registerStylesCore(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Styles/core").Include(
                ASSET_FOLDER + "/Styles/reset.css",
                ASSET_FOLDER + "/Styles/core.css"
            ));
        }
    }
}

using System.Web.Optimization;
using TMS.Web.UI.Filters;

namespace TMS.Web.UI
{
  public class BundleConfig
  {
    // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
    public static void RegisterBundles(BundleCollection bundles)
    {
      //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
      //  "~/Scripts/jquery-{version}.js"));

      //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
      //  "~/Scripts/jquery-ui-{version}.js"));

      //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
      //  "~/Scripts/jquery.unobtrusive*",
      //  "~/Scripts/jquery.validate*"));

      //// Use the development version of Modernizr to develop with and learn from. Then, when you're
      //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
      //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
      //  "~/Scripts/modernizr-*"));

      Bundle scriptBundle = new ScriptBundle("~/Scripts")
        .Include(
          //"~/Scripts/modernizr-2.7.2.js",
          "~/Scripts/jquery-2.1.0.js",
          //  //"~/Scripts/jqBootstrapValidation.js",
          "~/Scripts/jquery.dataTables.js",
          //  "~/Scripts/jquery.ext.dataTables.js",
          "~/Scripts/jquery.metisMenu.js",
          "~/Scripts/bootstrap.js",
          //  "~/Scripts/moment.min.js",
          //  "~/Scripts/bootstrap-datetimepicker.js",
          "~/Scripts/dataTables.bootstrap.js",
          //"~/Scripts/jquery.dataTables.min.js",
          //  "~/Scripts/morris.js",
          "~/Scripts/sb-admin.js"
          //"~/Scripts/Common.js"
        //  "~/Scripts/bootstrap-select.min.js",
        //  "~/Scripts/bootstrap-tooltip.min.js",
        //  "~/Scripts/bootstrap-transition.min.js",
        //  "~/Scripts/bootstrap-confirm.min.js",
        //  "~/Scripts/jquery.validate.min.js",
        //  "~/Scripts/bootstrap-dialog.min.js",
        //  "~/Scripts/bootstrap-spinedit.js",
        );

      Bundle styleBundle = new StyleBundle("~/Content")
        .Include(
          "~/Content/bootstrap.css",
          //  //"~/Content/glyphicons.css",
          //  //"~/Content/halflings.css",
          //  //"~/Content/bootstrap-theme.min.css",
          //  "~/Content/bootstrap-datetimepicker.min.css",
          "~/Content/dataTables.bootstrap.css",
          //  //"~/Content/bootstrap-datepicker3.css",
          //  //"~/Content/flags-large.css",
          //  //"~/Content/fam-icons.css",
          "~/Content/font-awesome.css",
          "~/Content/sb-admin.css"
        //  //"~/Content/timeline.css",
        //  "~/Content/bootstrap-select.min.css",
        //  "~/Content/bootstrap-dialog.min.css",
        //  "~/Content/bootstrap-spinedit.css"
        );

      bundles.Add(scriptBundle);
      bundles.Add(styleBundle);
    }

    //bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

    //bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
    //            "~/Content/themes/base/jquery.ui.core.css",
    //            "~/Content/themes/base/jquery.ui.resizable.css",
    //            "~/Content/themes/base/jquery.ui.selectable.css",
    //            "~/Content/themes/base/jquery.ui.accordion.css",
    //            "~/Content/themes/base/jquery.ui.autocomplete.css",
    //            "~/Content/themes/base/jquery.ui.button.css",
    //            "~/Content/themes/base/jquery.ui.dialog.css",
    //            "~/Content/themes/base/jquery.ui.slider.css",
    //            "~/Content/themes/base/jquery.ui.tabs.css",
    //            "~/Content/themes/base/jquery.ui.datepicker.css",
    //            "~/Content/themes/base/jquery.ui.progressbar.css",
    //            "~/Content/themes/base/jquery.ui.theme.css"));
  }
}
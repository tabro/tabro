using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Tabro.WebApp.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/Content/bootstrap.css",
                         "~/Content/bootstrap-theme.css",
                         "~/Content/bootstrap-social.css",
                         "~/Content/font-awesome.css",
                         "~/Content/site.css",
                         "~/Content/mdd_styles.css",
                         "~/Content/pretify.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.4.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/markdowndeep").Include(
                        "~/Scripts/MarkdownDeep.js",
                        "~/Scripts/MarkdownDeepEditor.js",
                        "~/Scripts/MarkdownDeepEditorUI.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js"));

        }
    }
}
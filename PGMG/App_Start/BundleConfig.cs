﻿using System.Web;
using System.Web.Optimization;

namespace PGMG
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/bootstrap-datepicker.js",
                        "~/Scripts/locales/bootstrap-datepicker.es.min.js",
                        "~/Scripts/jquery-ui-1.12.1.js",
                        "~/Scripts/jquery-ui-1.12.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
          "~/Ruta/de/popper.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/themes/base/.*",
                        "~/Content/fullcalendar.css"));
                      //"~/Content/fullcalendar.min.css"));

            //bundles.Add(new StyleBundle("~/Content/fullcalendarcss").Include(
            //    "~/Content/themes/jquery.ui.all.css",
            //    "~/Content/fullcalendar.css"));

            //bundles.Add(new ScriptBundle("~/bundles/fullcalendarjs").Include(
            //    "~/Scripts/jquery-ui-(version).min.js",
            //    "~/Scripts/moment.min.js",
            //    "~/Scripts/fullcalendar.min.js"));

        }
    }
}

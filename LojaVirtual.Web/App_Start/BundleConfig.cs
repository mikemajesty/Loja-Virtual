using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace LojaVirtual.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //-------------------------Jquery-------------------------//          
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                         .Include("~/Scripts/jquery.validate.min.js")
                         .Include("~/Scripts/jquery.validate.unobtrusive.min.js")
                         .Include("~/Scripts/jquery-2.1.3.js"));      
            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/modernizr-2.6.2.js"));
            //-------------------------Bootstrap-------------------------//
            bundles.Add(new StyleBundle("~/Content/bootstrap")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/bootstrap-theme.min.css"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js"));
            //-------------------------Custom-------------------------//
            bundles.Add(new StyleBundle("~/Content/Custom")
             .Include("~/Content/ErroEstilo.css"));
          
        }

    }
}

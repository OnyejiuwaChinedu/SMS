using System.Web.Mvc;

namespace SMS.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        //public override void RegisterArea(AreaRegistrationContext context) 
        //{
        //    context.MapRoute(
        //        "Admin_default",
        //        "Admin/{controller}/{action}/{id}",
        //        new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
        //        //new { action = "Index", id = UrlParameter.Optional }


        //    context.MapRoute(
        //        "Dashboard_default",
        //        "Dashboard/{controller}/{action}/{id}",
        //        new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
        //    );
        //}
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Dashboard_default",
                "Dashboard/{controller}/{action}/{id}",
                new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
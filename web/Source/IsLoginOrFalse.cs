using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Source
{
    public class IsLoginOrFalse : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
            HttpCookie cookie = filterContext.RequestContext.HttpContext.Request.Cookies["uID"];
            int uid = cookie == null ? 0 : Convert.ToInt32(cookie.Value);
            if (uid == 0)
            {
                filterContext.Result = new RedirectToRouteResult("Default", new System.Web.Routing.RouteValueDictionary(new
                {
                    Controller = "Home",
                    Action = "Index",
                    returnUrl = returnUrl
                }));
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }

        }

    }
}
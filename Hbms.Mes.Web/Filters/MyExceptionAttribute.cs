using Hbms.Mes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hbms.Mes.Web.Filters
{
    public class MyExceptionAttribute : HandleErrorAttribute
    {
        //public static Queue<Exception> ExceptionQueue = new Queue<Exception>();
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            RedisList.EnqueueItemOnList("ErrorLogs", filterContext.Exception);
            //ExceptionQueue.Enqueue(filterContext.Exception);
            if (filterContext.Exception != null)
            {
                //string a = filterContext.RouteData.Values["controller"].ToString();
                filterContext.HttpContext.Response.Redirect("/Error.html");
            }
        }
    }
}
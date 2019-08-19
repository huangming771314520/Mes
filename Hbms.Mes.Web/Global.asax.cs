using Hbms.Mes.Common;
using Hbms.Mes.Web.Filters;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Hbms.Mes.Web
{
    public class MvcApplication : Spring.Web.Mvc.SpringMvcApplication //System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //让Log4Net配置节点起作用，并注册我们的过滤器
            XmlConfigurator.Configure();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //string FileUrl = Server.MapPath("/Logs/");
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    if (RedisList.GetListCount("ErrorLogs") > 0)
                    //if (MyExceptionAttribute.ExceptionQueue.Count() > 0)
                    {
                        //Exception ex = MyExceptionAttribute.ExceptionQueue.Dequeue();
                        Exception ex = RedisList.DequeueItemFromList<Exception>("ErrorLogs");
                        if (ex != null)
                        {
                            //File.AppendAllText(FileUrl + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", ex.ToString(), System.Text.Encoding.Unicode);
                            ILog log = LogManager.GetLogger("ErrorName");
                            log.Error(ex.ToString());
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
            });

            //BundleTable.EnableOptimizations = true;//启用优化后:当页面下次再次发送请求的时候 BundleConfig里面没有更改的话、浏览器会从缓存中去取
        }
    }
}

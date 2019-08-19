using Hbms.Mes.Web.Filters;
using System.Web;
using System.Web.Mvc;

namespace Hbms.Mes.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MyExceptionAttribute());
        }
    }
}

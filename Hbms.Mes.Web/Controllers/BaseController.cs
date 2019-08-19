using Hbms.Mes.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hbms.Mes.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //if (Session["UserInfo"] == null)
            //{
            //    filterContext.Result = Redirect("/Home/About");
            //}
        }
        public class ResultData
        {
            public int Status { get; set; }
            public string Msg { get; set; }
            public object Data { get; set; }
        }
        public ActionResult Success(ResultData data)
        {
            data.Msg = "提交成功";
            string json = JsonConvert.SerializeObject(data);
            return Content(json);
        }
    }
}
using Hbms.Mes.BLL;
using Hbms.Mes.Common;
using Hbms.Mes.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hbms.Mes.Web.Controllers
{
    public class User
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
    public class HomeController : BaseController
    {
        //ISYS_BOMService bll = new SYS_BOMService();
        public IJQueryGanttService sys_bom_bll
        {
            get;
            set;
        }
        public ActionResult Index()
        {
            
            var list = sys_bom_bll.GetModelList(a => 1 == 1).ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
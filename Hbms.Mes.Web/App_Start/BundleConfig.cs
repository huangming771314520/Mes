using System.Web;
using System.Web.Optimization;

namespace Hbms.Mes.Web
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/js")
                .Include("~/Content/layuiadmin/layui/layui.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/layuiadmin/layui/css/layui.css")
                .Include("~/Content/layuiadmin/style/admin.css"));
        }
    }
}

using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            IUserInfoService lister = (IUserInfoService)ctx.GetObject("UserInfoService");
            Console.WriteLine(lister.GetMsg());
            Console.ReadLine();
        }
    }
}

using Hbms.Mes.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hbms.Mes.DalFactory
{
    public class AbstractFactory
    {
        private static readonly string AssemblyName = ConfigurationManager.AppSettings["AssemblyName"];
        private static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];
        public static object CreateModelDal(string ModelDal)
        {
            string ClassName = NameSpace + "." + ModelDal;
            return CreateInstance(ClassName);
        }

        public static object CreateInstance(string ClassName)
        {
            return Assembly.Load(AssemblyName).CreateInstance(ClassName);
        }

    }
}

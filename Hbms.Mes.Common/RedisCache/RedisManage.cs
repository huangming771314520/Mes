using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hbms.Mes.Common
{
    public class RedisManage
    {
        private static PooledRedisClientManager prcm { get; set; }
        private static RedisConfig config { get { return RedisConfig.GetConfig(); } }
        /// <summary>
        /// 初始化链接池对象prcm
        /// 静态构造函数不是我们程序员调用的、由.net框架在合适的时机调用的。
        /// 调用时机：在类被实例化或者静态成员被调用的时候进行调用，并且是由.net框架来调用静态构造函数来初始化静态成员变量。
        /// </summary>
        static RedisManage()
        {
            CreateManager();
        }
        /// <summary>
        /// 创建链接池管理对象
        /// </summary>
        private static void CreateManager()
        {
            string[] WriteServerConStr = SplitString(config.WriteServerList, ",");
            string[] ReadServerConStr = SplitString(config.ReadServerList, ",");
            prcm = new PooledRedisClientManager(ReadServerConStr, WriteServerConStr,
                             new RedisClientManagerConfig
                             {
                                 MaxWritePoolSize = config.MaxWritePoolSize,
                                 MaxReadPoolSize = config.MaxReadPoolSize,
                                 AutoStart = config.AutoStart,
                             });
        }
        private static string[] SplitString(string strSource, string split)
        {
            return strSource.Split(split.ToArray());
        }

        /// <summary>
        /// 客户端缓存操作对象
        /// </summary>
        public static IRedisClient GetClient()
        {
            if (prcm == null)
                CreateManager();
            return prcm.GetClient();
        }
    }
}

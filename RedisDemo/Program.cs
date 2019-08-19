using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using Hbms.Mes.Common;
using ServiceStack.Redis;

namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var Redis = new RedisClient("127.0.0.1", 6388);//redis服务IP和端口
            //var Redis2 = new RedisClient("127.0.0.1", 6388);//redis服务IP和端口
            //Redis.AddItemToList("test", "huangming99998888");
            //System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            //stopwatch.Start(); //  开始监视代码
            //for (int i = 0; i < 50000; i++)
            //{
            //    var test = Redis.GetAllItemsFromList("test");
            //    //Console.WriteLine(test[0]);
            //}
            //stopwatch.Stop(); //  停止监视
            //TimeSpan timeSpan = stopwatch.Elapsed; //  获取总时间
            //double hours = timeSpan.TotalHours; // 小时
            //double minutes = timeSpan.TotalMinutes;  // 分钟
            //double seconds = timeSpan.TotalSeconds;  //  秒数
            //double milliseconds = timeSpan.TotalMilliseconds;  //  毫秒数
            //string str = $"总小时数:{hours}，总分钟数:{minutes}，总秒数:{seconds}，总毫秒数:{seconds}";
            //Console.WriteLine(str);
            //Console.ReadLine();
            //ConcurrentQueue
            //Task<string> task1 = new Task<string>(() =>
            //{
            //    System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            //    stopwatch.Start(); //  开始监视代码
            //    for (int i = 0; i < 10000; i++)
            //    {
            //        var test = Redis.GetAllItemsFromList("test");
            //        //Console.WriteLine(test[0]);
            //    }
            //    stopwatch.Stop(); //  停止监视
            //    TimeSpan timeSpan = stopwatch.Elapsed; //  获取总时间
            //    double hours = timeSpan.TotalHours; // 小时
            //    double minutes = timeSpan.TotalMinutes;  // 分钟
            //    double seconds = timeSpan.TotalSeconds;  //  秒数
            //    double milliseconds = timeSpan.TotalMilliseconds;  //  毫秒数
            //    string ManagedThreadId = Thread.CurrentThread.ManagedThreadId.ToString();
            //    string TaskID = Task.CurrentId.ToString();
            //    string str = $"线程编号{TaskID}:总小时数:{hours}，总分钟数:{minutes}，总秒数:{seconds}，总毫秒数:{seconds}";
            //    return str;
            //    //Console.WriteLine(str);                 
            //    //Console.ReadLine();
            //});
            //Task<string> task2 = new Task<string>(() =>
            //{
            //    System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            //    stopwatch.Start(); //  开始监视代码
            //    for (int i = 0; i < 10000; i++)
            //    {
            //        var test = Redis2.GetAllItemsFromList("test");
            //        //Console.WriteLine(test[0]);
            //    }
            //    stopwatch.Stop(); //  停止监视
            //    TimeSpan timeSpan = stopwatch.Elapsed; //  获取总时间
            //    double hours = timeSpan.TotalHours; // 小时
            //    double minutes = timeSpan.TotalMinutes;  // 分钟
            //    double seconds = timeSpan.TotalSeconds;  //  秒数
            //    double milliseconds = timeSpan.TotalMilliseconds;  //  毫秒数
            //    string ManagedThreadId = Thread.CurrentThread.ManagedThreadId.ToString();
            //    string TaskID = Task.CurrentId.ToString();
            //    string str = $"线程编号{TaskID}:总小时数:{hours}，总分钟数:{minutes}，总秒数:{seconds}，总毫秒数:{seconds}";
            //    return str;
            //    //Console.WriteLine(str);
            //    //Console.ReadLine();
            //});
            //task1.Start();
            //task2.Start();
            //Task.WaitAll(task1, task2);
            //Console.WriteLine(task1.Result);
            //Console.WriteLine(task2.Result);
            //PooledRedisClientManager redis_pool = CreateManager(new string[] { "127.0.0.1:6379" }, new string[] { "127.0.0.1:6388" });
            //using (IRedisClient Redis3 = redis_pool.GetClient())
            //{
            //    string a = "";
            //}

            //RedisList.AddModelList("hm_test2",
            //    new List<dynamic>()
            //    {
            //        new
            //        {
            //            Name="李小强",
            //            Age=19
            //        },
            //        new
            //        {
            //            Name="六七千",
            //            Age=25
            //        },
            //        new
            //        {
            //            Name="皇马",
            //            Age=55
            //        }
            //    },
            //    DateTime.Now.AddHours(1));

            //var list= RedisList.GetModel<Student>("hm_test2", a => a.Name == "皇马1");

            //var list1 = RedisList.GetDynamicList("lst", a => Convert.ToString(a.Name).Contains("1"));

            //RedisList.DeleteModel("lst", a => Convert.ToInt32(a.Id) == 2);



            //Task.Run(() =>
            //{
            //    var Client = RedisManage.GetClient();
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Client.EnqueueItemOnList("List_Class", "哈哈哈:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
            //    }
            //});

            //Task.Run(() =>
            //{
            //    var Client = RedisManage.GetClient();
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Client.EnqueueItemOnList("List_Class", "哈哈哈:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
            //    }
            //});

            //Task.Run(() =>
            //{
            //    var Client = RedisManage.GetClient();
            //    while (RedisBase.Core.GetListCount("List_Class") > 0)
            //    {
            //        Console.WriteLine(RedisList.DequeueItemFromList("List_Class"));
            //    }
            //});



            //foreach (dynamic item in list)
            //{
            //    string name = item.name;
            //    int age = item.age;
            //    Console.WriteLine($"姓名：{name}，年龄：{age}");
            //}

            Console.ReadLine();
        }

        public static PooledRedisClientManager CreateManager(string[] readWriteHosts, string[] readOnlyHosts)
        {
            //支持读写分离，均衡负载
            return new PooledRedisClientManager(readWriteHosts, readOnlyHosts, new RedisClientManagerConfig
            {
                MaxWritePoolSize = 5,//“写”链接池链接数
                MaxReadPoolSize = 5,//“读”链接池链接数
                AutoStart = true,
            });
        }

    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

using Newtonsoft.Json;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hbms.Mes.Common
{
    public class RedisList : RedisBase
    {
        #region 赋值
        /// <summary>
        /// 从左侧向list中添加值
        /// </summary>
        public static void LPush(string key, string value)
        {
            RedisBase.Core.PushItemToList(key, value);
        }
        /// <summary>
        /// 从左侧向list中添加值，并设置过期时间
        /// </summary>
        public static void LPush(string key, string value, DateTime dt)
        {
            RedisBase.Core.PushItemToList(key, value);
            RedisBase.Core.ExpireEntryAt(key, dt);
        }
        /// <summary>
        /// 从左侧向list中添加值，设置过期时间
        /// </summary>
        public static void LPush(string key, string value, TimeSpan sp)
        {
            RedisBase.Core.PushItemToList(key, value);
            RedisBase.Core.ExpireEntryIn(key, sp);
        }
        /// <summary>
        /// 从左侧向list中添加值
        /// </summary>
        public static void RPush(string key, string value)
        {
            RedisBase.Core.PrependItemToList(key, value);
        }
        /// <summary>
        /// 从右侧向list中添加值，并设置过期时间
        /// </summary>    
        public static void RPush(string key, string value, DateTime dt)
        {
            RedisBase.Core.PrependItemToList(key, value);
            RedisBase.Core.ExpireEntryAt(key, dt);
        }
        /// <summary>
        /// 从右侧向list中添加值，并设置过期时间
        /// </summary>        
        public static void RPush(string key, string value, TimeSpan sp)
        {
            RedisBase.Core.PrependItemToList(key, value);
            RedisBase.Core.ExpireEntryIn(key, sp);
        }
        /// <summary>
        /// 添加key/value
        /// </summary>     
        public static void Add(string key, string value)
        {
            RedisBase.Core.AddItemToList(key, value);
        }
        /// <summary>
        /// 添加key/value ,并设置过期时间
        /// </summary>  
        public static void Add(string key, string value, DateTime dt)
        {
            RedisBase.Core.AddItemToList(key, value);
            RedisBase.Core.ExpireEntryAt(key, dt);
        }
        /// <summary>
        /// 添加key/value。并添加过期时间
        /// </summary>  
        public static void Add(string key, string value, TimeSpan sp)
        {
            RedisBase.Core.AddItemToList(key, value);
            RedisBase.Core.ExpireEntryIn(key, sp);
        }
        /// <summary>
        /// 为key添加多个值
        /// </summary>  
        public static void Add(string key, List<string> values)
        {
            RedisBase.Core.AddRangeToList(key, values);
        }
        /// <summary>
        /// 为key添加多个值，并设置过期时间
        /// </summary>  
        public static void Add(string key, List<string> values, DateTime dt)
        {
            RedisBase.Core.AddRangeToList(key, values);
            RedisBase.Core.ExpireEntryAt(key, dt);
        }
        /// <summary>
        /// 为key添加多个值，并设置过期时间
        /// </summary>  
        public static void Add(string key, List<string> values, TimeSpan sp)
        {
            RedisBase.Core.AddRangeToList(key, values);
            RedisBase.Core.ExpireEntryIn(key, sp);
        }
        #endregion
        #region 获取值
        /// <summary>
        /// 获取list中key包含的数据数量
        /// </summary>  
        public static long Count(string key)
        {
            return RedisBase.Core.GetListCount(key);
        }
        /// <summary>
        /// 获取key包含的所有数据集合
        /// </summary>  
        public static List<string> Get(string key)
        {
            return RedisBase.Core.GetAllItemsFromList(key);
        }
        /// <summary>
        /// 获取key中下标为star到end的值集合
        /// </summary>  
        public static List<string> Get(string key, int star, int end)
        {
            return RedisBase.Core.GetRangeFromList(key, star, end);
        }
        #endregion
        #region 阻塞命令
        /// <summary>
        ///  阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public static string BlockingPopItemFromList(string key, TimeSpan? sp)
        {
            return RedisBase.Core.BlockingDequeueItemFromList(key, sp);
        }
        /// <summary>
        ///  阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public static ItemRef BlockingPopItemFromLists(string[] keys, TimeSpan? sp)
        {
            return RedisBase.Core.BlockingPopItemFromLists(keys, sp);
        }
        /// <summary>
        ///  阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public static string BlockingDequeueItemFromList(string key, TimeSpan? sp)
        {
            return RedisBase.Core.BlockingDequeueItemFromList(key, sp);
        }
        /// <summary>
        /// 阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public static ItemRef BlockingDequeueItemFromLists(string[] keys, TimeSpan? sp)
        {
            return RedisBase.Core.BlockingDequeueItemFromLists(keys, sp);
        }
        /// <summary>
        /// 阻塞命令：从list中key的头部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public static string BlockingRemoveStartFromList(string keys, TimeSpan? sp)
        {
            return RedisBase.Core.BlockingRemoveStartFromList(keys, sp);
        }
        /// <summary>
        /// 阻塞命令：从list中key的头部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public static ItemRef BlockingRemoveStartFromLists(string[] keys, TimeSpan? sp)
        {
            return RedisBase.Core.BlockingRemoveStartFromLists(keys, sp);
        }
        /// <summary>
        /// 阻塞命令：从list中一个fromkey的尾部移除一个值，添加到另外一个tokey的头部，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public static string BlockingPopAndPushItemBetweenLists(string fromkey, string tokey, TimeSpan? sp)
        {
            return RedisBase.Core.BlockingPopAndPushItemBetweenLists(fromkey, tokey, sp);
        }
        #endregion
        #region 删除
        /// <summary>
        /// 从尾部移除数据，返回移除的数据
        /// </summary>  
        public static string PopItemFromList(string key)
        {
            return RedisBase.Core.PopItemFromList(key);
        }
        /// <summary>
        /// 移除list中，key/value,与参数相同的值，并返回移除的数量
        /// </summary>  
        public static long RemoveItemFromList(string key, string value)
        {
            return RedisBase.Core.RemoveItemFromList(key, value);
        }
        /// <summary>
        /// 从list的尾部移除一个数据，返回移除的数据
        /// </summary>  
        public static string RemoveEndFromList(string key)
        {
            return RedisBase.Core.RemoveEndFromList(key);
        }
        /// <summary>
        /// 从list的头部移除一个数据，返回移除的值
        /// </summary>  
        public static string RemoveStartFromList(string key)
        {
            return RedisBase.Core.RemoveStartFromList(key);
        }
        #endregion
        #region 其它
        /// <summary>
        /// 从一个list的尾部移除一个数据，添加到另外一个list的头部，并返回移动的值
        /// </summary>  
        public static string PopAndPushItemBetweenLists(string fromKey, string toKey)
        {
            return RedisBase.Core.PopAndPushItemBetweenLists(fromKey, toKey);
        }
        #endregion


        public static void AddModelList<T>(string listId, IEnumerable<T> values, DateTime? dt = null)
        {
            var IRedisTypedClient = RedisBase.Core.As<T>();
            IRedisTypedClient.Lists[listId].AddRange(values);
            if (!(dt is null))
            {
                RedisBase.Core.ExpireEntryAt(listId, Convert.ToDateTime(dt));
            }
        }

        public static void AddModel<T>(string listId, T values, DateTime? dt = null)
        {
            var IRedisTypedClient = RedisBase.Core.As<T>();
            IRedisTypedClient.Lists[listId].Add(values);
            if (!(dt is null))
            {
                RedisBase.Core.ExpireEntryAt(listId, Convert.ToDateTime(dt));
            }
        }

        public static List<T> GetModelList<T>(string listId, Func<T, bool> where = null) where T : class, new()
        {
            var IRedisTypedClient = RedisBase.Core.As<T>();
            IEnumerable<T> IRedisList = IRedisTypedClient.Lists[listId];
            if (!(where is null))
            {
                IRedisList = IRedisList.Where(where);
            }
            return IRedisList.ToList();
        }

        public static List<dynamic> GetDynamicList(string listId, Func<dynamic, bool> where = null)
        {
            var List = RedisBase.Core.GetAllItemsFromList(listId);
            var JsonString = "[" + string.Join(",", List) + "]";
            IEnumerable<dynamic> DynamicList = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(JsonString);
            if (!(where is null))
            {
                DynamicList = DynamicList.Where(where);
            }
            return DynamicList.ToList();
        }

        public static T GetModel<T>(string listId, Func<T, bool> where) where T : new()
        {
            var IRedisTypedClient = RedisBase.Core.As<T>();
            IEnumerable<T> IRedisList = IRedisTypedClient.Lists[listId];
            T result = new T();
            result = IRedisList.Where(where).FirstOrDefault();
            return result;
        }

        public static long DeleteModel<T>(string listId, Func<T, bool> where)
        {
            var IRedisTypedClient = RedisBase.Core.As<T>();
            var model = IRedisTypedClient.Lists[listId].Where(where).First();
            return IRedisTypedClient.RemoveItemFromList(IRedisTypedClient.Lists[listId], model);
        }

        public static long DeleteModel(string listId, Func<dynamic, bool> where)
        {
            var model = GetDynamicList(listId, where).FirstOrDefault();
            var DeleteJson = JsonConvert.SerializeObject(model);
            return RedisBase.Core.RemoveItemFromList(listId, DeleteJson);
        }

        public static void EnqueueItemOnList(string listId, string value)
        {
            RedisBase.Core.EnqueueItemOnList(listId, value);
        }

        public static void EnqueueItemOnList<T>(string listId, T value)
        {
            string JsonStr = JsonConvert.SerializeObject(value);
            RedisBase.Core.EnqueueItemOnList(listId, JsonStr);
        }

        public static void EnqueueItemOnList(string listId, dynamic value)
        {
            string JsonStr = JsonConvert.SerializeObject(value);
            RedisBase.Core.EnqueueItemOnList(listId, JsonStr);
        }

        public static string DequeueItemFromList(string listId)
        {
            return RedisBase.Core.DequeueItemFromList(listId);
        }

        public static T DequeueItemFromList<T>(string listId)
        {
            string QueueStr = RedisBase.Core.DequeueItemFromList(listId);
            return JsonConvert.DeserializeObject<T>(QueueStr);
        }

        public static long GetListCount(string listId)
        {
            return RedisBase.Core.GetListCount(listId);
        }
    }
}

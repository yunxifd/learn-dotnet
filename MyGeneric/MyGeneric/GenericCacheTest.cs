using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace MyGeneric
{

    public class GenericCacheTest
    {
        public static void Show()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(GenericCache<int>.GetCache());
                Thread.Sleep(1000);
                Console.WriteLine(GenericCache<long>.GetCache());
                Thread.Sleep(1000);
                Console.WriteLine(GenericCache<string>.GetCache());
                Thread.Sleep(1000);
                Console.WriteLine(GenericCache<GenericCacheTest>.GetCache());
                Thread.Sleep(1000);
            }
        }
    }

    /// <summary>
    /// 字典缓存 静态属性常驻内存
    ///
    /// </summary>
    public class DictionaryCache
    {
        private static Dictionary<Type, string> _TypeTimeDictionary = null;

        static DictionaryCache()
        {
            Console.WriteLine("this is DictionaryCache 静态构造函数");
            _TypeTimeDictionary = new Dictionary<Type, string>();
        }

        public static string GetCache<T>()
        {
            Type type = typeof(Type);
            if (!_TypeTimeDictionary.ContainsKey(type))
            {
                _TypeTimeDictionary[type] = string.Format("{0}_{1}", typeof(T).FullName, DateTime.Now.ToString());
            }

            return _TypeTimeDictionary[type];
        }
    }

    /// <summary>
    /// 泛型类
    ///
    /// 包含一个 静态构造函数
    ///
    /// 每个不同的 T, 都会生成一份不同的副本，不同副本即不同类 就会有不同的静态构造函数
    /// 适合不同类型，需要缓存一份数据的场景，效率高 比字典项的缓存查询效率还高
    ///
    /// 缓存 不能主动释放
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericCache<T> {
        /// <summary>
        /// 静态构造函数
        ///
        /// 用于初始化任何 静态 数据，或用于执行仅需执行一次的特定操作
        /// 在创建第一个实例或引用任何静态成员之前，将自动调用静态构造函数。
        ///
        /// </summary>
        static GenericCache() {
            Console.WriteLine("This is GenericCache 静态构造函数");
            TypeTime = $"{typeof(T).FullName}_{DateTime.Now.ToString(CultureInfo.InvariantCulture)}";
        }

        private static readonly string TypeTime;
        
        public static string GetCache()
        {
            return TypeTime;
        }
    }
}

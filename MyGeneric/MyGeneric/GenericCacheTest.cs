using System;
using System.Globalization;

namespace MyGeneric
{
    public class GenericCache<T> {
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

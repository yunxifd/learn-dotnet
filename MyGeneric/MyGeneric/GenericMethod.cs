using System;

namespace MyGeneric
{
    public static class GenericMethod
    {
        /// <summary>
        /// 2.0 的时候 推出了新语法 -----泛型
        /// 
        /// 泛型方法 - 主要用来解决用一个方法，满足不同参数类型，来做相同的事
        /// 
        /// 延迟声明： 把参数类型的声明推迟到调用
        /// 不是语法糖，而是由框架升级提供的功能
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        public static void Show<T>(T value)
        {
            Console.WriteLine($"this is {typeof(GenericMethod)},type={value.GetType().Name} , value = {value}");
        }
    }
}

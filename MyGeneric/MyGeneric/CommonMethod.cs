using System;

namespace MyGeneric
{
    public static class CommonMethod
    {
        /// <summary>
        /// 打印int值
        /// </summary>
        /// <param name="value"></param>
        public static void ShowInt(int value)
        {
            Console.WriteLine($"This is {typeof(CommonMethod).Name}, type={value.GetType().Name}, value={value}");
        }

        /// <summary>
        /// 打印string值
        /// </summary>
        /// <param name="value"></param>
        public static void ShowString(string value)
        {
            Console.WriteLine($"This is {typeof(CommonMethod).Name}, type={value.GetType().Name}, value={value}");
        }

        /// <summary>
        /// 打印datetime值
        /// </summary>
        /// <param name="value"></param>
        public static void ShowDateTime(DateTime value)
        {
            Console.WriteLine($"This is {typeof(CommonMethod).Name}, type={value.GetType().Name}, value={value}");
        }

        /// <summary>
        /// 打印object值
        /// 
        /// object 类型是一切类型的父类
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void ShowObj(object value)
        {
            Console.WriteLine($"This is {typeof(CommonMethod).Name}, type={value.GetType().Name}, value={value}");
        }
    }
}

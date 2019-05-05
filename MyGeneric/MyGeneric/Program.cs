using System;
using System.Collections.Generic;

namespace MyGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(".net framework 1.0的时候");
            int intValue = 1;
            string stringValue = "1";
            DateTime dateValue = DateTime.Now;
            CommonMethod.ShowInt(intValue);
            CommonMethod.ShowString(stringValue);
            CommonMethod.ShowDateTime(dateValue);
            Console.WriteLine("使用object简化代码");
            CommonMethod.ShowObj(intValue);
            CommonMethod.ShowObj(stringValue);
            CommonMethod.ShowObj(dateValue);

            Console.WriteLine(".net framework 2.0的时候，引入泛型");
            GenericMethod.Show(intValue);
            GenericMethod.Show(stringValue);
            GenericMethod.Show(dateValue);

            Console.WriteLine("打印泛型类型，会看到编译器，生成占位符");
            Console.WriteLine(typeof(List<>));
            Console.WriteLine(typeof(Dictionary<,>));

            Console.WriteLine("比较性能");
            Monitor.Show();
        }
    }
}

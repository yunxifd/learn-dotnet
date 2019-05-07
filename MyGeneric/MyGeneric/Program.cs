using MyGeneric.models;
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

            // 泛型类

            // 泛型接口

            // 泛型约束
            var people = new People()
            {
                Id = 1,
                Name = "人类"
            };

            var chinese = new Chinese()
            {
                Id = 2,
                Name = "中国人"
            };
            var japanese = new Japanese()
            {
                Id = 3,
                Name = "日本人"
            };

            CommonMethod.ShowObj(people);
            CommonMethod.ShowObj(chinese);
            CommonMethod.ShowObj(japanese);

            GenericMethod.Show(people);
            GenericMethod.Show(chinese);
            GenericMethod.Show(japanese);

            // 上面方法只是打印了对象的类型
            // 如果想打印 对象里的内容 输出Id,Name的值

            Constraint.ShowBase(people);
            Constraint.Show(chinese);
            //Constraint.Show(japanese); 由于japannese 不是继承自 People 类所以这里不能使用

            // 为啥不直接使用基类 方法
            
            // 泛型类缓存
            GenericCacheTest.Show();
        }
    }
}

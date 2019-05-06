using MyGeneric.models;
using System;

namespace MyGeneric
{
    public static class Constraint
    {
        /// <summary>
        /// 泛型： 不同的参数类型都能进来，任何类型都能传递进来，这就造成了 类型安全的问题
        /// 
        /// 所以需要 泛型约束 - 基类约束
        ///  好处是：
        ///  限制了泛型方法 可以处理的 参数的类型，必须是继承自基类的类 或 基类
        ///  可以直接使用基类的一切属性和方法，而不用用反射来获取对象的属性和方法
        ///  
        /// 作为约束使用的类型必须是接口、非密封类或类型参数
        /// - 不能是 sealed 声明的类
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="people"></param>
        public static void Show<T>(T people)
            where T : People
            // where T: class 引用类型约束
            // where T: ISports 接口约束
            // where T: struct // 值类型约束
           // where T: new()  无参数构造函数约束
        {
            Console.WriteLine($"{people.Id}-{people.Name}");
        }

        //作为约束使用的类型必须是接口、非密封类或类型参数

        public static T Get<T>(T t)
        {
            T tNew = default(T);
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="people"></param>
        public static void ShowBase(People people) {
            Console.WriteLine($"{people.Id}-{people.Name}");
        }
    }
}

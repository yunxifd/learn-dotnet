using System;
using System.Reflection;
using MyAttribute.Extend;

namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    class FirstAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Class)]
    class SecondAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class ThirdAttribute : Attribute { }

    // Apply custom attributes to classes:
    [First, Second]
    class BaseClass { }

    [Third, Third]
    class DerivedClass : BaseClass { }
    class Program
    {
        static void Main(string[] args)
        {
            // 示例一
            BaseClass b = new BaseClass();
            DerivedClass d = new DerivedClass();
            
            // 查看类上的 特性
            // Display custom attributes for each class.
            Console.WriteLine("Attributes on Base Class:");
            object[] attrs = b.GetType().GetCustomAttributes(true);
            foreach (Attribute attr in attrs)
            {
                Console.WriteLine(attr);
            }

            Console.WriteLine("Attributes on Derived Class:");
            attrs = d.GetType().GetCustomAttributes(true);
            foreach (Attribute attr in attrs)
            {
                Console.WriteLine(attr);
            }

            // 示例2
            // 读取添加的特性的信息
            GetAttributeInfoByReflectionTest.Test();
            
            // 示例3
            // 获取 Student类上的特性
            var type = typeof(Student);
            if (type.IsDefined(typeof(CustomAttribute), true))
            {
                CustomAttribute attribute = type.GetCustomAttribute<CustomAttribute>();
                
                Console.WriteLine($"{attribute.Description} {attribute.Remark}");
            }
            // 获取属性上的特性
            PropertyInfo propertyInfo = type.GetProperty("Id");
            if (propertyInfo.IsDefined(typeof(CustomAttribute), true))
            {
                CustomAttribute attribute = propertyInfo.GetCustomAttribute<CustomAttribute>();
                
                Console.WriteLine($"{attribute.Description} {attribute.Remark}");
            }
            // 获取方法上的特性
            MethodInfo methodInfo = type.GetMethod("Answer");
            if (methodInfo.IsDefined(typeof(CustomAttribute), true))
            {
                CustomAttribute attribute = methodInfo.GetCustomAttribute<CustomAttribute>();
                
                Console.WriteLine($"{attribute.Description} {attribute.Remark}");
            }
            
            // 获取方法参数上的特性
            ParameterInfo parameterInfo = methodInfo.GetParameters()[0];
            if (parameterInfo.IsDefined(typeof(CustomAttribute), true))
            {
                CustomAttribute attribute = parameterInfo.GetCustomAttribute<CustomAttribute>();
                
                Console.WriteLine($"{attribute.Description} {attribute.Remark}");
            }
            
            // 获取返回值 上的 特性
            ParameterInfo returnParameterInfo = methodInfo.ReturnParameter;
            if (returnParameterInfo.IsDefined(typeof(CustomAttribute), true))
            {
                CustomAttribute attribute = returnParameterInfo.GetCustomAttribute<CustomAttribute>();
                
                Console.WriteLine($"{attribute.Description} {attribute.Remark}");
            }
            
            
            // 获取枚举值 前端显示名称
            {
                Console.WriteLine(UserState.Normal.GetRemark());
                Console.WriteLine(UserState.Frozen.GetRemark());
                Console.WriteLine(UserState.Deleted.GetRemark());
                Console.WriteLine(RemarkExtension.GetRemark(UserState.Deleted));
            }
            
            // 使用 特性 进行 数据合法性校验
            {
                var student1 = new Student()
                {
                    QQ = 5
                };
                var student2 = new Student()
                {
                    QQ = 6
                };
                Console.WriteLine(student1.QQ.Validate());
                Console.WriteLine(student2.QQ.Validate());
            }
        }
    }
}
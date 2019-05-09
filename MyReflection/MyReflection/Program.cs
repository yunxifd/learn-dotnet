using Project.DB.MySql;
using System;
using System.Reflection;

namespace MyReflection
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // 1、首先加载dll
            Assembly assembly1 = Assembly.Load("Project.DB.MySql"); // 从当前目录 加载 指定名称的 dll

            // 加载指定文件路径的 dll ,可以是别的目录 ，加载不会报错，但是如果没有依赖项 ，使用的时候会报错
            //Assembly assembly2 = Assembly.LoadFile(@"E:\repository\learn-dotnet\MyReflection\Project.DB.MySql\bin\Debug\netcoreapp2.2\Project.DB.MySql.dll");

            // 带后缀 或指定文件路径的dll
            // Assembly assembly3 = Assembly.LoadFrom("Project.DB.MySql.dll");

            // 2、读取 dll信息
            foreach (var item in assembly1.GetModules())
            {
                Console.WriteLine(item.FullyQualifiedName);
            }
            foreach (var item in assembly1.GetTypes())
            {
                Console.WriteLine(item.FullName);
            }

            // 3、使用
            Type type = assembly1.GetType("Project.DB.MySql.MySqlDbHelper");
            object oDBHelper2 = Activator.CreateInstance(type);

            // 编译器报错 因为编译器 不知道 里面有 Query 方法
            // oDBHelper2.Query();

            // dynamic 与 object的区别
            // dynamic 绕过编译时类型检查， 改为在运行时解析这些操作
            dynamic oDBHelper = Activator.CreateInstance(type);
            oDBHelper.Query();

            // 查看类型信息
            {
                // load an assembly using its file name
                Assembly a = Assembly.Load("Project.DB.MySql");

                Type[] types2 = a.GetTypes();
                foreach (Type t in types2)
                {
                    Console.WriteLine(t.FullName);
                }
            }

            {
                Singleton instance1 = Singleton.GetInstance();
                Singleton instance2 = Singleton.GetInstance();
                Console.WriteLine(instance1 == instance2);

                {
                    Assembly assembly = Assembly.Load("Project.DB.MySql");
                    Type type2 = assembly.GetType("Project.DB.MySql.Singleton");
                    // 默认是 不能调用 对象的私有构造函数 创建 实例对象的
                    // 但是 通过反射 我们可以 调用私有构造函数 创建实例化对象
                    // 因此 下面2个实例 是不同的
                    Singleton instance3 = (Singleton)Activator.CreateInstance(type2, true);
                    Singleton instance4 = (Singleton)Activator.CreateInstance(type2, true);

                    Console.WriteLine(instance3 == instance4);
                }
                {
                    // 调用 有参构造函数
                    Assembly assembly = Assembly.Load("Project.DB.MySql");
                    Type type2 = assembly.GetType("Project.DB.MySql.Student");

                    object obj1 = Activator.CreateInstance(type2);
                    object obj2 = Activator.CreateInstance(type2, 1, "liLei");
                }
                {
                    // 泛型类
                    // 注意泛型类的runtime type  类名+占位符+类型个数
                    Assembly assembly = Assembly.Load("Project.DB.MySql");
                    // 注意这里获取泛型类的 class名称的写法
                    Type type2 = assembly.GetType("Project.DB.MySql.GenericClass`3");
                    // 设置泛型类 的参数类型
                    Type newType = type2.MakeGenericType(typeof(Guid), typeof(string), typeof(int));
                    object obj1 = Activator.CreateInstance(newType);
                }
                {
                    var a = typeof(int); // 获取类型的type
                    const int c = 1;
                    var b = c.GetType(); // 获取变量的type

                    Console.WriteLine(a == b);
                }

                // 通过反射 调用方法
                // 使用场景 MVC 中的 url 映射
                {
                    // 调用 有参构造函数
                    Assembly assembly = Assembly.Load("Project.DB.MySql");
                    Type type2 = assembly.GetType("Project.DB.MySql.Student");

                    object obj1 = Activator.CreateInstance(type2, 1, "李磊");

                    // 实例方法
                    {
                        MethodInfo method = type2.GetMethod("ShowInfo");
                        method.Invoke(obj1, null);
                    }
                    // 重载方法 showInfo 有多个
                    {
                        // 调用 ShowInfo2(int id)
                        MethodInfo method1 = type2.GetMethod("ShowInfo2", new Type[] { typeof(int) });
                        method1.Invoke(obj1, new object[] { 1 });
                        // 调用 ShowInfo2(int id, string name)
                        MethodInfo method2 = type2.GetMethod("ShowInfo2", new Type[] { typeof(int), typeof(string) });
                        method2.Invoke(obj1, new object[] { 1, "李磊" });
                    }
                    // 静态方法
                    {
                        MethodInfo method = type2.GetMethod("StaticShow");
                        method.Invoke(obj1, null);
                        // 静态方法 可以不用传实例对象 因此这里可以直接传递 null
                        method.Invoke(null, null);
                    }
                    // 私有方法
                    {
                        MethodInfo method = type2.GetMethod("PrivateShow", BindingFlags.NonPublic | BindingFlags.Instance);
                        method.Invoke(obj1, null);
                    }
                    // 泛型方法
                    {
                        Assembly assembly2 = Assembly.Load("Project.DB.MySql");
                        Type type3 = assembly2.GetType("Project.DB.MySql.GenericClass`3");
                        Type newType = type3.MakeGenericType(typeof(Guid), typeof(string), typeof(int));
                        object oGeneric = Activator.CreateInstance(newType);
                        MethodInfo method = newType.GetMethod("Show");
                        // 设置泛型方法 的 泛型类型 Show<W>(T1 t1, T2 t2, T3 t3) 即 W的类型
                        MethodInfo methodNew = method.MakeGenericMethod(typeof(Guid));
                        methodNew.Invoke(oGeneric, new object[] { Guid.NewGuid(), "李磊", 28 });
                    }
                }

                // 通过反射 获取 字段 
                // 使用场景 ORM
                {
                    Student student = new Student
                    {
                        Id = 1,
                        Name = "李磊"
                    };
                    Console.WriteLine($"{student.Id} {student.Name}");

                    object student2 = Activator.CreateInstance(typeof(Student), 2, "李翰");
                    foreach (var property in typeof(Student).GetProperties())
                    {
                        // 修改 属性值
                        if(property.Name.Equals("Name"))
                            property.SetValue(student2,"韩梅梅");
                        // 获取属性值
                        Console.WriteLine(property.Name+":"+ property.GetValue(student2));
                    }
                }
            }
        }
    }
}
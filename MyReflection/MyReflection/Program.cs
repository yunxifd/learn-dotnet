using System;
using System.Reflection;
using System.Runtime.CompilerServices;

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
            // 首先加载dll
            Assembly assembly1 = Assembly.Load("Project.DB.MySql"); // 从当前目录 加载 指定名称的 dll
            
            // 加载指定文件路径的 dll ,可以是别的目录 ，加载不会报错，但是如果没有依赖项 ，使用的时候会报错
            Assembly assembly2 = Assembly.LoadFile(@"E:\repository\learn-dotnet\MyReflection\Project.DB.MySql\bin\Debug\netcoreapp2.2\Project.DB.MySql.dll");

            // 带后缀 或指定文件路径的dll
            // Assembly assembly3 = Assembly.LoadFrom("Project.DB.MySql.dll");
    
            // 读取 dll信息
            foreach (var item in assembly1.GetModules())
            {
                Console.WriteLine(item.FullyQualifiedName);
            }
            foreach (var item in assembly1.GetTypes())
            {
                Console.WriteLine(item.FullName);
            }
            
            // 使用
            Type type = assembly1.GetType("Project.DB.MySql.MySqlDbHelper");
            dynamic oDBHelper = Activator.CreateInstance(type);
            oDBHelper.Query();
        }
    }
}
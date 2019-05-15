using MyAttribute.Extend;
using System;

namespace MyAttribute
{
    // 给 class 添加特性
    // [Custom]
    // [Custom(Description = "description",Remark = "remark")]
    [Custom("description","remark")]
    public class Student
    {
        [Custom]
        public int Id { get; set; }
        public string Name { get; set; }
        [LongAttribute(1,100)]
        public long QQ { get; set; }

        // 给方法添加特性
        [Custom]
        public void Study()
        {
            Console.WriteLine($"这里是{this.Name}");
        }
        
        // [return:Custom()] 给返回值添加特性
        // [Custom]string name 给方法参数 添加特性
        [Custom]
        [return:Custom]
        public string Answer([Custom]string name)
        {
            return $"This is {name}";
        }
    }
}
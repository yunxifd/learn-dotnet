using System;

namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.All,AllowMultiple = true,Inherited = true)]
    public class CustomAttribute:Attribute
    {
        public string  Description { get; set; }
        public string Remark { get; set; }

        public CustomAttribute()
        {
            
        }

        public CustomAttribute(string description, string remark)
        {
            Description = description;
            Remark = remark;
        }

        public void Show()
        {
            Console.WriteLine($"This is {nameof(CustomAttribute)}");
        }
    }
}
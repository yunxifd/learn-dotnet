using System;
using System.Reflection;

namespace MyAttribute.Extend
{
    public static class ValidateExtension
    {
        public static bool Validate(this object oObject)
        {
            var type = oObject.GetType();
            //foreach (var prop in type.GetProperties()) {
            //    if (prop.IsDefined(typeof(LongAttribute), true))
            //    {
            //       var attribute= (LongAttribute)prop.GetCustomAttribute(typeof(LongAttribute));
            //        if (attribute.Validate(prop.GetValue(oObject)))
            //            return true;
            //    }
            //}
            // 如有需要校验其他特性 也可以在这里一起处理
            // 例如 名称长度的校验 LenAttribute 等等 每个校验的特性 都有一个Validate 方法 为了简化代码 我们可以 使用抽象类
            // 例如 如下的 AbstractValidateAttribute 让每个 实现校验功能的特性 都继承自它 ，然后通过反射 获取循环遍历 校验 
            foreach (var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(LongAttribute), true))
                {
                    var attributes = prop.GetCustomAttributes(typeof(AbstractValidateAttribute));
                    foreach (AbstractValidateAttribute attribute in attributes) {
                        if (!attribute.Validate(prop.GetValue(oObject)))
                            return false;
                    }
                }
            }
            return true;
        }
    }


    public abstract class AbstractValidateAttribute : Attribute {
        public abstract bool Validate(object oObject);
    }

    public class LongAttribute : Attribute
    {
        public long Min { get; set; }
        public long Max { get; set; }

        public LongAttribute()
        {

        }

        public LongAttribute(long min, long max)
        {
            Min = min;
            Max = max;
        }

        public bool Validate(object value)
        {
            if (value != null && string.IsNullOrWhiteSpace(value.ToString()))
                if (long.TryParse(value.ToString(), out long lResult))
                {
                    if (lResult > Min && lResult < Max)
                        return true;
                }

            return false;
        }
    }
}
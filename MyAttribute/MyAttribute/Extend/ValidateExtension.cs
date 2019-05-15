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
            // ������ҪУ���������� Ҳ����������һ����
            // ���� ���Ƴ��ȵ�У�� LenAttribute �ȵ� ÿ��У������� ����һ��Validate ���� Ϊ�˼򻯴��� ���ǿ��� ʹ�ó�����
            // ���� ���µ� AbstractValidateAttribute ��ÿ�� ʵ��У�鹦�ܵ����� ���̳����� ��Ȼ��ͨ������ ��ȡѭ������ У�� 
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
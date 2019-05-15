using System;
using System.Reflection;

namespace MyAttribute.Extend
{
    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserState
    {
        [Remark("正常")] Normal = 1,
        [Remark("冻结")] Frozen = 2,
        [Remark("删除")] Deleted = 3
    }

    public class RemarkAttribute : Attribute
    {
        public RemarkAttribute(string remark)
        {
            Remark = remark;
        }

        private string Remark = null;

        public string GetRemark()
        {
            return Remark;
        }
    }

    public static class RemarkExtension
    {
        public static string GetRemark(this Enum value)
        {
            Type type = value.GetType();
            // 枚举中的 key 是 字段
            FieldInfo fieldInfo = type.GetField(value.ToString());

            if (fieldInfo.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute attribute = (RemarkAttribute) fieldInfo.GetCustomAttribute(typeof(RemarkAttribute));
                return attribute.GetRemark();
            }

            return value.ToString();
        }
    }
}
namespace MyGeneric
{
    /// <summary>
    /// 泛型类
    /// 
    /// 一个类来满足不同的数据类型，做相同的事
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericClass<T>
    {
        public T Id { get; set; }
    }

    /// <summary>
    /// 普通方法继承 泛型类 必须指定类型
    /// </summary>
    public class CommonClass : GenericClass<int>, IGenericInterface<string>
    {
        public string Get()
        {
            throw new System.NotImplementedException();
        }
    }

    /// <summary>
    /// 泛型类的继承
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericChildClass<T> : GenericClass<T> {
    }
}

namespace MyGeneric
{
    /// <summary>
    /// 泛型接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericInterface<T>
    {
        T Get();
    }

    /// <summary>
    /// 泛型委托
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public delegate void SayHi<T>();
}

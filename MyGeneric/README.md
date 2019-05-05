假设有需求 要打印不同类型的数据的值

.net framework 1.0 的时候
我们需要为不同数据类型定义，不同的方法
```cs
/// <summary>
/// 打印int值
/// </summary>
/// <param name="value"></param>
public static void ShowInt(int value)
{
    Console.WriteLine($"This is {typeof(CommonMethod).Name}, type={value.GetType().Name}, value={value}");
}

/// <summary>
/// 打印string值
/// </summary>
/// <param name="value"></param>
public static void ShowString(string value)
{
    Console.WriteLine($"This is {typeof(CommonMethod).Name}, type={value.GetType().Name}, value={value}");
}

/// <summary>
/// 打印datetime值
/// </summary>
/// <param name="value"></param>
public static void ShowDateTime(DateTime value)
{
    Console.WriteLine($"This is {typeof(CommonMethod).Name}, type={value.GetType().Name}, value={value}");
}
```

为了简化上面的代码，.net framework 1.0 时候的做法
```cs
public static void ShowObj(object value)
{
    Console.WriteLine($"This is {typeof(CommonMethod).Name}, type={value.GetType().Name}, value={value}");
}
```

利用 System.Object类型是所有内建类型的基类，来实现的。通过继承，子类拥有父类的一切属性和方法，任何父类出现的地方，都可以用子类代替

object是引用类型 如果传其他值类型(int 等等) 会有一个装箱拆箱的性能损失

## 泛型的原理

## 引入泛型的优缺点

##参考资料
https://www.cnblogs.com/dotnet261010/p/9034594.html
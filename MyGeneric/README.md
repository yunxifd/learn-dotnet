���������� Ҫ��ӡ��ͬ���͵����ݵ�ֵ

.net framework 1.0 ��ʱ��
������ҪΪ��ͬ�������Ͷ��壬��ͬ�ķ���
```cs
/// <summary>
/// ��ӡintֵ
/// </summary>
/// <param name="value"></param>
public static void ShowInt(int value)
{
    Console.WriteLine($"This is {typeof(CommonMethod).Name}, type={value.GetType().Name}, value={value}");
}

/// <summary>
/// ��ӡstringֵ
/// </summary>
/// <param name="value"></param>
public static void ShowString(string value)
{
    Console.WriteLine($"This is {typeof(CommonMethod).Name}, type={value.GetType().Name}, value={value}");
}

/// <summary>
/// ��ӡdatetimeֵ
/// </summary>
/// <param name="value"></param>
public static void ShowDateTime(DateTime value)
{
    Console.WriteLine($"This is {typeof(CommonMethod).Name}, type={value.GetType().Name}, value={value}");
}
```

Ϊ�˼�����Ĵ��룬.net framework 1.0 ʱ�������
```cs
public static void ShowObj(object value)
{
    Console.WriteLine($"This is {typeof(CommonMethod).Name}, type={value.GetType().Name}, value={value}");
}
```

���� System.Object�����������ڽ����͵Ļ��࣬��ʵ�ֵġ�ͨ���̳У�����ӵ�и����һ�����Ժͷ������κθ�����ֵĵط������������������

object���������� ���������ֵ����(int �ȵ�) ����һ��װ������������ʧ

## ���͵�ԭ��

## ���뷺�͵���ȱ��

##�ο�����
https://www.cnblogs.com/dotnet261010/p/9034594.html
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

object���������� ���������ֵ����(int,DateTime �ȵ�) ����һ��װ������������ʧ

## ���͵�ԭ��
.Net Framework 2.0 ��ʱ�������˷��͡�  
�������ӳ������ģ��������ʱ��û��ָ������Ĳ������ͣ��Ѳ������͵������Ƴٵ��˵��õ�ʱ���ָ���������͡� �ӳ�˼���ڳ���ܹ���Ƶ�ʱ����ܻ�ӭ�����磺�ֲ�ʽ������С�EF���ӳټ��صȵȡ�

���͵�ʵ���� �����﷨�ǣ����ǿ�����������������ԡ� ��**������+ JIT**�Ĺ�ͬ������ʵ�ֵġ�Դ�����еķ������� �����������������⴦�������ռλ����������ʾ

![](./images/placeholder.png)

- **`1** ��ʾһ��ռλ��  
- **`2** ��ʾ����ռλ��  

�����������������ɵ�exe�����е�ʱ���پ��� `JIT����`���ɻ�����   
��Ϊ���е�ʱ���Ѿ�֪��ʹ�õ��������ͣ�`JIT`���ڱ����ʱ�������������ɵ�ռλ���滻�ɾ������������
## ���ܱȽ�
![](./images/performance.png)

���ͷ���  �� ��ͨ���� > Object(װ�����)����

## ����Լ��

��ӡ �̳��� Person��Ķ�������ԣ�

ʹ�÷���Լ��
```cs
public static void Show<T>(T people)
    where T : People
{
    Console.WriteLine($"{people.Id}-{people.Name}");
}
```
ʹ�û��෽��
```cs
public static void ShowBase(People people) {
    Console.WriteLine($"{people.Id}-{people.Name}");
}
```
˼�� ���ͷ��� �� ���෽���� ����  
2�߶�����ʵ�� ��ӡ �������Ե� ����

- ���� ���� ���ö��Լ�� ���� `where T: People, Iworks,ISports` 

## �ο�����
https://www.cnblogs.com/dotnet261010/p/9034594.html
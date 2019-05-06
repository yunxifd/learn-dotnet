using System;
using System.Collections.Generic;
using System.Linq;

namespace MyGeneric
{
    public class CCTest
    {
        public static void Show()
        {
            {
                Bird bird1 = new Bird();
                // 麻雀 也是 鸟
                Bird bird2 = new Sparrow();
                Sparrow sparrow1 = new Sparrow();
                // 鸟不一定是 麻雀
                //Sparrow sparrow2 = new Bird();
            }

            // 对象可以转换 那 泛型中类型 也能转换吗
            {
                List<Bird> birdList1 = new List<Bird>();
                // 应该可以啊 一堆麻雀当然是 一堆鸟了
                // 但是编译器 提示错误
                // 原因 是 泛型类 List<Bird> List<Sparrow> 2个类没有父子关系
                //List<Bird> birdList2 = new List<Sparrow>();

                // 强制类型转换
                List<Bird> birdList3 = new List<Sparrow>().Select(c => (Bird)c).ToList();
            }
            // .net 4.0 的时候 考虑到上面的问题，引入了协变
            // 只能用在 接口 和 委托
            // 查看 IEnumerable
            {
                IEnumerable<Bird> birdList1 = new List<Bird>();
                IEnumerable<Bird> birdList2 = new List<Sparrow>();

                Func<Bird> func = new Func<Sparrow>(() => null);

                ICustomerListOut<Bird> customerList1 = new CustomerListOut<Bird>();
                ICustomerListOut<Bird> customerList2 = new CustomerListOut<Sparrow>();
            }
            // 逆变
            {
                // 逆变 参数类型是输入值的类型
                ICustomerListIn<Sparrow> customerList1 = new CustomerListIn<Bird>();
                //ICustomerListIn<Bird> customerList3 = new CustomerListIn<Sparrow>();
                ICustomerListIn<Sparrow> customerList2 = new CustomerListIn<Sparrow>();
            }
        }
    }

    public class Bird
    {
        public int Id { get; set; }
    }

    public class Sparrow : Bird
    {
        public string Name { get; set; }
    }

    /// <summary>
    ///  out 协变 ，只能作为返回值类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustomerListOut<out T> {
        T Get();
        // 报错 协变类型 只能作为返回值类型
        //void Show(T t);
    }

    public class CustomerListOut<T> : ICustomerListOut<T>
    {
        public T Get()
        {
            return default(T);
        }

        public void Show(T t) {

        }
    }
    /// <summary>
    /// in 逆变 只能用在 方法参数上
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustomerListIn<in T> {
        //T Get();

        void Show(T t);
    }

    public class CustomerListIn<T> : ICustomerListIn<T>
    {
        public void Show(T t)
        {
            throw new System.NotImplementedException();
        }
    }
}

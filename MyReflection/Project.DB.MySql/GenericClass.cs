namespace Project.DB.MySql
{
    public class GenericClass<T1, T2, T3>
    {
        public void Show(T1 t1, T2 t2, T3 t3)
        {
            System.Console.WriteLine($"{t1.GetType().Name} {t2.GetType().Name} {t3.GetType().Name}");
        }
        public T1 Id { get; set; }
        public T2 Name { get; set; }
        public T3 Age { get; set; }
    }
}

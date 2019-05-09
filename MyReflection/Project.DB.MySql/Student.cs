namespace Project.DB.MySql
{
    public class Student
    {
        public Student()
        {
        }
        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public void ShowInfo()
        {
            System.Console.WriteLine($"{this.Id} {this.Name}");
        }

        public void ShowInfo2(int id)
        {
            System.Console.WriteLine(id);
        }
        public void ShowInfo2(int id, string name)
        {
            System.Console.WriteLine($"{Id} {name}");
        }
        public static void StaticShow()
        {
            System.Console.WriteLine("我是静态方法");
        }

        private void PrivateShow()
        {
            System.Console.WriteLine("我是私有方法");
        }
    }
}

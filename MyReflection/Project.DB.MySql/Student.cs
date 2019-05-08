namespace Project.DB.MySql
{
    public class Student
    {
        public Student() {
        }
        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public void ShowInfo() {
            System.Console.WriteLine($"{this.Id} {this.Name}");
        }

        public static void StaticShow() {
            System.Console.WriteLine("我是静态方法");
        }

        public static void PrivateShow()
        {
            System.Console.WriteLine("我是私有方法");
        }
    }
}

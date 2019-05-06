using System;

namespace MyGeneric.models
{
    public class Japanese
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Hi()
        {
            Console.WriteLine("Hi");
        }
    }
}

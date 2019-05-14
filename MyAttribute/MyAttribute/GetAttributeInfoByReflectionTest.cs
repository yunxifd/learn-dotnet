using System;

namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct,AllowMultiple = true)]
    class Author: Attribute
    {
        private string name;
        public double Version;

        public Author(string name)
        {
            this.name = name;
            Version = 1.0;
        }

        public string GetName()
        {
            return name;
        }
    }
    
    [Author("P.Ackerman")]
    public class FirstClass
    {
        
    }
    
    // Class without the Author attribute.  
    public class SecondClass  
    {  
        // ...  
    }  
  
    // Class with multiple Author attributes.  
    [Author("P. Ackerman"), Author("R. Koch", Version = 2.0)]  
    public class ThirdClass  
    {  
        // ...  
    }  

    public static class GetAttributeInfoByReflectionTest
    {
       public static void Test()
        {
            
            PrintAuthorInfo(typeof(FirstClass));  
            PrintAuthorInfo(typeof(SecondClass));  
            PrintAuthorInfo(typeof(ThirdClass));  
        }

        private static void PrintAuthorInfo(Type t)
        {
            Console.WriteLine("Author information for {0}",t);

            var attrs = Attribute.GetCustomAttributes(t);

            foreach (var attr in attrs)
            {
                if (attr is Author)
                {
                    Author a = (Author) attr;
                    Console.WriteLine("{0}, version {1:f}",a.GetName(),a.Version);
                }
            }
        }
    }
}
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ConsoleApp1
{
    internal class HelloWorld
    {
        public int Test = 0;

        public HelloWorld(int test)
        {
            Test = test;
        }
    }


    internal class Program
    {
        static ObservableCollection<HelloWorld> test = new ObservableCollection<HelloWorld>();

        static void Main(string[] args)
        {
            test.Add(new HelloWorld(1));
            test.Add(new HelloWorld(2));

            var singleOrDefault = test.SingleOrDefault(t => t.Test == 3);

            Console.WriteLine("Null:" + (singleOrDefault == null)); // True
            Console.WriteLine("Null:" + (singleOrDefault == default)); // True
            Console.WriteLine("Null:" + (singleOrDefault == default(HelloWorld))); // True
            Console.WriteLine("Null:" + (null == default(HelloWorld))); // True

            singleOrDefault = test.SingleOrDefault(t => t.Test == 3) ?? null; 
            Console.WriteLine("Right Hand Side: " + (singleOrDefault == null)); // True (null not default)

            singleOrDefault = test.SingleOrDefault(t => t.Test == 3) ?? new HelloWorld(5);
            Console.WriteLine("Right Hand Side: " + singleOrDefault.Test); // 5 - False (right hand side)

            singleOrDefault = test.SingleOrDefault(t => t.Test == 2);
            Console.WriteLine("Normal Result: " + singleOrDefault.Test); // 2 - False



            Console.ReadLine();
        }
    }
}

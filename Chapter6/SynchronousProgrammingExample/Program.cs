using System;
using System.Threading;

namespace SynchronousProgrammingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Demonstration-1.A Synchronous Program Demo.***");
            Method1();
            Method2();
            Console.WriteLine("End Main().");
            Console.ReadKey();
        }
        //Method1
        private static void Method1()
        {
            Console.WriteLine("Method1() has started.");
            //Some big task
            Thread.Sleep(1000);
            Console.WriteLine("Method1() has finished.");
        }
        //Method2
        private static void Method2()
        {
            Console.WriteLine("Method2() has started.");
            //Some small task
            Thread.Sleep(100);
            Console.WriteLine("Method2() has finished.");
        }
    }
}

using System;
using System.Threading;

namespace UsingThreadClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Asynchronous Programming Demonstration-1.***");
            //Method1();
            //Old approach.Creating a separate thread for the following task(i.e Method1.)
            Thread newThread = new Thread(() =>
            {
                Console.WriteLine("Method1() has started in a separate thread.");
                //Some big task
                Thread.Sleep(1000);
                Console.WriteLine("Method1() has finished.");
            }
            );
            newThread.Start();
            Thread.Sleep(10);
            Method2();
            Console.WriteLine("End Main().");
            Console.ReadKey();
        }
        //Method1
        //private static void Method1()
        //{            
        //        Console.WriteLine("Method1() has started.");
        //        //Some big task
        //        Thread.Sleep(1000);
        //        Console.WriteLine("Method1() has finished.");           
        //}

        private static void Method2()
        {
            Console.WriteLine("Method2() has started.");
            //Some small task
            Thread.Sleep(100);
            Console.WriteLine("Method2() has finished.");
        }
    }
}

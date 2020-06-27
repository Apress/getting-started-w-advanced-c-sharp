using System;
using System.Threading;

namespace UsingMainThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Working on the main thread and a child Thread only.****");
            Thread.CurrentThread.Name = "Main Thread";
            //Thread.CurrentThread.Priority= ThreadPriority.AboveNormal;
            Thread threadOne = new Thread(Method1);
            //Same as
            //Thread threadOne = new Thread(new ThreadStart(Method1));
            threadOne.Name = "Child Thread-1";
            threadOne.Priority = ThreadPriority.AboveNormal;
            Console.WriteLine("Starting threadOne shortly.");
            //threadOne starts
            threadOne.Start();            
            Console.WriteLine("Inside Main,Thread Name is:{0}", Thread.CurrentThread.Name);
            Console.WriteLine("Inside Main,ManagedThreadId is:{0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Inside Main,Thread Priority is: {0}", Thread.CurrentThread.Priority);
            Console.WriteLine("Control comes at the end of Main() method.");
            Console.ReadKey();
        }
        static void Method1()
        {
            Console.WriteLine("Inside Method1(),Thread Name is:{0}", Thread.CurrentThread.Name);
            Console.WriteLine("Inside Method1(),ManagedThreadId is:{0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Inside Method1(),Thread Priority is:{0}", Thread.CurrentThread.Priority);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Using Method1(), printing the value {0}", i);              
            }
        }
    }
}

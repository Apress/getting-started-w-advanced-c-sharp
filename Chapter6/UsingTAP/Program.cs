using System;
using System.Threading;
using System.Threading.Tasks;

namespace UsingTAP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Using Task-based Asynchronous Pattern.****");
            Console.WriteLine("Inside Main().Thread ID:{0}", Thread.CurrentThread.ManagedThreadId);
            Task taskForMethod1 = new Task(Method1);
            taskForMethod1.Start();
            Method2();
            Console.ReadKey();
        }

        private static void Method1()
        {
            Console.WriteLine("Method1() has started.");
            Console.WriteLine("Inside Method1(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
            //Some big task
            Thread.Sleep(3000);
            Console.WriteLine("Method1() has completed its job now.");
        }

        private static void Method2()
        {
            Console.WriteLine("Method2() has started.");
            Console.WriteLine("Inside Method2(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(100);
            Console.WriteLine("Method2() is completed.");
        }
        
    }
}

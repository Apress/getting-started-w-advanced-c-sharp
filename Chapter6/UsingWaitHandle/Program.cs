using System;
using System.Threading;

namespace UsingWaitHandle
{
    class Program
    {
        public delegate void Method1Delegate(int sleepTimeinMilliSec);
        static void Main(string[] args)
        {
            Console.WriteLine("***Polling and WaitHandle Demo.***");
            Console.WriteLine("Inside Main(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
            //Synchronous call
            //Method1(3000);
            //Asynchrous call using a delegate
            Method1Delegate method1Del = Method1;
            IAsyncResult asyncResult = method1Del.BeginInvoke(3000, null, null);
            Method2();
            //while (!asyncResult.IsCompleted)
            while (true)
            {
                //Keep working in main thread
                Console.Write("*");
                /*
                There are 5 different overload method for WaitOne() 
                Following method blocks the current thread until the current System.Threading.WaitHandle receives
                a signal, using a 32-bit signed integer to specify the time interval in milliseconds.
                */
                if (asyncResult.AsyncWaitHandle.WaitOne(10))                
                {
                    Console.Write("\nResult is available now.");
                    break;
                }
            }
            method1Del.EndInvoke(asyncResult);
            Console.WriteLine("\nExiting Main().");
            Console.ReadKey();
        }
        //Method1
        private static void Method1(int sleepTimeInMilliSec)
        {
            Console.WriteLine("Method1() has started.");
            //It will have a different thread id
            Console.WriteLine("Inside Method1(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
            //Some big task
            Thread.Sleep(sleepTimeInMilliSec);
            Console.WriteLine("\nMethod1() has finished.");

        }
        //Method2
        private static void Method2()
        {
            Console.WriteLine("Method2() has started.");
            //Main thread id and this thread id will be same
            Console.WriteLine("Inside Method2(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
            //Some small task
            Thread.Sleep(100);
            Console.WriteLine("Method2() has finished.");
        }
    }
}

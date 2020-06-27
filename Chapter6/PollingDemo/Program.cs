using System;
using System.Threading;

namespace PollingDemo
{
    class Program
    {
        public delegate void Method1Delegate(int sleepTimeinMilliSec);
        //For Q&A
        //public delegate void Method1ADelegate(int sleepTimeinMilliSec, int dummy);
        static void Main(string[] args)
        {
            Console.WriteLine("***Polling Demo.***");
            Console.WriteLine("Inside Main(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
            //Synchronous call
            //Method1(3000);
            //Asynchronous call using a delegate
            Method1Delegate method1Del = Method1;          
            IAsyncResult asyncResult = method1Del.BeginInvoke(3000, null, null);
            //For Q&A
            // Method1ADelegate method1ADel = Method1A;
            //Passing 111 for second dummy parameter in Method1A
            //IAsyncResult asyncResult1A = method1ADel.BeginInvoke(3000,111, null, null);
            Method2();
            while (!asyncResult.IsCompleted)
            {
                //Keep working in main thread
                Console.Write("*");
                Thread.Sleep(5);
            }

            method1Del.EndInvoke(asyncResult);
            Console.ReadKey();
        }
        //Method1
        private static void Method1(int sleepTimeInMilliSec)
        {
            Console.WriteLine("Method1() has started.");
            Console.WriteLine("Inside Method1(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
            //Some big task
            Thread.Sleep(sleepTimeInMilliSec);
            Console.WriteLine("\nMethod1() has finished.");

        }
        //Method2
        private static void Method2()
        {
            Console.WriteLine("Method2() has started.");
            Console.WriteLine("Inside Method2(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
            //Some small task
            Thread.Sleep(100);
            Console.WriteLine("Method2() has finished.");
        }
        //For Q&A
        //private static void Method1A(int sleepTimeInMilliSec, int dummy)
        //{
        //    Console.WriteLine("Method1() has started.");
        //    Console.WriteLine("Inside Method1(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
        //    //Some big task
        //    Thread.Sleep(sleepTimeInMilliSec);
        //    Console.WriteLine("\nMethod1() has finished.");
        //}
    }
}

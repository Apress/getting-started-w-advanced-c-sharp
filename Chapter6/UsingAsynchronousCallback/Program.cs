using System;
//using System.Data.SqlClient;
//using System.Net;
using System.Threading;

namespace UsingAsynchronousCallback
{
    class Program
    {
        public delegate void Method1Delegate(int sleepTimeinMilliSec);
        static void Main(string[] args)
        {
            Console.WriteLine("***Using Asynchronous Callback.***");
            Console.WriteLine("Inside Main(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
            //Synchronous call
            //Method1(3000);
            //Asynchrous call using a delegate
            Method1Delegate method1Del = Method1;
            //IAsyncResult asyncResult = method1Del.BeginInvoke(3000,Method3, null);
            //For Q&A
            IAsyncResult asyncResult = method1Del.BeginInvoke(3000, Method3, "Method1Delegate, thank you for using me." );

            Method2();
            while (!asyncResult.IsCompleted)
            {
                //Keep working in main thread
                Console.Write("*");
                Thread.Sleep(5);
            }

            method1Del.EndInvoke(asyncResult);
            Console.WriteLine("Exit Main().");
            Console.ReadKey();
            //HttpWebRequest req;
            //SqlCommand cmd;
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
        /*Method3:It's a callback method.This method will be invoked when Method1Delegate 
         completes its work.*/
        private static void Method3(IAsyncResult asyncResult)
        {
            if (asyncResult != null)//if null you can throw some exception
            {
                Console.WriteLine("\nMethod3() has started.");
                Console.WriteLine("Inside Method3(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
                //Do some housekeeping work/ clean-up operation
                Thread.Sleep(100);
                //For Q&A
                String msg = (String)asyncResult.AsyncState;
                Console.WriteLine("Method3() says : '{0}'",msg);
                Console.WriteLine("Method3() has finished.");
            }
        }
    }
}


using System;
using System.Threading;

namespace UsingThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Asynchronous Programming Demonstration.***");
            Console.WriteLine("***Using ThreadPool.***");

            //Using Threadpool
            //Not passing any parameter for Method2
            //ThreadPool.QueueUserWorkItem(new WaitCallback(Method2));
            //For Q&A
            ThreadPool.QueueUserWorkItem(Method2);
            //Passing 10 as the parameter for Method3
            ThreadPool.QueueUserWorkItem(new WaitCallback(Method3), 10);
            Method1();

            Console.WriteLine("End Main().");
            Console.ReadKey();
        }

        private static void Method1()
        {
            Console.WriteLine("-Method1() has started.");
            //Some big task
            Thread.Sleep(1000);
            Console.WriteLine("-Method1() has finished.");
        }

        /*The following method's signature should match the delegate WaitCallback.
          It is as follows:
          public delegate void WaitCallback(object state)
        */
        //private static void Method2()//Compilation error
        private static void Method2(Object state)
        {
            Console.WriteLine("--Method2() has started.");
            //Some small task
            Thread.Sleep(100);
            Console.WriteLine("--Method2() has finished.");
        }
        /*
        The following method has a parameter.
        This method's signature matches the WaitCallBack delegate signature.
        Notice that this method also matches the ParameterizedThreadStart delegate signature; 
        because it has a single parameter of type Object and this method doesn't return a value.
        */
        static void Method3(Object number)
        {
            Console.WriteLine("---Method3() has started.");
            int upperLimit = (int)number;
            for (int i = 0; i < upperLimit; i++)
            {
                Console.WriteLine("---Method3() prints 3.0{0}", i);
            }
            Thread.Sleep(100);
            Console.WriteLine("---Method3() has finished.");
        }

    }
}

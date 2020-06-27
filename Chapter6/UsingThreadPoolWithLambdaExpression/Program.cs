using System;
using System.Threading;

namespace UsingThreadPoolWithLambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Asynchronous Programming Demonstration.***");
            Console.WriteLine("***Using ThreadPool with Lambda Expression.***");

            //Using Threadpool
            //Not passing any parameter for Method2
            ThreadPool.QueueUserWorkItem(Method2);
            //Using lambda Expression
            //Here the method needs a parameter(input).
            //Passing 10 as the parameter for Method3
            ThreadPool.QueueUserWorkItem(
                (number) =>
                {
                    Console.WriteLine("--Method3() has started.");
                    int upperLimit = (int)number;
                    for (int i = 0; i < upperLimit; i++)
                    {
                        Console.WriteLine("---Method3() prints 3.0{0}", i);
                    }
                    Thread.Sleep(100);
                    Console.WriteLine("--Method3() has finished.");
                }, 10

                );

            Method1();
            Console.WriteLine("End Main().");
            Console.ReadKey();
        }

        private static void Method1()
        {
            Console.WriteLine("-Method1() has started.");
            //Some task
            Thread.Sleep(500);
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
            //Some task
            Thread.Sleep(100);
            Console.WriteLine("--Method2() has finished.");
        }

    }
}

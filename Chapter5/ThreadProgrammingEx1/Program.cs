using System;
using System.Threading;

namespace ThreadProgrammingDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Thread Demonstration-1****");
            Console.WriteLine("Main thread has started.");

            Thread threadOne = new Thread(Method1);
            //Same as
            //Thread threadOne = new Thread(new ThreadStart(Method1));

            Thread threadTwo = new Thread(Method2);
            //Same as
            //Thread threadTwo = new Thread(new ThreadStart(Method2));    

            Console.WriteLine("Starting threadOne shortly.");
            //threadOne starts
            threadOne.Start();
            //threadOne.Start();//run-time error if thread is already started
            Console.WriteLine("Starting threadTwo shortly.");
            //threadTwo starts
            threadTwo.Start();
            Console.WriteLine("Control comes at the end of Main() method.");
            Console.ReadKey();
        }
        static void Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("-ThreadOne from Method1() prints {0}", i);
                //Console.WriteLine("Thread.CurrentThread.Name={0}", Thread.CurrentThread.Name);
            }
        }
        static void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("--ThreadTwo from Method2() prints 2.0{0}", i);
            }
        }
    }
}

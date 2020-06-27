using System;
using System.Threading;

namespace ThreadProgrammingEx2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Thread Demonstration-2****");
            Console.WriteLine("***Exploring Join() method.It helps to make a thread wait for another running thread to finish it's job.***");
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
            Console.WriteLine("Starting threadTwo shortly.");
            //threadTwo starts
            threadTwo.Start();

            //Waiting for threadOne to finish
            threadOne.Join();//Will cause exception if the thread hasn't started
            //Waiting for threadtwo to finish
            threadTwo.Join();

            Console.WriteLine("Control comes at the end of Main() method.");
            Console.ReadKey();
        }
        static void Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("-ThreadOne from Method1() prints {0}", i);
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

using System;
using System.Threading;

namespace ThreadProgrammingEx5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Dealing methods with return types.These methods run in different threads.***");
            int myInt = 0;//Initial value
            Console.WriteLine($"Inside Main(),ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
            Thread threadOne = new Thread(
                () => {
                    Console.WriteLine($"Method1() is executing in ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
                    //Do some activity/task
                    myInt = 5;//An arbitrary value                    
                });

            string myStr = "Failure";//Initial value
            Thread threadTwo = new Thread(
                () => {
                    Console.WriteLine($"Method2() is executing in ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
                    //Do some activity/task
                    myStr = "Success.";
                });

            Console.WriteLine("Starting threadOne shortly.");
            //threadOne starts
            threadOne.Start();
            Console.WriteLine("Starting threadTwo shortly.");
            //threadTwo starts
            threadTwo.Start();
            //threadOne.Abort();//Will terminate the thread

            //Waiting for threadOne to finish
            threadOne.Join();
            //Waiting for threadtwo to finish
            threadTwo.Join();
            Console.WriteLine($"Method1() returns {myInt}");
            Console.WriteLine($"Method2() returns {myStr} ");
            Console.WriteLine("Control comes at the end of Main() method.");
            Console.ReadKey();
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace UsingTAPDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Using Task-based Asynchronous Pattern.Using lambda expression into it.****");
            Console.WriteLine("Inside Main().Thread ID:{0}", Thread.CurrentThread.ManagedThreadId);
            //Task taskForMethod1 = new Task(Method1);
            //taskForMethod1.Start();
            Task<string> taskForMethod1 = Method1();
            //Wait for task to complete.It’ll be no more asynchonous now.
            //taskForMethod1.Wait();
            //Continue the task
            //The taskForMethod3 will continue once taskForMethod1 is finished
            //Task taskForMethod3 = taskForMethod1.ContinueWith(Method3, TaskContinuationOptions.OnlyOnRanToCompletion);
            //For Q&A
            //taskForMethod3= taskForMethod1.ContinueWith(Method4, TaskContinuationOptions.OnlyOnRanToCompletion);
            //Task taskForMethod4 = taskForMethod3.ContinueWith(Method4, TaskContinuationOptions.OnlyOnRanToCompletion);

            Method2();
            Console.WriteLine("Task for Method1 was a : {0}", taskForMethod1.Result);
            Console.ReadKey();
        }
        //Using lambda expression
        private static Task<string> Method1()
        {
            return Task.Run(() =>
            {
                string result = "Failure";
                try
                {
                    Console.WriteLine("Inside Method1(),Task.id={0}", Task.CurrentId);
                    Console.WriteLine("Method1() has started.");
                    Console.WriteLine("Inside Method1(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
                    //Some big task
                    Thread.Sleep(3000);
                    Console.WriteLine("Method1() has completed its job now.");
                    result = "Success";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught:{0}", ex.Message);
                }
                return result;
            }
            );
        }

        private static void Method2()
        {
            Console.WriteLine("Method2() has started.");
            Console.WriteLine("Inside Method2(),Thread id {0} .", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(100);
            Console.WriteLine("Method2() is completed.");
        }
        private static void Method3(Task task)
        {
            Console.WriteLine("Method3 starts now.");
            Console.WriteLine("Task.id is:{0} with Thread id is :{1} ", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(20);
            Console.WriteLine("Method3 for Task.id {0} and Thread id {1} is completed.", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
        }
        //Method4 added for Q&A
        private static void Method4(Task task)
        {
            Console.WriteLine("Method4 starts now.");
            Console.WriteLine("Task.id is:{0} with Thread id is :{1} ", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(10);
            Console.WriteLine("Method4 for Task.id {0} and Thread id {1} is completed.", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
        }
    }
}

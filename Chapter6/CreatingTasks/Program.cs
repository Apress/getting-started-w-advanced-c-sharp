using System;
using System.Threading;
using System.Threading.Tasks;

namespace CreatingTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Using different ways to create tasks.****");
            Console.WriteLine("Inside Main().Thread ID:{0}", Thread.CurrentThread.ManagedThreadId);

            #region Different ways to create and execute task
            //Using constructor
            Task taskOne = new Task(MyMethod);
            taskOne.Start();
            //Using task factory
            TaskFactory taskFactory = new TaskFactory();
            //StartNew Method creates and starts a task.
            //It has different overloaded version.
            Task taskTwo = taskFactory.StartNew(MyMethod);
            //Using task factory via a task           
            Task taskThree = Task.Factory.StartNew(MyMethod);
            #endregion            
            Console.ReadKey();
        }

       private static void MyMethod()
        {
            Console.WriteLine("Task.id={0} with Thread id {1} has started.", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
            //Some task
            Thread.Sleep(100);
            Console.WriteLine("MyMethod for Task.id={0} and Thread id {1} is completed.", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
        }
    }
}

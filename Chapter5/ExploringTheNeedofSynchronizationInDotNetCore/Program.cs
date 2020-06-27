using System;
using System.Threading;

namespace ExploringTheNeedofSynchronizationInDotNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Exploring Thread Synchronization.****");
            Console.WriteLine("***We are beginning with a non-synchronized version.****");
            Thread.CurrentThread.Name = "Main Thread";
            Console.WriteLine("Main thread has started already.");

            SharedResource sharedObject = new SharedResource();

            Thread threadOne = new Thread(sharedObject.SharedMethod);
            threadOne.Name = "Child Thread-1";

            Thread threadTwo = new Thread(sharedObject.SharedMethod);
            threadTwo.Name = "Child Thread-2";
            //Child Thread-1 starts.
            threadOne.Start();
            //Child Thread-2 starts.
            threadTwo.Start();

            //Waiting for Child Thread-1 to finish.
            threadOne.Join();
            //Waiting for Child Thread-2 to finish.
            threadTwo.Join();
            Console.WriteLine("The {0} exits now.", Thread.CurrentThread.Name);
            Console.ReadKey();
        }
    }
    class SharedResource
    {
        public void SharedMethod()
        {
            Console.Write(Thread.CurrentThread.Name + " has entered in the shared location. \n");
            Thread.Sleep(3000);
            Console.Write(Thread.CurrentThread.Name + " exits.\n");
        }
    }
}

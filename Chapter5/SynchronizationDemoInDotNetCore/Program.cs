using System;
//using System.Text;
using System.Threading;

namespace SynchronizationDemoInDotNetCore
{
    class Program
    {
        //To demonstrate the case with a static method
        //private static StringBuilder strLock = new StringBuilder();
        static void Main(string[] args)
        {
            Console.WriteLine("***Exploring Thread Synchronization.****");
            Console.WriteLine("***Here we have a synchronized version.We are using the concept of lock.****");
            Thread.CurrentThread.Name = "Main Thread";
            Console.WriteLine("Main thread has started already.");

            SharedResource sharedObject = new SharedResource();
            //Thread threadOne = new Thread(SharedMethod2);//To demonstrate static method
            Thread threadOne = new Thread(sharedObject.SharedMethod);
            threadOne.Name = "Child Thread-1";

            //Thread threadTwo = new Thread(SharedMethod2);//To demonstrate static method
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
        /*
         //To demonstrate the case with a static method
        public static void SharedMethod2()
        {
            lock (strLock)
            {
                Console.Write(Thread.CurrentThread.Name + " has entered in the shared location. \n");
                Thread.Sleep(3000);
                Console.Write(Thread.CurrentThread.Name + " exits.\n");
            }
        }
        */


    }

    class SharedResource
    {
        private object myLock = new object();
        //private int myLock = new int();//not correct
        public void SharedMethod()
        {
            lock (myLock)
            {
                Console.Write(Thread.CurrentThread.Name + " has entered in the shared location. \n");
                Thread.Sleep(3000);

                Console.Write(Thread.CurrentThread.Name + " exits.\n");
            }

            /*
            //lock internally wraps Monitor’s Entry and Exit method in a  try...finally block.
            try
            {
                Monitor.Enter(myLock);
                Console.Write(Thread.CurrentThread.Name + " has entered in the shared location. \n");
                Thread.Sleep(3000);
                Console.Write(Thread.CurrentThread.Name + " exits.\n");
            }
            finally
            {
                Monitor.Exit(myLock);
            }

            */
        }
    }

}


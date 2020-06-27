using System;
using System.Threading;

namespace DeadlockDemoInDotNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Exploring Deadlock with an incorrect design of application.****");

            Thread.CurrentThread.Name = "Main Thread";
            Console.WriteLine("Main thread has started already.");

            SharedResource sharedObject = new SharedResource();
            Thread threadOne = new Thread(sharedObject.SharedMethodOne);
            threadOne.Name = "Child Thread-1";

            Thread threadTwo = new Thread(sharedObject.SharedMethodTwo);
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
        private object myFirstLock = new object();
        private object mySecondLock = new object();
        public void SharedMethodOne()
        {
            lock (myFirstLock)
            {
                Console.Write(Thread.CurrentThread.Name + " has entered into first part of SharedMethodOne. \n");
                Thread.Sleep(1000);
                Console.Write(Thread.CurrentThread.Name + " exits SharedMethodOne--first part.\n");

                lock (mySecondLock)
                {
                    Console.Write(Thread.CurrentThread.Name + " has entered into last part of SharedMethodOne. \n");
                    Thread.Sleep(1000);

                    Console.Write(Thread.CurrentThread.Name + " exits SharedMethodOne--last part.\n");
                }
            }
        }
        public void SharedMethodTwo()
        {
            lock (mySecondLock)
            {
                Console.Write(Thread.CurrentThread.Name + " has entered into first part of SharedMethodTwo. \n");
                Thread.Sleep(1000);

                Console.Write(Thread.CurrentThread.Name + " exits SharedMethodTwo--first part.\n");

                lock (myFirstLock)
                {
                    Console.Write(Thread.CurrentThread.Name + " has entered into last part of SharedMethodTwo. \n");
                    Thread.Sleep(1000);
                    Console.Write(Thread.CurrentThread.Name + " exits SharedMethodTwo--last part.\n");
                }
            }
        }
    }

}



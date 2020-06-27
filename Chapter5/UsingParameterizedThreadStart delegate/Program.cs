using System;
using System.Threading;

namespace UsingParameterizedThreadStart_delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***ParameterizedThreadStart delegate is used in this demonstration****");
            Console.WriteLine("Main thread has started.");

            Thread threadOne = new Thread(Method1);
            //Same as
            //Thread threadOne = new Thread(new ThreadStart(Method1));

            Thread threadTwo = new Thread(Method2);
            //Same as
            //Thread threadTwo = new Thread(new ThreadStart(Method2));

            Thread threadThree = new Thread(Method3);
            //Same as
            //Thread threadThree = new Thread(new ParameterizedThreadStart(Method3));            

            Console.WriteLine("Starting threadOne shortly.");
            //threadOne starts
            threadOne.Start();
            Console.WriteLine("Starting threadTwo shortly.");
            //threadTwo starts
            threadTwo.Start();

            Console.WriteLine("Starting threadThree shortly.Here we use ParameterizedThreadStart delegate.");
            //threadThree starts
            threadThree.Start(15);

            //Waiting for threadOne to finish
            threadOne.Join();
            //Waiting for threadtwo to finish
            threadTwo.Join();
            //Waiting for threadthree to finish
            threadThree.Join();
            Console.WriteLine("Main() method ends now.");
            //For  background thread discussion
            //Thread threadFour = new Thread(Method1);
            //Console.WriteLine("Is threadFour is a background thread?:{0} ", threadFour.IsBackground);
            //Thread threadFive = new Thread(Method1);
            //threadFive.IsBackground = true;
            //Console.WriteLine("Is threadFive is a background thread?:{0} ", threadFive.IsBackground);
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

        /*
        The following method has an object parameter.
        This method matches the ParameterizedThreadStart delegate signature;
        because it has a single parameter of type Object and this method doesn't return a value.
        */

        static void Method3(Object number)
        {
            int upperLimit = (int)number;
            for (int i = 0; i < upperLimit; i++)
            {
                Console.WriteLine("---ThreadThree from Method3() prints 3.0{0}", i);
            }
        }
    }
}


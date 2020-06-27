using System;
using System.Threading;

namespace ThreadProgrammingEx4
{
    class Boundaries
    {
        public int lowerLimit;
        public int upperLimit;
        public Boundaries(int lower, int upper)
        {
            lowerLimit = lower;
            upperLimit = upper;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Thread Demonstration-4****");
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

            Thread threadFour = new Thread(Method4);
            //Same as
            //Thread threadThree = new Thread(new ParameterizedThreadStart(Method4));

            Console.WriteLine("Starting threadOne shortly.");
            //threadOne starts
            threadOne.Start();
            Console.WriteLine("Starting threadTwo shortly.");
            //threadTwo starts
            threadTwo.Start();

            Console.WriteLine("Starting threadThree shortly.Here we use ParameterizedThreadStart delegate.");
            //threadThree starts
            threadThree.Start(15);

            Console.WriteLine("Starting threadFour shortly.Here we use ParameterizedThreadStart delegate.");
            //threadFour starts
            threadFour.Start(new Boundaries(0, 10));

            //Waiting for threadOne to finish
            threadOne.Join();
            //Waiting for threadtwo to finish
            threadTwo.Join();
            //Waiting for threadthree to finish
            threadThree.Join();

            Console.WriteLine("Main() method ends now.");
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
        The following method has an object parameter
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


        /*
         The following method also has one parameter.
         This method matches the ParameterizedThreadStart delegate signature;
         because it has a single parameter of type Object and this method doesn't return a value.
        */

        static void Method4(Object limits)
        {
            Boundaries boundaries = (Boundaries)limits;
            int lowerLimit = boundaries.lowerLimit;
            int upperLimit = boundaries.upperLimit;
            for (int i = lowerLimit; i < upperLimit; i++)
            {
                Console.WriteLine("---ThreadFour from Method4() prints 4.0{0}", i);
            }
        }
    }
}

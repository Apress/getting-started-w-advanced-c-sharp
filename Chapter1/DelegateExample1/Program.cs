using System;

namespace DelegateExample1
{
    delegate int DelegateWithTwoIntParameterReturnInt(int x, int y);

    class Program
    {
        public static int Sum(int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***A simple delegate demo.***");
            Console.WriteLine("\n Calling Sum(..) method without using a delegate:");
            Console.WriteLine("Sum of 10 and 20 is : {0}", Sum(10, 20));

            //Creating a delegate instance
            //DelegateWithTwoIntParameterReturnInt delOb = new DelegateWithTwoIntParameterReturnInt(Sum);
            //Or,simply write as follows:
            DelegateWithTwoIntParameterReturnInt delOb = Sum;
            Console.WriteLine("\nCalling Sum(..) method using a delegate.");
            int total = delOb(10, 20);
            Console.WriteLine("Sum of 10 and 20 is: {0}", total);

            //Alternative way to calculate the aggregate of the numbers.
            //delOb(25,75) is shorthand for delOb.Invoke(25,75)
            Console.WriteLine("\nUsing Invoke() method on delegate instance, calculating sum of 25 and 75.");
            total = delOb.Invoke(25,75);            
            Console.WriteLine("Sum of 25 and 75 is: {0}", total);
            Console.ReadKey();
        }
    }
}


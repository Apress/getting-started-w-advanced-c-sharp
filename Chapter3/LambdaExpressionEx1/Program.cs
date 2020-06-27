using System;

namespace LambdaExpressionEx1
{
    public delegate int Mydel(int x, int y);

    class Program
    {
        public static int Sum(int a, int b) { return a + b; }

        static void Main(string[] args)
        {
            Console.WriteLine("***Exploring the use of a lambda expression and comparing it with other techniques. ***");
            // Without using delgates or lambda expression
            Console.WriteLine(" Using a normal method.");
            int a = 21, b = 79;
            Console.WriteLine(" Invoking the Sum() method in a common way without using a delegate.");
            Console.WriteLine("Sum of {0} and {1} is : {2}", a, b, Sum(a, b));

            // Using Delegate(Initialization with a named method)
            Mydel del1 = new Mydel(Sum);
            Console.WriteLine("\n Using delegate now.");
            Console.WriteLine("Invoking the Sum() method with the use of a delegate.");
            Console.WriteLine("Sum of {0} and {1} is : {2}", a, b, del1(a, b));

            // Using anonymous method (C# 2.0 onwards)
            Mydel del2 = delegate (int x, int y) { return x + y; };
            Console.WriteLine("\n Using anonymous method now.");
            Console.WriteLine("Invoking the Sum() method using an anonymous method.");
            Console.WriteLine("Sum of {0} and {1} is : {2}", a, b, del2(a, b));

            // Using lambda expression(C# 3.0 onwards)
            Console.WriteLine("\n Using lambda expression now.");
            Mydel sumOfTwoIntegers = (x, y) => x + y;
            Console.WriteLine("Sum of {0} and {1} is : {2}", a, b, sumOfTwoIntegers(a, b));
            Console.ReadKey();
        }
    }

}

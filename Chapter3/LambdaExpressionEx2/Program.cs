using System;

namespace LambdaExpressionEx2
{
    class Program
    {
        public delegate void DelegateWithNoParameter();
        public delegate int DelegateWithOneIntParameter(int x);
        public delegate void DelegateWithTwoIntParameters(int x, int y);
        static void Main(string[] args)
        {

            Console.WriteLine("***Experimenting lambda expressions with different parameters.***\n");
            //Without lambda exp.
            Method1(5, 10);

            //Using Lambda expression
            //Console.WriteLine("\nStarted using lambda expressions with different parameters");
            DelegateWithNoParameter delWithNoParam = () => Console.WriteLine("Using lambda expression with no parameter, printing Hello");
            delWithNoParam();

            DelegateWithOneIntParameter delWithOneIntParam = (x) => x * x;
            Console.WriteLine("\nUsing a lambda expression with one parameter, square of 5 is {0}", delWithOneIntParam(5));

            DelegateWithTwoIntParameters delWithTwoIntParam = (int x, int y) =>
            {
                Console.WriteLine("\nUsing lambda expression with two parameters.");
                Console.WriteLine("It is called a statement lambda because it has a block of statements in it's body.");
                Console.WriteLine("This lambda accepts two parameters.");

                int sum = x + y;
                Console.WriteLine("Sum of {0} and {1} is {2}", x, y, sum);
            };

            delWithTwoIntParam(10, 20);
            Console.ReadKey();
        }

        private static void Method1(int a, int b)
        {
            Console.WriteLine("\nThis is Method1() without lambda expression.");
            int sum = a + b;
            Console.WriteLine("Sum of {0} and {1} is {2}", a, b, sum);
        }
    }
}

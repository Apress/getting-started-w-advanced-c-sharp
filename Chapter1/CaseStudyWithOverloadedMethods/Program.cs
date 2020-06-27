using System;

namespace CaseStudyWithOverloadedMethods
{
    delegate int DelegateWithTwoIntParameterReturnInt(int x, int y);
    class Program
    {
        public static int Sum(int a, int b)
        {
            return a + b;
        }
        public static int Sum(int a, int b, int c)
        {
            return a + b + c;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***A case study with overloaded methods.***");
            DelegateWithTwoIntParameterReturnInt delOb = Sum;
            Console.WriteLine("\nCalling Sum(..) method using a delegate.");
            int total = delOb(10, 20);
            Console.WriteLine("Sum of 10 and 20 is: {0}", total);
            Console.ReadKey();
        }
    }
}

using System;

namespace ExpressionBodiedMethodDemo
{
    class Test
    {
        public int CalculateSum1(int a, int b)
        {
            int sum = a + b;
            return sum;
        }
        /*
        Expression-bodied method is not available in C#5
        C#6.0 onwards,you can use same expression syntax to    define a non-lambda method within a class
        It is ok for single expression, i.e. for 
        expression lambda syntax,but not for statement lambda.
        */

        public int CalculateSum2(int a, int b) => a + b;//ok 

        //Following causes compile-time error
        //For expression-bodied methods, you cannot use statement lambda 
        //int CalculateSum3(int a, int b) =>{            
        //    int sum = a + b;       
        //    return sum;
        //}
}
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Experimenting lambda expression with expression-bodied method.***\n");
            //Using Normal method
            Test test = new Test();
            int result1 = test.CalculateSum1(5, 7);
            Console.WriteLine("\nUsing a normal method, CalculateSum1(5, 7) results: {0}", result1);
            //Using expression syntax 
            int result2 = test.CalculateSum2(5, 7);
            Console.WriteLine("\nUsing expression syntax for CalculateSum2(5,7),result is: {0}", result2);
            Console.ReadKey();
        }
    }
}
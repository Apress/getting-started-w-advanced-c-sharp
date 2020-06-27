using System;

namespace UsingTuplesInLambdaExp
{
    delegate Tuple<int, double> MakeDoubleDelegate(Tuple<int, double> input);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Using Tuples in Lambda Expression.***");
            var inputTuple = Tuple.Create(1, 2.3);
            Console.WriteLine("Content of input tuple is as follows:");
            Console.WriteLine("First Element: " + inputTuple.Item1);
            Console.WriteLine("Second Element: " + inputTuple.Item2);
            var resultantTuple = MakeDoubleMethod(inputTuple);

            Console.WriteLine("\nPassing tuple as an input argument in a normal method which again returns a tuple.");
            Console.WriteLine("Content of resultant tuple is as follows:");
            Console.WriteLine("First Element: " + resultantTuple.Item1);
            Console.WriteLine("Second Element: " + resultantTuple.Item2);

            Console.WriteLine("\nUsing delegate and lambda expression with tuple now.");
            MakeDoubleDelegate delegateObject =
                (Tuple<int, double> input) => Tuple.Create(input.Item1 * 2, input.Item2 * 2);
            var resultantTupleUsingLambda= delegateObject(inputTuple);
            Console.WriteLine("Using lambda expression, the content of resultant tuple is as follows:");
            Console.WriteLine("First Element: " + resultantTupleUsingLambda.Item1);
            Console.WriteLine("Second Element: " + resultantTupleUsingLambda.Item2);
            Console.ReadKey();
        }
        static Tuple<int, double> MakeDoubleMethod(Tuple<int, double> input)
        {
            return Tuple.Create(input.Item1 * 2, input.Item2 * 2);
        }
    }

}

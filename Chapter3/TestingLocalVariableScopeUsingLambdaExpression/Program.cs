using System;
using System.Collections.Generic;
using System.Linq;


namespace TestingLocalVariableScopeUsingLambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Testing local variable scope with a lambda expression.***\n");
            #region Using query syntax
            // /* Inside lambda Expression,you can access the variable that are in scope (at that location).*/
            int midPoint = 5;
            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var myQueryAboveMidPoint = from i in intList
                                       where i > midPoint
                                       select i;
            Console.WriteLine("Numbers above mid point(5) in intList are as follows:");
            foreach (int number in myQueryAboveMidPoint)
            {
                Console.WriteLine(number);
            }
            #endregion
            #region Using method call syntax 
            // Alternative way( using method call syntax)
            Console.WriteLine("Using a lambda expression, numbers above mid point(5) in intList are as follows:");
            IEnumerable<int> numbersAboveMidPoint = intList.Where(x => x > midPoint);
            foreach (int number in numbersAboveMidPoint)
            {
                Console.WriteLine(number);
            }
            #endregion            
            Console.ReadKey();
        }
    }

}

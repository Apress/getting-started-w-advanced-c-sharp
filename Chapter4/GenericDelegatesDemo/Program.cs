using System;

namespace GenericDelegatesDemo
{
    class Program
    {
        //Custom delegate
        //public delegate string Mydel(string n, int r, double d);
        //For Q&A
        //public delegate void CustomAction<in T1, in T2, in T3>(T1 arg1, T2 arg2, T3 arg3);
        static void Main(string[] args)
        {
            Console.WriteLine("***Using Generic Delegates.***");
            //Func
            Console.WriteLine("Using Func delegate now.");
            Func<string, int, double,string> empOb = new Func<string, int, double,string>(DisplayEmployeeDetails);
            Console.WriteLine(empOb("Amit", 1,1025.75));
            Console.WriteLine(empOb("Sumit", 2,3024.55));
            //Using custom delegate
            //Console.WriteLine("<---Using custom delegate--->");
            //Mydel myDelOb = DisplayEmployeeDetails;
            //Console.WriteLine(myDelOb("Amit", 1, 1025.75));
            //For Q&A
            //Func<string, int, string> empOb2 = new Func<string, int,string>(DisplayEmployeeDetailsShortForm);
            //Console.WriteLine(empOb2("Amit",1));

            //Action
            Console.WriteLine("Using Action delegate now.");
            //Action<int, int, int> sum = new Action<int, int, int>(CalculateSumOfThreeInts);
            Action<int, int, int> sum = CalculateSumOfThreeInts;
            sum(10, 3, 7);
            sum(5, 10, 15);
            //Error:Keyword 'void' cannot be used in this context
            //Func<int, int, int, void> sum2 = new Func<int, int, int, void>(CalculateSumOfThreeInts);//error
            //For Q&A
            //Console.WriteLine("Using user-defined generic delegate to subsitute Action delegate now.");
            //CustomAction<int, int, int> sum2 = new CustomAction<int, int, int>(CalculateSumOfThreeInts);
            //sum2(10, 3, 7);

            //Predicate
            Console.WriteLine(" Using Predicate delegate now.");
            Predicate<int> isGreater = new Predicate<int>(IsGreaterThan100);
            Console.WriteLine("101 is greater than 100? {0}", isGreater(101));
            Console.WriteLine("99 is greater than 100? {0}", isGreater(99));

            Console.ReadKey();
        }
        private static string DisplayEmployeeDetails(string name, int empId, double salary)
        {
            return string.Format("Employee Name:{0},id:{1}, salary:{2}$", name, empId,salary);
        }
        private static void CalculateSumOfThreeInts(int i1, int i2, int i3)
        {
            int sum = i1 + i2 + i3;
            Console.WriteLine("Sum of {0},{1} and {2} is: {3}", i1, i2, i3, sum);
        }
        private static bool IsGreaterThan100(int input)
        {
            return input > 100 ? true : false;
        }
        //For Q&A
        //private static string DisplayEmployeeDetailsShortForm(string name, int empId)
        //{
        //    return string.Format("Employee Name:{0},id:{1}", name, empId);
        //}
    }
}


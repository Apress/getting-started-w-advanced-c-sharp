using System;

namespace TestingStaticData
{
    class MyGenericClass<T>
    {
        public static int count;
        public void IncrementMe()
        {
            Console.WriteLine($"Incremented value is : {++count}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Testing static in the context of generic programming.***");
            MyGenericClass<int> intOb = new MyGenericClass<int>();
            Console.WriteLine("\nUsing intOb now.");
            intOb.IncrementMe();//1
            intOb.IncrementMe();//2
            intOb.IncrementMe();//3

            Console.WriteLine("\nUsing strOb now.");
            MyGenericClass<string> strOb = new MyGenericClass<string>();
            strOb.IncrementMe();//1
            strOb.IncrementMe();//2

            Console.WriteLine("\nUsing doubleOb now.");
            MyGenericClass<double> doubleOb = new MyGenericClass<double>();
            doubleOb.IncrementMe();//1
            doubleOb.IncrementMe();//2

            MyGenericClass<int> intOb2 = new MyGenericClass<int>();
            Console.WriteLine("\nUsing intOb2 now.");
            intOb2.IncrementMe();//4
            intOb2.IncrementMe();//5           

            Console.ReadKey();
        }
    }
}

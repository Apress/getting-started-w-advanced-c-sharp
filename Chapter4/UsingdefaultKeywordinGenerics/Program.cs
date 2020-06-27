using System;

namespace UsingdefaultKeywordinGenerics
{
    class MyClass
    {
        //Some other stuff as per need
    }
    struct MyStruct
    {
        //Some other stuff as per need
    }
    class Program
    {
        static void PrintDefault<T>()
        {
            //T defaultValue = null;//will not work for value types
            //T defaultValue = 0;//will not work for reference types
            T defaultValue = default(T);
            string printMe = String.Empty;
            printMe = (defaultValue == null) ? "null" : defaultValue.ToString();
            Console.WriteLine("Default value of {0} is {1}", typeof(T), printMe);
            //C#6.0 onwards,you can use interpolated string
            //Console.WriteLine($"Default value of {typeof(T)} is {printMe}.");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***Using default keyword in Generic Programming.***");
            PrintDefault<int>();//0
            PrintDefault<double>();//0
            PrintDefault<bool>();//False
            PrintDefault<string>();//null
            PrintDefault<int?>();//null
            PrintDefault<System.Numerics.Complex>();//(0,0)
            PrintDefault<System.Collections.Generic.List<int>>();//null
            PrintDefault<System.Collections.Generic.List<string>>();//null
            PrintDefault<MyClass>();//null
            PrintDefault<MyStruct>();
            Console.ReadKey();
        }
    }
}

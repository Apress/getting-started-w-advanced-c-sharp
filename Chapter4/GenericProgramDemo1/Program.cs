using System;

namespace GenericProgramDemo1
{
    class GenericClassDemo<T>
    {
        public T Display(T value)
        {
            return value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Introduction to Generic Programming.***");
            GenericClassDemo<int> myGenericClassIntOb = new GenericClassDemo<int>();
            Console.WriteLine("Display method returns :{0}", myGenericClassIntOb.Display(1));
            GenericClassDemo<string> myGenericClassStringOb = new GenericClassDemo<string>();
            Console.WriteLine("Display method returns :{0}", myGenericClassStringOb.Display("A generic method is called."));
            GenericClassDemo<double> myGenericClassDoubleOb = new GenericClassDemo<double>();
            Console.WriteLine("Display method returns :{0}", myGenericClassDoubleOb.Display(12.345));
            Console.ReadKey();
        }
    }
}


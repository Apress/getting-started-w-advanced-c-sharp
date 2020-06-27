using System;
using System.Collections.Generic;

namespace GenericProgramDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Using Generics to avoid run-time error.***");
            List<int> myList = new List<int>();            
            myList.Add(1);
            myList.Add(2);
            //Compile time error:Cannot convert from 'string' to 'int'
            //myList.Add("InvalidElement");
            foreach (int myInt in myList)
            {
                Console.WriteLine((int)myInt);//downcasting
                //Additional information: Cannot modify the collection
                //myList.Add(15);//Run-time exception
            }
            Console.ReadKey();
        }
    }
}

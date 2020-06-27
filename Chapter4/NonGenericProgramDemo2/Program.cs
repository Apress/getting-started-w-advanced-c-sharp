using System;
using System.Collections;

namespace NonGenericProgramDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Use Generics to avoid runtime error***");
            ArrayList myList = new ArrayList();
            myList.Add(1);
            myList.Add(2);
            //No compile time error
            myList.Add("InvalidElement");
            foreach (int myInt in myList)
            {
                //Will encounter run-time exception for the final element which is not an int
                Console.WriteLine((int)myInt); //downcasting
            }
            Console.ReadKey();
        }
    }
}


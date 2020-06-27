using System;

namespace MulticastDelegateExample1
{
    delegate void MultiDelegate();
    class Program
    {
        public static void MethodOne()
        {
            Console.WriteLine("A static method of Program class- MethodOne() executed.");
            /* For Q&A 1.6
            //Let's say, some code causes an exception
            //like the following
            int a = 10, b = 0,c;
            c = a / b;
            Console.WriteLine("c={0}",c);
            */
        }
        public static void MethodTwo()
        {
            Console.WriteLine("A static method of Program class- MethodTwo() executed.");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***Example of a Multicast Delegate.***");
            // Target a static method
            MultiDelegate multiDel = MethodOne;
            // Target another static method
            multiDel += MethodTwo;
            //Target an instance method
            multiDel += new OutsideProgram().MethodThree;
            multiDel();
            //Reducing the delegate chain
            Console.WriteLine("\nReducing the length of delegate chain by discarding MethodTwo now.");
            multiDel -= MethodTwo;
            //The following invocation will call MethodOne and MethodThree now.
            multiDel();
            Console.ReadKey();
        }
    }
    class OutsideProgram
    {
        public void MethodThree()
        {
            Console.WriteLine("An instance method of OutsideProgram class is executed.");
        }
    }
}

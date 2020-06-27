using System;

namespace MulticastDelegateExample2
{
    delegate int MultiDelegate();
    class Program
    {
        public static int MethodOne()
        {
            Console.WriteLine("A static method of Program class- MethodOne() executed.");
            return 1;
        }
        public static int MethodTwo()
        {
            Console.WriteLine("A static method of Program class- MethodTwo() executed.");            
            return 2;
        }
        public static int MethodThree()
        {
            Console.WriteLine("A static method of Program class- MethodThree() executed.");
            return 3;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***A case study with a multicast delegate when we target non-void methods.***");
            // Target MethodOne
            MultiDelegate multiDel = MethodOne;
            // Target MethodTwo
            multiDel += MethodTwo;
            // Target MethodThree
            multiDel += MethodThree;
            int finalValue=multiDel();
            Console.WriteLine("The final value is {0}", finalValue);
            Console.ReadKey();
        }
    }  
}

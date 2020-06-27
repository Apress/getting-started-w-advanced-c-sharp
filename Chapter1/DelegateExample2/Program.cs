using System;

namespace DelegateExample2
{
    delegate int DelegateWithTwoIntParameterReturnInt(int x, int y);
    ////For Q&A 1.9
    //delegate OutSideProgram ConsGenerator();
    class Program
    {
        public static int Sum(int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***Comparing the behavior of a static method and  instance method when assign them to a delegate instance.***");
            
            Console.WriteLine("Assigning a static method to a delegate object.");
            //Assigning a static method to a delegate object.
            DelegateWithTwoIntParameterReturnInt delOb = Sum;
            Console.WriteLine("Calling Sum(..) method of Program Class using a delegate.");
            int total = delOb(10, 20);
            Console.WriteLine("Sum of 10 and 20 is: {0}", total);
            Console.WriteLine("delOb.Target={0}", delOb.Target);
            Console.WriteLine("delOb.Target==null? {0}", delOb.Target == null);//true
            Console.WriteLine("delOb.Method={0}", delOb.Method);//delOb.Method=Int32 Sum(Int32, Int32)

            OutSideProgram outsideOb = new OutSideProgram();
            ////For Q&A 1.9
            //ConsGenerator consGenerator = () =>
            //{
            //    return new OutSideProgram();
            //};
            //consGenerator();

            Console.WriteLine("\nAssigning an instance method to a delegate object.");
            //Assigning an instance method to a delegate object.
            delOb = outsideOb.CalculateSum;
            Console.WriteLine("Calling CalculateSum(..) method of OutsideProgram class using a delegate.");
            total = delOb(50, 70);
            Console.WriteLine("Sum of 50 and 70 is: {0}", total);
            Console.WriteLine("delOb.Target={0}", delOb.Target);//delOb.Target=DelegateEx1.OutSideProgramClass
            Console.WriteLine("delOb.Target==null? {0}", delOb.Target == null);//false
            Console.WriteLine("delOb.Method={0}", delOb.Method);//delOb.Method=Int32 Sum(Int32, Int32)
            Console.ReadKey();
        }
    }
    class OutSideProgram
    {
        ////For Q&A 1.9
        //public OutSideProgram()
        //{
        //    Console.WriteLine("\nOutSideProgram constructor is called.");
        //}
        public int CalculateSum(int x, int y)
        {
            return x + y;
        }

    }
}



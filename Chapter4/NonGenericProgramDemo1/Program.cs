using System;

namespace NonGenericProgramDemo1
{
    class NonGenericEx
    {
        public int DisplayMyInteger(int myInt)
        {
            return myInt;
        }
        public string DisplayMyString(string myStr)
        {
            return myStr;
        }
        //public double DisplayMyDouble(double myDouble)
        //{
        //    return myDouble;
        //}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***A non-generic program demonstration.***");
            NonGenericEx nonGenericOb = new NonGenericEx();
            Console.WriteLine("DisplayMyInteger returns :{0}", nonGenericOb.DisplayMyInteger(123));
            Console.WriteLine("DisplayMyString returns :{0}", nonGenericOb.DisplayMyString("DisplayMyString method inside NonGenericEx is called."));
            //Console.WriteLine("ShowDouble returns :{0}", nonGenericOb.DisplayMyDouble(25.5));//error
            
            Console.ReadKey();
        }
    }
}

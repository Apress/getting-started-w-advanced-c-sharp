using System;

namespace MethodOverridingDemo
{
    class BaseClass<T>
    {
       public virtual T MyMethod(T param)
        {
            Console.WriteLine("Inside BaseClass.BaseMethod()");
            return param;
        }
    }
    class DerivedClass<T>: BaseClass<T>
    {
        public override T MyMethod(T param)        
        {
            Console.WriteLine("Here I'm inside of DerivedClass.DerivedMethod()");
            return param;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Overriding a virtual method.***\n");
            BaseClass<int> intBase = new BaseClass<int>();
            //Invoking Parent class method
            Console.WriteLine($"Parent class method returns {intBase.MyMethod(25)}");//25
            //Now pointing to the child class method and invoking it.
            intBase = new DerivedClass<int>();
            Console.WriteLine($"Derived class method returns {intBase.MyMethod(25)}");//25
            //The following will cause compile-time error
            //intBase = new DerivedClass<double>();//error
            Console.ReadKey();
        }
    }
}

using System;

namespace ImplementingGenericInterface
{
    interface GenericInterface<T>
    {
        //A generic method
        T GenericMethod(T param);
        //A non-generic method
        public void NonGenericMethod();

    }
    //Implementing the interface
    class ConcreteClass<T> : GenericInterface<T>
    {
        //Implementing interface method
        public T GenericMethod(T param)
        {
            return param;
        }

        public void NonGenericMethod()
        {
            Console.WriteLine("Implementing NonGenericMethod of GenericInterface<T>");
        }
    }

    #region For Q&A and analysis section
    // class ConcreteClass2 : GenericInterface<T>//Error
    //class ConcreteClass2<U> : GenericInterface<T>//Error
    //class ConcreteClass2<U,T> : GenericInterface<T>//valid
    class ConcreteClass2<T, U> : GenericInterface<T>//also valid
    {
        public T GenericMethod(T param)
        {
            throw new NotImplementedException();
        }

        public void NonGenericMethod()
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Implementing generic interfaces.***\n");
            //Using 'int' type
            GenericInterface<int> concreteInt = new ConcreteClass<int>();
            int myInt = concreteInt.GenericMethod(5);
            Console.WriteLine($"The value stored in myInt is : {myInt}");
            concreteInt.NonGenericMethod();

            //Using 'string' type now
            GenericInterface<string> concreteString = new ConcreteClass<string>();
            string myStr = concreteString.GenericMethod("Hello Reader");
            Console.WriteLine($"The value stored in myStr is : {myInt}");
            concreteString.NonGenericMethod();

            Console.ReadKey();
        }
    }
}

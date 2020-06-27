using System;

namespace CovarianceWithGenericDelegates
{
    //A generic delegate with covariant return type
    //(Notice the use of 'out' keyword)

    delegate TResult CovDelegate<out TResult>();
    
    //Here 'out' is not used(i.e. it is non-covariant)
    //delegate TResult CovDelegate<TResult>();

    class Vehicle
    {
        //Some code if needed
    }
    class Bus : Vehicle
    {
        //Some code if needed
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Testing covariance with a Generic Delegate.***");
            Console.WriteLine("Normal usage:");
            CovDelegate<Vehicle> covVehicle = GetOneVehicle;
            covVehicle();
            CovDelegate<Bus> covBus = GetOneBus;
            covBus();
            //Testing Covariance
            //covBus to covVehicle (i.e. more specific-> more general) is allowed through covariance
            Console.WriteLine("Using covariance now.");
            //Following assignment is Ok, if you use 'out' in delegate definition
            //Otherwise, you'll receive compile-time error
            covVehicle = covBus;//Still ok
            covVehicle();
            Console.WriteLine("End covariance testing.\n");
            Console.ReadKey();
        }

        private static Vehicle GetOneVehicle()
        {
            Console.WriteLine("Creating one vehicle and returning it.");
            return new Vehicle();
        }
        private static Bus GetOneBus()
        {
            Console.WriteLine("Creating one bus and returning the bus.");
            return new Bus();
        }
    }
}

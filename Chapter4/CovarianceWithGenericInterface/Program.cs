using System;
using System.Collections.Generic;

namespace CovarianceWithGenericInterface
{
    class Vehicle
    {
        public virtual void ShowMe()
        {
            Console.WriteLine("Vehicle.ShowMe().The hash code is : " + GetHashCode());
        }
    }
    class Bus : Vehicle
    {
        public override void ShowMe()
        {
            Console.WriteLine("Bus.ShowMe().Here the hash code is : " + GetHashCode());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Covariance Example
            Console.WriteLine("***Using Covariance with Generic Interface.***\n");
            Console.WriteLine("**Remember that T in IEnumerable<T> is covariant");
            //Some Parent objects
            //Vehicle vehicle1 = new Vehicle();
            //Vehicle vehicle2 = new Vehicle();
            //Some Bus objects
            Bus bus1 = new Bus();
            Bus bus2 = new Bus();
            //Creating a child List
            //List<T> implements IEnumerable<T>
            List<Bus> busList = new List<Bus>();
            busList.Add(bus1);
            busList.Add(bus2);
            IEnumerable<Bus> busEnumerable = busList;
            /*
             An object which was instantiated with a more derived type argument (Bus) 
            is assigned to an object instantiated with a less derived type argument(Vehicle).
            Assignment compatibility is preserved here.
            */
            IEnumerable<Vehicle> vehicleEnumerable = busEnumerable;
            foreach (Vehicle vehicle in vehicleEnumerable)
            {
                vehicle.ShowMe();
            }
            
            Console.ReadKey();
        }
    }
}


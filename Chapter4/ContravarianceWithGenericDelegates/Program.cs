using System;

namespace ContravarianceWithGenericDelegates
{
    //A generic contravariant delegate
    delegate void ContraDelegate<in T>(T t);
    //A generic non-contravariant delegate
    //delegate void ContraDelegate<T>(T t);
    class Vehicle
    {
        public virtual void ShowMe()
        {
            Console.WriteLine(" Vehicle.ShowMe()");
        }
    }
    class Bus : Vehicle
    {
        public override void ShowMe()
        {
            Console.WriteLine(" Bus.ShowMe()");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Testing Contra-variance with Generic Delegates.***");
            Vehicle obVehicle = new Vehicle();
            Bus obBus = new Bus();
            Console.WriteLine("Normal usage:");
            ContraDelegate<Vehicle> contraVehicle = ShowVehicleType;
            contraVehicle(obVehicle);
            ContraDelegate<Bus> contraBus = ShowBusType;
            contraBus(obBus);
            Console.WriteLine("Using contravariance now.");
            /*
            Using general type to derived type.
            Following assignment is Ok, if you use 'in' in delegate definition.
            Otherwise, you'll receive compile-time error.
            */
            contraBus = contraVehicle;//ok
            contraBus(obBus);
            Console.ReadKey();
        }

        private static void ShowVehicleType(Vehicle vehicle)
        {
            vehicle.ShowMe();
        }
        private static void ShowBusType(Bus bus)
        {
            bus.ShowMe();
        }
    }
}

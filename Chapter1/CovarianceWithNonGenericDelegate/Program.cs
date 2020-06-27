using System;

namespace CovarianceWithNonGenericDelegate
{
    class Vehicle
    {
        public Vehicle CreateVehicle()
        {
            Vehicle myVehicle = new Vehicle();
            Console.WriteLine(" Inside Vehicle.CreateVehicle, a vehicle object is created.");
            return myVehicle;
        }
    }
    class Bus : Vehicle
    {
        public Bus CreateBus()
        {
            Bus myBus = new Bus();
            Console.WriteLine(" Inside Bus.CreateBus, a bus object is created.");
            return myBus;
        }
    }

    class Program
    {
        public delegate Vehicle VehicleDelegate();
        static void Main(string[] args)
        {
            Vehicle vehicleOb = new Vehicle();
            Bus busOb = new Bus();
            Console.WriteLine("***Testing covariance with delegates.It is allowed C# 2.0 onwards.***\n");
            //Normal case:
            /* VehicleDelegate is expecting a method 
             with return type Vehicle.*/
            VehicleDelegate vehicleDelegate1 = vehicleOb.CreateVehicle;
            vehicleDelegate1();
            /*VehicleDelegate is expecting a method with return type Vehicle(i.e. a basetype)
            but you're assigning a method with return type Bus( a derived type)
            Covariance allows this kind of assignment.*/
            VehicleDelegate vehicleDelegate2 = busOb.CreateBus;
            vehicleDelegate2();
            Console.ReadKey();
        }
    }

}

using System;

namespace ContravarianceWithNonGenegicDelegate
{
    class Vehicle
    {
        public void ShowVehicle(Vehicle myVehicle)
        {
            Console.WriteLine("Vehicle.ShowVehicle is called.");
            Console.WriteLine("myVehicle.GetHashCode() is: {0}", myVehicle.GetHashCode());
        }
    }
    class Bus : Vehicle
    {
        public void ShowBus(Bus myBus)
        {
            Console.WriteLine("Bus.ShowBus is called.");
            Console.WriteLine("myBus.GetHashCode() is: {0}", myBus.GetHashCode());
        }
    }

    class Program
    {
        public delegate void BusDelegate(Bus bus);
        static void Main(string[] args)
        {
            Console.WriteLine("***Demonstration-7.Exploring Contravariance with non-generic delegates***");
            Vehicle myVehicle = new Vehicle();
            Bus myBus = new Bus();
            //Normal case
            BusDelegate busDelegate = myBus.ShowBus;
            busDelegate(myBus);

            //Special case
            //Contravariance:
            /*
             * Note that the following delegate expected a method that accepts 
             a Bus(derived) object parameter but still it can point to the method 
             that accepts Vehicle(base) object parameter
             */
            BusDelegate anotherBusDelegate = myVehicle.ShowVehicle;
            anotherBusDelegate(myBus);
            //Additional note:you cannot pass vehicle object here
            //anotherBusDelegate(myVehicle);//error
            Console.ReadKey();
        }
    }
}

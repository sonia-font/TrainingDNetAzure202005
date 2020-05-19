using Parking_App.Parking;
using Parking_App.Vehicles;
using System;

namespace Parking_App
{
    class Program
    {
        static void Main(string[] args)
        {
            int wheels;
            int minutes;
            string confirm;

            Console.WriteLine("Welcome to the parking metering administrarion");

            do
            {
                do
                {
                    Console.WriteLine("How many wheels will have the vehicle on your parking?");
                    wheels = Convert.ToInt32(Console.ReadLine());
                    if (wheels % 2 != 0)
                    {
                        Console.WriteLine("Wheels cannot be impair");
                    }
                } while (wheels % 2 != 0);

                Console.WriteLine("How much time did you stay?");
                minutes = Convert.ToInt32(Console.ReadLine());

                if (wheels == 2)
                {
                    Vehicle vehicle = new Vehicle(new ParkingBike(wheels), minutes);
                    vehicle.GetRate();
                }
                else if (wheels == 4)
                {
                    Vehicle vehicle = new Vehicle(new ParkingCar(wheels), minutes);
                    vehicle.GetRate();
                }
                else
                {
                    Vehicle vehicle = new Vehicle(new ParkingTruck(wheels), minutes);
                    vehicle.GetRate();
                }

                do
                {
                    Console.WriteLine("Do you want to continue? [Y/N]");
                    confirm = Console.ReadLine();
                    if (confirm != "Y" && confirm != "N")
                    {
                        Console.WriteLine("Key must be Y or N");
                    }
                } while (confirm != "Y" && confirm != "N");

            } while (confirm == "Y");              
        }
    }
}

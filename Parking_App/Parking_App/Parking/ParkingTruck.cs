using Parking_App.Interfaces;
using Parking_App.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking_App.Parking
{
    class ParkingTruck : IParking
    {
        public int _numberOfWheels;

        public ParkingTruck(int wheels)
        {
            _numberOfWheels = wheels;
        }

        public double CalculateRate(int minutes)
        {
            return minutes * _numberOfWheels;
        }

        public void FindVehicle()
        {
            Console.WriteLine("Finding a Truck");
        }

        public void ParkVehicle()
        {
            Console.WriteLine("Parking a Truck");
        }
    }
}

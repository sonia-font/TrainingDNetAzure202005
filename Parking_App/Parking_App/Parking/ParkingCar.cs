using Parking_App.Interfaces;
using Parking_App.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking_App.Parking
{
    class ParkingCar : IParking
    {
        public int _numberOfWheels;

        public ParkingCar(int wheels)
        {
            _numberOfWheels = wheels;
        }

        public double CalculateRate(int minutes)
        {
            return minutes * _numberOfWheels;
        }

        public void FindVehicle()
        {
            Console.WriteLine("Finding a Car");
        }

        public void ParkVehicle()
        {
            Console.WriteLine("Parking a Car");
        }
    }
}

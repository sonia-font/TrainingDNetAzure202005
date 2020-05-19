using Parking_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking_App.Vehicles
{
    class Vehicle
    {              
        public double _rate;

        public Vehicle(IParking parkingVehicle, int minutes)
        {
            parkingVehicle.ParkVehicle();
            parkingVehicle.FindVehicle();
            _rate = parkingVehicle.CalculateRate(minutes);
        }

        public void GetRate()
        {
            Console.WriteLine("rate is " + _rate);
        }
    }
}

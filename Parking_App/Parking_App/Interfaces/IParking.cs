using System;
using System.Collections.Generic;
using System.Text;

namespace Parking_App.Interfaces
{
    public interface IParking
    {
        public void FindVehicle();
        public void ParkVehicle();
        public double CalculateRate(int minutes);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Parking_App.Interfaces
{
    public interface IParking
    {
        void FindVehicle();
        void ParkVehicle();
        double CalculateRate(int minutes);
    }
}

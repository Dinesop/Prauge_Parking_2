using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class AppConfig
    {
        public int numberOfParkingSpots { get; set; } = 6;
        public List<string> allowedVehicleTypes { get; set; } = new List<string> { "Car", "Motorcycle" };
        public int totalCapacity { get; set; } = 4;

        public AppConfig()
        {
            
        }
    }
}

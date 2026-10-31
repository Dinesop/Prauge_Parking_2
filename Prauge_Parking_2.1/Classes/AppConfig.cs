using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class AppConfig
    {
        public int NumberOfParkingSpots { get; set; } = 100;
        public List<string> AllowedVehicleTypes { get; set; } = new List<string> { "Car", "Motorcycle" };
        public int TotalCapacity { get; set; } = 4;
        public string ConfigFilePath { get; set; } = "ConfigFile"; 
        // I am not adding the file-ending here because I want to be able to add numbers into the string if needed at CheckExsistingParkingGarage() backup handling

        public string ParkingGarageFilePath { get; set; } = "ParkingGarage";

        public AppConfig()
        {
            
        }
    }
}

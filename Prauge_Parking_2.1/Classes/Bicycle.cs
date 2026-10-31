using Prauge_Parking_2._0.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._1.Classes
{
    public class Bicycle : IVehicle
    {
        public int Size { get ; set; }
        public string VehicleType { get; set; }
        public decimal Price { get; set; }
        public string LicencePlate { get; set; }
        public DateTime CheckIn { get; set; }

        public Bicycle(string licencePlate, AppConfig appConfig)
        {
            Size = appConfig.VehicleSetup["Bicycle"];
            VehicleType = "Bicycle";
            Price = appConfig.VehiclePrices["Bicycle"];
            LicencePlate = licencePlate;
            CheckIn = DateTime.UtcNow;
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._1.Classes
{
    public class Motorcycle : IVehicle
    {
        public int Size { get; set; }
        public string VehicleType { get; set; }
        public decimal Price { get; set; }
        public string LicencePlate { get; set; }
        public DateTime CheckIn { get; set; }

        /* ---------- Constructors ---------- */
        public Motorcycle(string licencePlate, AppConfig appConfig)
        {
            Size = appConfig.VehicleSetup["Motorcycle"];
            VehicleType = "Motorcycle";
            Price = appConfig.VehiclePrices["Motorcycle"];
            LicencePlate = licencePlate;
            CheckIn = DateTime.UtcNow;
        }
    }

}

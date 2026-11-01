using Prauge_Parking_2._1.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Prauge_Parking_2._1.Classes
{
    public class Bus : IVehicle
    {
        public string LicencePlate { get; set; }
        public int Size { get; set; }
        public DateTime CheckIn { get; set; }
        public string VehicleType { get; set; }
        public decimal Price { get; set; }
        /* ---------- Constructors ---------- */
        [JsonConstructor]
        public Bus()
        {

        }
        public Bus(string licencePlate, AppConfig appConfig)
        {
            Size = appConfig.VehicleSetup["Bus"];
            VehicleType = "Bus";
            Price = appConfig.VehiclePrices["Bus"];
            LicencePlate = licencePlate;
            CheckIn = DateTime.UtcNow;
        }
    }
}

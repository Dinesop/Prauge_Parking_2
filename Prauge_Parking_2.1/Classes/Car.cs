using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    
    public class Car : IVehicle
    {
        /* ---------- Properties ---------- */
        public int Size { get; set; }
        public string VehicleType { get; set; }
        public decimal Price { get; set; }
        public string LicencePlate { get; set; }
        public DateTime CheckIn { get; set ; }

        /* ---------- Constructors ---------- */
        public Car()
        {
            
        }
        public Car(string licencePlate, AppConfig appConfig)
        {
            Size = appConfig.VehicleSetup["Car"];
            VehicleType = "Car";
            Price = appConfig.VehiclePrices["Car"];
            LicencePlate = licencePlate;
            CheckIn = DateTime.UtcNow;
        }
        
    }
}

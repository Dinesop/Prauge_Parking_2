using Prauge_Parking_2._0.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._1.Classes
{
    public class Bicycle : Vehicle
    {
        public override int Size { get ; set; }
        public override string VehicleType { get; set; }
        public override decimal Price { get; set; }

        public Bicycle(string licencePlate, AppConfig appConfig) : base(licencePlate, appConfig)
        {
            Size = 1;
            VehicleType = "Bicycle";
            Price = appConfig.VehiclePrices["Bicycle"];
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class Motorcycle : Vehicle
    {
        public override int Size { get; set; }
        public override string VehicleType { get; set; }
        public override decimal Price { get; set; }

        /* ---------- Constructors ---------- */
        public Motorcycle(string licencePlate) : base(licencePlate)
        {
            Size = 2;
            VehicleType = "Motorcycle";
            Price = 10M;
        }
    }

}

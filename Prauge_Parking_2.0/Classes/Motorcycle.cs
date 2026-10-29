using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class Motorcycle : Vehicle
    {
        public override int Size { get; }
        public override string VehicleType { get; }
        public override decimal Price { get; }

        /* ---------- Constructors ---------- */
        public Motorcycle() : base()
        {
            Size = 2;
            VehicleType = "Motorcycle";
            Price = 10M;
        }
    }

}

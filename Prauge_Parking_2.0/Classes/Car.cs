using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    
    public class Car : Vehicle
    {
        public override int Size { get; }
        public override string VehicleType { get; }
        /* ---------- Constructors ---------- */
        public Car()  :base ()
        {
            Size = 4;
            VehicleType = "Car";
        }
        
    }
}

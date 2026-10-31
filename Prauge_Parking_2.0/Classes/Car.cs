using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    
    public class Car : IVehicle
    {
        /* ---------- Properties ---------- */
        public override int Size { get; set; }
        public override string VehicleType { get; set; }
        public override decimal Price { get; set; }
        /* ---------- Constructors ---------- */
        public Car()
        {
            
        }
        public Car(string licencePlate)  :base (licencePlate)
        {
            Size = 4;
            VehicleType = "Car";
            Price = 20M;
        }
        
    }
}

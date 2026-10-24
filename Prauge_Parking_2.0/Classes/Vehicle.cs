using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public abstract class Vehicle
    {
        /* ---------- Properties ---------- */
        // TODO: Setup so properties becomes read-only and is set and then "immutable" in the constructor
        public string LicencePlate { get; set; }
        public int Size { get; set; }

        /* ---------- Constructors ---------- */
        public Vehicle(string licencePlate)
        {
            LicencePlate = licencePlate;
            //Size = size;
        }

    }
}

using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public abstract class Vehicle
    {
        /* ---------- Properties ---------- */
        // TODO: Setup so properties becomes read-only and is set and then "immutable" in the constructor, se exempel i anteckningar från F15.
        public string LicencePlate { get; }
        public abstract int Size { get; }
        public DateTime CheckIn { get; }

        public abstract string VehicleType { get; }

        /* ---------- Constructors ---------- */
        public Vehicle()
        {
            LicencePlate = PrintOut.getLicencePlate();
            CheckIn = DateTime.UtcNow;
        }

    }
}

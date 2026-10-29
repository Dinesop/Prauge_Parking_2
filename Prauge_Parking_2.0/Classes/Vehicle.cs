using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public abstract class Vehicle
    {
        /* ---------- Properties ---------- */ 
        public string LicencePlate { get; }
        public abstract int Size { get; }
        public DateTime CheckIn { get; }
        public abstract string VehicleType { get; }
        public abstract decimal Price { get; }

        /* ---------- Constructors ---------- */
        public Vehicle()
        {
            LicencePlate = PrintOut.getLicencePlate();
            CheckIn = DateTime.UtcNow;
        }

        
        

    }
}

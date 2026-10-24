using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class Motorcycle : Vehicle
    {
        /* ---------- Constructors ---------- */
        public Motorcycle(string licencePlate) : base(licencePlate)
        {
            Size = 2;
            LicencePlate = licencePlate;
        }
    }

}

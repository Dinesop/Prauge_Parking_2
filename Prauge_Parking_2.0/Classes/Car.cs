using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class Car : Vehicle
    {
        /* ---------- Constructors ---------- */
        public Car(string licencePlate) : base(licencePlate)
        {
            Size = 4;
            LicencePlate = licencePlate;
        }
    }
}

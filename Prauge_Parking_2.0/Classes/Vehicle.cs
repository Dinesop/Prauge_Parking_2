using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public abstract class Vehicle
    {
        /* ---------- Fields ---------- */
        private string _licencePlate;
        private int _size;

        /* ---------- Properties ---------- */
        public string LicencePlate { get { return _licencePlate; } set { _licencePlate = value; } }
        public int Size { get { return _size; } set { _size = value; } }

        /* ---------- Constructors ---------- */
        public Vehicle(string licencePlate)
        {
            LicencePlate = licencePlate;
        }
    }
}

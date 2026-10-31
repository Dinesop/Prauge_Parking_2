using Class_Library_PP2;
using Prauge_Parking_2._1.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Prauge_Parking_2._1.Classes
{
    public interface IParkingGarage
    {
        /* ---------- Fields ---------- */

        public List<ParkingSpot> ParkingSpots { get; set; }


    }

}

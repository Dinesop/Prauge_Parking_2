using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class Receipt 
    {
        public Vehicle ParkedVehicle { get; }
        public TimeSpan ParkedDuration { get; }
        public int ParkingSpotId { get; }
        public Receipt(ParkingSpot parkingSpot, TimeSpan parkedDuration, Vehicle foundVehicle)
        {
            ParkedVehicle = foundVehicle;
            ParkedDuration = parkedDuration;
            ParkingSpotId = parkingSpot.ParkingSpotId;
        }
    }
}

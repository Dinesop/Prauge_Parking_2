using Prauge_Parking_2._0.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._1.Classes
{
    public interface IParkingSpot
    {
        public int ParkingSpotId { get; set; }
        public bool IsEmpty { get; set; }
        public List<IVehicle> ParkedVehicles { get; set; }
        public int TotalCapacity { get; set; }
        public int RemainingSize { get; set; }
    }
}

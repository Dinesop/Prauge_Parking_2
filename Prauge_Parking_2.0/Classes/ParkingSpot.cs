using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class ParkingSpot
    {
        /* ---------- Properties ---------- */
        public int ParkingSpotId { get; }
        public bool IsOccupied { get; set; }
        public Vehicle ParkedVehicle { get; set; }

        /* ---------- Constructors ---------- */
        public ParkingSpot(int parkingSpotId)
        {
            ParkingSpotId = parkingSpotId;
            IsOccupied = false;
        }

        /* ---------- Methods ---------- */
        public bool ParkVehicleOnEmptySpot(Vehicle vehicle)
        {
            ParkedVehicle = vehicle;
            IsOccupied = true;

            return true; // Gemini förklarade att man lägger in bool returns för att kunna kontrollera om den kör som planerat i framtiden. Först hade jag det bara som en to do men pillade runt och testade olika saker för att lösa problemet att samma fordon parkerades på ALLA lediga platser och nu får den vara kvar där. 
        }

        public void VacateParkingSpot()
        {
            IsOccupied = false;
            ParkedVehicle = null;
        }

    }
}

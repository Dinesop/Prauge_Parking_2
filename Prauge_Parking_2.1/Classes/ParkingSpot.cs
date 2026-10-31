using Class_Library_PP2;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Prauge_Parking_2._0.Classes
{
    public class ParkingSpot
    {
        /* ---------- Properties ---------- */
        public int ParkingSpotId { get; set; }
        public bool IsEmpty { get; set; }
        public List<IVehicle> ParkedVehicles { get; set;  } = new List<IVehicle>(); 
        public int TotalCapacity { get; set; }
        public int RemainingSize { get; set; }

        /* ---------- Constructors ---------- */
        public ParkingSpot()
        {
            
        }
        public ParkingSpot(int parkingSpotId,int totalCapacity)
        {
            ParkingSpotId = parkingSpotId;
            IsEmpty = true;
            TotalCapacity = totalCapacity;
            RemainingSize = totalCapacity;
        }

        /* ---------- Methods ---------- */
        public bool ParkVehicleOnSpot(IVehicle vehicle)
        {
            ParkedVehicles.Add(vehicle);
            RemainingSize -= vehicle.Size;
            IsEmpty = false;

            return true; // Gemini förklarade att man lägger in bool returns för att kunna kontrollera om den kör som planerat i framtiden. Först hade jag det bara som en to do men pillade runt och testade olika saker för att lösa problemet att samma fordon parkerades på ALLA lediga platser och nu får den vara kvar där. 
        }

        public void VacateVehicleSpot(IVehicle vehicle)
        {
            RemainingSize += vehicle.Size;
            ParkedVehicles.Remove(vehicle);

            if (RemainingSize == TotalCapacity)
            {
                IsEmpty = true;
            }
            else
            {
                IsEmpty = false;
                

            }
        }
    }
}

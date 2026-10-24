using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class ParkingGarage
    {
        /* ---------- Fields ---------- */
        // TODO: Göra om fältet till en egenskap.
        private List<ParkingSpot> _parkingSpots = new List<ParkingSpot>(); // En lista som innehåller många objekt av typen ParkingSpot


        /* ---------- Constructors ---------- */
        public ParkingGarage(int totalSpots)
        { // Vi skapar (instansierar) ett parkingSpot-objekt för varje parkeringsplats i huset
            for (int i = 1; i <= totalSpots; i++)
            {
                _parkingSpots.Add(new ParkingSpot(i));
            }
        }

        /* ---------- Methods ---------- */
        public void FindFirstEmptyParkingSpot(Vehicle vehicle)
        { // since the vehicle class can't access the parkingspot class without going through the parking garage we must have a main method in parking garage that reaches into parkingspot to park a vehicle.
            foreach (var spot in _parkingSpots)
            {
                if (!spot.IsOccupied)
                {
                    spot.ParkVehicleOnEmptySpot(vehicle);
                    break;
                }
            }
        }
        public ParkingSpot FindLicencePlateInParkingSpot(string requestedLicencePlate)
        { // TODO: Suggested LINQ query from Gemini to simplify the search 
          // LINQ Query: "Give me the first spot where IsOccupied is false"
          // ParkingSpot currentSpot = GetAllParkingSpots().FirstOrDefault(spot => !spot.IsOccupied);
            
            foreach (var spot in _parkingSpots)
            { // added spot.IsOccupied to avoid null exceptions. Consider changing to a try-catch?
                if(spot.IsOccupied && spot.ParkedVehicle.LicencePlate == requestedLicencePlate)
                {
                    return spot;
                } 
            }
            return null; // TODO: Set up an enum with errorcodes?

        }
        public ParkingSpot FindParkingSpotId(int parkingSpotId)
        { // TODO: Suggested LINQ query from Gemini to simplify the search 
          // LINQ Query: "Give me the first spot where IsOccupied is false"
          // ParkingSpot currentSpot = GetAllParkingSpots().FirstOrDefault(spot => !spot.IsOccupied);

            foreach (var spot in _parkingSpots)
            { // added spot.IsOccupied to avoid null exceptions. Consider changing to a try-catch?
                if(spot.ParkingSpotId == parkingSpotId)
                {
                    return spot;
                } 
            }
            return null; // TODO: Set up an enum with errorcodes?
        }

        public void RetriveVehicle(string requestedLicencePlate)
        {
            ParkingSpot currentSpot = FindLicencePlateInParkingSpot(requestedLicencePlate);
            TimeSpan parkedDuration = currentSpot.ParkedVehicle.CheckIn - DateTime.UtcNow;
            currentSpot.VacateParkingSpot();
        }

        public void MoveVehicle(string requestedLicencePlate, int requestedNewSpot)
        {
            ParkingSpot currentSpot = FindLicencePlateInParkingSpot(requestedLicencePlate);
            ParkingSpot newSpot = FindParkingSpotId(requestedNewSpot);

            newSpot.ParkedVehicle = currentSpot.ParkedVehicle;
            newSpot.IsOccupied = true;

            currentSpot.VacateParkingSpot();
        }
    }
}



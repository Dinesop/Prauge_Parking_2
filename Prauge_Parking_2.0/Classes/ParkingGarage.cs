using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class ParkingGarage
    {
        /* ---------- Fields ---------- */
        // TODO: Göra om fältet till en egenskap.  - 27/10: later 
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
        public ParkingSpot FindFirstEmptyParkingSpot(Vehicle vehicle)
        { // since the vehicle class can't access the parkingspot class without going through the parking garage we must have a main method in parking garage that reaches into parkingspot to park a vehicle.
            foreach (var spot in _parkingSpots)
            {

                if (spot.RemainingSize >= vehicle.Size)
                {
                        spot.ParkVehicleOnSpot(vehicle);
                        return spot;
                }
                else continue;
            }
            return null;
        }
        public ParkingSpot FindLicencePlateInParkingSpot(string requestedLicencePlate)
        { 
            foreach (var spot in _parkingSpots)
            {
                Vehicle foundVehicle = CollectVehicleFromLicencePlate(spot, requestedLicencePlate);
                if (foundVehicle != null)
                {
                    return spot;
                }
            }
            return null; // TODO: Set up an enum with errorcodes?  - 27/10: later 

        }
        public Vehicle FindLicencePlate(string requestedLicencePlate)
        { 
            Vehicle vehicleInGarage = _parkingSpots.SelectMany(spot => spot.ParkedVehicles).FirstOrDefault(v => v.LicencePlate == requestedLicencePlate);
            return vehicleInGarage; 
        }
        public ParkingSpot FindParkingSpotId(int parkingSpotId)
        { // TODO: Suggested LINQ query from Gemini to simplify the search ?  - 27/10: later 
            foreach (var spot in _parkingSpots)
            { 
                if (spot.ParkingSpotId == parkingSpotId)
                {
                    return spot;
                }
            }
            return null; 
        }
        public Receipt RetriveVehicle(string requestedLicencePlate)
        {
            ParkingSpot currentSpot = FindLicencePlateInParkingSpot(requestedLicencePlate);
            Vehicle foundVehicle = CollectVehicleFromLicencePlate(currentSpot, requestedLicencePlate);
            TimeSpan parkedDuration = foundVehicle.CheckIn - DateTime.UtcNow;
            Receipt endedParking = new Receipt(currentSpot, parkedDuration, foundVehicle);
            currentSpot.VacateVehicleSpot();
            return endedParking;
        }
        public void MoveVehicle(string requestedLicencePlate, int requestedNewSpot)
        {
            ParkingSpot currentSpot = FindLicencePlateInParkingSpot(requestedLicencePlate);
            Vehicle foundVehicle = CollectVehicleFromLicencePlate(currentSpot, requestedLicencePlate);
            ParkingSpot newSpot = FindParkingSpotId(requestedNewSpot);
            if (newSpot.RemainingSize >= foundVehicle.Size)
            {
                newSpot.ParkVehicleOnSpot(foundVehicle);
                currentSpot.VacateVehicleSpot();
                PrintOut.parkVehicleAtSpot(newSpot, foundVehicle);
            }
            else PrintOut.parkingSpotIsFull(newSpot, foundVehicle);
                
        }

        public static Vehicle CollectVehicleFromLicencePlate(ParkingSpot parkingSpot, string requestedLicencePlate)
        {
            Vehicle foundVehicle = parkingSpot.ParkedVehicles.FirstOrDefault(v => v.LicencePlate == requestedLicencePlate);
            return foundVehicle;
        }
    }
}



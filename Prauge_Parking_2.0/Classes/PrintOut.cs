using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class PrintOut
    { //TODO: make static - 27/10: later 
        public string Text { get; set; }
        public PrintOut()
        {

        }

        public static string getLicencePlate()
        {
            string licencePlate = AnsiConsole.Ask<string>("Please input the vehicle licence plate:");
            //return licencePlate;
            if (Validator.ValidateLicencePlate(licencePlate)) return licencePlate;
            else return null; // TODO would be nice if null triggered a error message...  - 27/10: later 
        }

        public static int requestedNewSpot()
        { 
            int newSpot = AnsiConsole.Ask<int>("Please input the parking spot you wish to move the vehicle to:");
            return newSpot;
        }

        public static bool parkVehicleAtSpot(ParkingSpot parkingSpot, Vehicle vehicle)
        {
            AnsiConsole.WriteLine($"The {vehicle.VehicleType} with licence nr {vehicle.LicencePlate} is assigned to parkingspot {parkingSpot.ParkingSpotId}.");
            pressAnyKeyToContinue();
            return true;
        }
        public static bool vehicleParkedAt(ParkingSpot parkingSpot, Vehicle vehicle)
        {
            AnsiConsole.WriteLine($"The {vehicle.VehicleType} with licence nr {vehicle.LicencePlate} is parked at parkingspot {parkingSpot.ParkingSpotId}.");
            pressAnyKeyToContinue();
            return true;
        }

        public static bool pressAnyKeyToContinue()
        {
            AnsiConsole.WriteLine("Press any key to continue");
            AnsiConsole.Console.Input.ReadKey(false);
            return true;
        }

        public static bool retrieveVehicleAtSpot(Receipt endedParking)
        {
            AnsiConsole.WriteLine($"The {endedParking.ParkedVehicle.VehicleType} with licence nr {endedParking.ParkedVehicle.LicencePlate} is parked to parkingspot {endedParking.ParkingSpotId}. It was parked for {endedParking.ParkedDuration}. Please retrieve it as it is now flagged for departure.");
            pressAnyKeyToContinue();
            return true;
        }

        public static bool parkingSpotIsFull(ParkingSpot parkingSpot, Vehicle vehicle)
        {
            AnsiConsole.WriteLine($"Parkingspot {parkingSpot.ParkingSpotId} doesn't have enough space available to park a {vehicle.VehicleType}, try a different spot.");
            pressAnyKeyToContinue();
            return true;
        }

        public static bool ErrorNullOrWhiteSpace()
        {
            AnsiConsole.WriteLine("The text you provided is either null or whitespace. Try again.");
            return true;
        }

        public static bool ErrorLicencePlateLenght()
        {
            AnsiConsole.WriteLine("The text you provided is too long, a licenceplate can be a maximum of 10 characters.");
            return true;
        }
    }
}

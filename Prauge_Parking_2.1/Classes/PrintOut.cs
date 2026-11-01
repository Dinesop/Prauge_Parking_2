using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;
using System.Xml.Linq;

namespace Prauge_Parking_2._1.Classes
{
    public class PrintOut
    { //TODO: make static
        public string Text { get; set; }
        public PrintOut()
        {

        }
        public static string getLicencePlate()
        { // TODO add a "press escape to go back" function.
            string licencePlate = AnsiConsole.Ask<string>("Please input the vehicle licence plate:");
            licencePlate.Trim().ToUpper();
            if (Validator.ValidateLicencePlate(licencePlate)) return licencePlate;
            else return null;
        }
        public static int requestedNewSpot()
        {
            int newSpot = AnsiConsole.Ask<int>("Please input the parking spot you wish to move the vehicle to:");
            return newSpot;
        }
        public static bool parkVehicleAtSpot(ParkingSpot parkingSpot, IVehicle vehicle)
        {
            AnsiConsole.WriteLine($"The {vehicle.VehicleType} with licence nr {vehicle.LicencePlate} is assigned to parkingspot {parkingSpot.ParkingSpotId}.");
            pressAnyKeyToContinue();
            return true;
        }
        public static bool simParkVehicleAtSpot(ParkingSpot parkingSpot, IVehicle vehicle)
        {
            AnsiConsole.WriteLine($"The {vehicle.VehicleType} with licence nr {vehicle.LicencePlate} is assigned to parkingspot {parkingSpot.ParkingSpotId}.");
            return true;
        }
        public static bool vehicleParkedAt(ParkingSpot parkingSpot, IVehicle vehicle)
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

            AnsiConsole.WriteLine($"The {endedParking.ParkedVehicle.VehicleType} with licence nr {endedParking.ParkedVehicle.LicencePlate} is parked to parkingspot {endedParking.ParkingSpotId}. It was parked for {endedParking.ParkedDuration:d\\.hh\\:mm\\:ss}. The cost totalled {endedParking.CostOfParking:N2}. Please retrieve it as it is now flagged for departure.");
            pressAnyKeyToContinue();
            return true;
        }
        public static bool parkingSpotIsFull(ParkingSpot parkingSpot, IVehicle vehicle)
        {
            AnsiConsole.WriteLine($"Parkingspot {parkingSpot.ParkingSpotId} doesn't have enough space available to park a {vehicle.VehicleType}, try a different spot.");
            pressAnyKeyToContinue();
            return true;
        }
        public static bool parkingSpotIsFull(int requestedSpot, IVehicle vehicle)
        {
            AnsiConsole.WriteLine($"Parkingspot {requestedSpot} doesn't have enough space available to park a {vehicle.VehicleType}, try a different spot.");
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
        public static bool WarningParkingGarageOverwriten()
        {
            AnsiConsole.WriteLine("The configuration and the parking garage did not match in the number of parking spots, but as the parking garage was empty the save file was adjusted to match the configuration settings.");
            pressAnyKeyToContinue();
            return true;
        }
        public static bool WarningNewParkingGarageCreated()
        {
            AnsiConsole.WriteLine("The configuration and the parking garage did not match in the number of parking spots, but as the parking garage was empty a new file has been created and the exsisting vehicles have been moved over. ");
            pressAnyKeyToContinue();
            return true;
        }
        public static void ParkingFailed()
        {
            AnsiConsole.WriteLine("The vehicle could not be entered into the system. Check input and try again.");
            pressAnyKeyToContinue();
        }
        public static string getBicycleColor()
        {
            string bicycleColor = AnsiConsole.Ask<string>("Please input the color of the bicycle:").Trim().ToUpper();
            if (Validator.ValidateLicencePlate(bicycleColor)) return bicycleColor;
            else return null;
        }
        public static bool parkBusAtSpot(List<ParkingSpot> parkingSpot, IVehicle vehicle)
        {
            AnsiConsole.WriteLine($"The {vehicle.VehicleType} with licence nr {vehicle.LicencePlate} is assigned to parkingspots {parkingSpot[0].ParkingSpotId} - {parkingSpot[3].ParkingSpotId}.");
            pressAnyKeyToContinue();
            return true;
        }
        public static bool simParkBusAtSpot(List<ParkingSpot> parkingSpot, IVehicle vehicle)
        {
            AnsiConsole.WriteLine($"The {vehicle.VehicleType} with licence nr {vehicle.LicencePlate} is assigned to parkingspots {parkingSpot[0].ParkingSpotId} - {parkingSpot[3].ParkingSpotId}.");
            return true;
        }
        public static bool NoBusParkingAvailable()
        {
            AnsiConsole.WriteLine($"The amount of parkingspots in the parkinggarage are to few to fit a bus.");
            pressAnyKeyToContinue();
            return true;
        }
        public static List<string> VehicleSelection()
        {
            var selected = AnsiConsole.Prompt(
                new MultiSelectionPrompt<string>()
                .Title("Which vehicles do you want to enable?")
                .AddChoices("Car", "Motorcycle", "Bus", "Bicycle"));

            AnsiConsole.WriteLine("You selected:");
            foreach (var item in selected)
            {
                AnsiConsole.WriteLine($"- {item}");
            }
            return selected;
        }
        public static List<string> VehiclePriceSelection()
        {
            var selected = AnsiConsole.Prompt(
                new MultiSelectionPrompt<string>()
                .Title("Which vehicles do you want to change prices for?")
                .AddChoices("Car", "Motorcycle", "Bus", "Bicycle"));

            AnsiConsole.WriteLine("You selected:");
            foreach (var item in selected)
            {
                AnsiConsole.WriteLine($"- {item}");
            }
            return selected;
        }
        public static decimal AskForPrice(string type)
        {
            int price = AnsiConsole.Ask<int>($"Set the price for {type}:");
            return price;
        }
        public static void Prices(Dictionary<string, decimal> priceList)
        {
            foreach (var type in priceList)
            {
                AnsiConsole.WriteLine($"{type.Key}: {type.Value}");
            }
        }

        public static bool AskForManualConfigSetUp()
        {

            AnsiConsole.WriteLine("There is no existing configurationfile.");
            if (AnsiConsole.Confirm("Do you want to setup the configuration manually? "))
            {
                return true;
            }
            else
            {
                AnsiConsole.MarkupLine("The following standard settings will be used:");
                AnsiConsole.WriteLine("Number Of ParkingSpots : 100");
                AnsiConsole.WriteLine("Allowed Vehicle Types, Price and Size: \nCar: Price:20, CZK Size: 4 \nMotorcycle: Price:10, CZK Size: 2 \nBus: Price:80, CZK Size: 16 \nBicycle: Price:5, CZK Size: 1");
                AnsiConsole.WriteLine("Total Capacity Of A ParkingSpot : 4");
                AnsiConsole.WriteLine("Config FilePath : ConfigFile.json");
                AnsiConsole.WriteLine("ParkingGarage FilePath : ParkingGarage.json");
                AnsiConsole.WriteLine("PriceList FilePath : PriceList.txt");
                AnsiConsole.WriteLine("Free Parking Time : 10 min");
                AnsiConsole.WriteLine("Available BusSpots : 50");
                pressAnyKeyToContinue();
                return false;
            }
        }
        public static int AskForNumberOfParkingSpots(AppConfig configFile, ParkingGarage parkingGarage)
        {
            int nrOfSpots = AnsiConsole.Prompt(
             new TextPrompt<int>("Submit the number of parkingspots: ")
            .ValidationErrorMessage("[red]Not allowed — vehicles are parked on spots that would be removed.[/]")
            .Validate(nrOfSpots => Validator.TrySetNumberOfParkingSpots(nrOfSpots, configFile, parkingGarage)));
            return nrOfSpots;
        }
        public static int AskForNumberOfParkingSpots(AppConfig configFile)
        {
            int nrOfSpots = AnsiConsole.Prompt(
             new TextPrompt<int>("Submit the number of parkingspots: ")
            .ValidationErrorMessage("[red]Not allowed — vehicles are parked on spots that would be removed.[/]")
            .Validate(nrOfSpots => Validator.TrySetNumberOfParkingSpots(nrOfSpots, configFile)));
            return nrOfSpots;
        }

        public static int AskForTotalCapacity()
        {
            int totalCapacity = AnsiConsole.Ask<int>("Submit the total capacity of each parking spot: ");
            return totalCapacity;
        }

        public static string AskForConfigFilePath()
        {
            string configFilePath = AnsiConsole.Prompt(
                new TextPrompt<string>("Submit the name of the config file:")
                    .Validate(path =>
                    {
                        // 1. Reject characters illegal in Windows file names
                        char[] invalidChars = Path.GetInvalidPathChars()
                        .Concat(Path.GetInvalidFileNameChars())
                        .Distinct()
                        .ToArray();

                        if (path.IndexOfAny(invalidChars) >= 0)
                            return ValidationResult.Error(
                            $"Path contains invalid characters such as '?'.");

                        // 2. Reject malformed paths (e.g. empty, bad format)
                        if (string.IsNullOrWhiteSpace(path))
                            return ValidationResult.Error("Path cannot be empty.");

                        try
                        {
                            _ = Path.GetFullPath(path); // throws on malformed paths
                        }
                        catch (Exception e) when (e is ArgumentException or PathTooLongException
                                          or NotSupportedException)
                        {
                            return ValidationResult.Error("That is not a valid file path.");
                        }

                        return ValidationResult.Success();
                    }));
            return configFilePath;
        }

        public static string AskForParkingGarageFilePath()
        {
            string parkingGarageFilePath = AnsiConsole.Prompt(
                new TextPrompt<string>("Submit the name of the parking garage file:")
                    .Validate(path =>
                    {
                    // 1. Reject characters illegal in Windows file names
                    char[] invalidChars = Path.GetInvalidPathChars()
                    .Concat(Path.GetInvalidFileNameChars())
                    .Distinct()
                    .ToArray();

                    if (path.IndexOfAny(invalidChars) >= 0)
                    return ValidationResult.Error(
                    $"Path contains invalid characters such as '?'.");

                    // 2. Reject malformed paths (e.g. empty, bad format)
                    if (string.IsNullOrWhiteSpace(path))
                    return ValidationResult.Error("Path cannot be empty.");

                    try
                    {
                        _ = Path.GetFullPath(path); // throws on malformed paths
                    }
                    catch (Exception e) when (e is ArgumentException or PathTooLongException
                                      or NotSupportedException)
                    {
                        return ValidationResult.Error("That is not a valid file path.");
                    }

                    return ValidationResult.Success();
                    }));

            return parkingGarageFilePath;
        }

        public static string AskForPriceListFilePath()
        {
            string priceListFilePath = AnsiConsole.Prompt(
                new TextPrompt<string>("Submit the name of the parking garage file:")
                    .Validate(path =>
                    {
                        // 1. Reject characters illegal in Windows file names
                        char[] invalidChars = Path.GetInvalidPathChars()
                        .Concat(Path.GetInvalidFileNameChars())
                        .Distinct()
                        .ToArray();

                        if (path.IndexOfAny(invalidChars) >= 0)
                            return ValidationResult.Error(
                            $"Path contains invalid characters such as '?'.");

                        // 2. Reject malformed paths (e.g. empty, bad format)
                        if (string.IsNullOrWhiteSpace(path))
                            return ValidationResult.Error("Path cannot be empty.");

                        try
                        {
                            _ = Path.GetFullPath(path); // throws on malformed paths
                        }
                        catch (Exception e) when (e is ArgumentException or PathTooLongException
                                          or NotSupportedException)
                        {
                            return ValidationResult.Error("That is not a valid file path.");
                        }

                        return ValidationResult.Success();
                    }));
            return priceListFilePath;
        }
        public static TimeSpan AskForFreeTimeSpan()
        {
            int minutes = AnsiConsole.Prompt(new TextPrompt<int>("Submit the free parking time in minutes: ")
                .ValidationErrorMessage("[red]Minutes must be zero or greater.[/]")
                .Validate(m => m >= 0));
            TimeSpan freeParkingTime = TimeSpan.FromMinutes(minutes);
            return freeParkingTime;
        }
        public static bool RunSimulation()
        {
            if (AnsiConsole.Confirm("[red bold]WARNING, this will populate the garage with simulated vehicles for testing purposes, are you sure you want to proceed?[/] \nAll simulated vehicles will have licenceplates with lowercase while all real vehicles will have licenceplates in upper case."))
            {
                return true;
            }
            else return false;
        }

        internal static int SubmittNrOfFakeVehicles()
        {
            int vehicleCount = AnsiConsole.Ask<int>("Submit the number of fake vehicles you would like to run the test with: ");
            return vehicleCount;
        }

        internal static void ErrorLicencePlateDontExsist()
        {
            AnsiConsole.WriteLine("The requested licenceplate couldn't be found, verify and try again.");
            pressAnyKeyToContinue();
        }

        internal static void ExceedingParkingSpotLimit()
        {
            AnsiConsole.WriteLine("The requested amount of simulated vehicles exceeds the number of parking spots available in the parking garage.");
            pressAnyKeyToContinue();
        }
    }
}

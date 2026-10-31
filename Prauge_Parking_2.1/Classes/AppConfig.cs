using Class_Library_PP2;
using Prauge_Parking_2._1.Classes;
using Spectre.Console;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class AppConfig
    {
        public int NumberOfParkingSpots { get; set; } = 2;
        public List<string> AllowedVehicleTypes { get; set; } = new List<string> { "Car", "Motorcycle", "Bicycle" };
        public Dictionary<string, decimal> VehiclePrices { get; set; } = new();
        public Dictionary <string, int> VehicleSetup { get; set; } = new();

        public int TotalCapacity { get; set; } = 4;
        public string ConfigFilePath { get; set; } = "ConfigFile";
        // I am not adding the file-ending here because I want to be able to add numbers into the string if needed at CheckExsistingParkingGarage() backup handling

        public string ParkingGarageFilePath { get; set; } = "ParkingGarage";
        public string PriceListFilePath { get; set; } = "PriceList";

        public TimeSpan FreeParkingTime { get; set; } = new TimeSpan(0, 10, 0);


        public AppConfig()
        {
            VehiclePrices = CheckExsistingPriceList();
            VehicleSetup = SetupVehicleConfig();
        }

        public static Dictionary<string, decimal> CheckExsistingPriceList()
        {
            string priceFilePath = "Pricelist" + ".txt";
            bool checkForFile = MyFiles.CheckForFile(priceFilePath);
            if (!checkForFile)
            {
                //MyFiles.CreateFile(priceFilePath);
                Dictionary<string, decimal> vehiclePrices = new Dictionary<string, decimal> { { "Car", 20M }, { "Motorcycle", 10M }, { "Bicycle", 5M } };
                MyFiles.WriteDictionaryToTxtFile(priceFilePath, vehiclePrices);
                return vehiclePrices;
            }
            else
            {
                Dictionary<string, decimal> vehiclePrices = LoadPricelist(priceFilePath);
                return vehiclePrices;
            }
        }

        public static Dictionary<string, decimal> LoadPricelist(string priceFilePath)
        {
            var prices = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);

            foreach (var line in File.ReadLines(priceFilePath))
            {
                if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                    continue; // skip blanks and comments like "# weekend rates"

                var parts = line.Split(' ', 2);   // max 2 parts: type, price
                if (parts.Length != 2)
                {
                    AnsiConsole.MarkupLine($"[yellow]Warning:[/] skipping malformed line: '{line}'");
                    continue;
                }

                var type = parts[0].Trim();
                if (!decimal.TryParse(parts[1].Trim(), out var price))
                {
                    AnsiConsole.MarkupLine($"[yellow]Warning:[/] skipping line with invalid price: '{line}'");
                    continue;
                }

                prices[type] = price;   // indexer assignment: later duplicates overwrite earlier ones
            }

            return prices;
        }
        public static AppConfig CheckExsistingConfigFile()
        {// TODO Move to AppConfig where it belongs. 
            string configFilePath = "ConfigFile" + ".json";
            bool checkForFile = MyFiles.CheckForFile(configFilePath);
            if (!checkForFile)
            {

                AppConfig configFile = new AppConfig();
                ParkingGarage.SaveConfigFile(configFile);
                return configFile;
            }
            else
            {
                AppConfig configFile = ParkingGarage.LoadConfigFile(configFilePath);
                return configFile;
            }
        }

        public static Dictionary<string, int> SetupVehicleConfig()
        {
            Dictionary<string, int> vehiclePrices = new Dictionary<string, int> { { "Car", 4 }, { "Motorcycle", 2 }, { "Bicycle", 1 } };
            return vehiclePrices;
        }


    }
}

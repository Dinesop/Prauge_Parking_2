using Class_Library_PP2;
using Prauge_Parking_2._1.Classes;
using Spectre.Console;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._1.Classes
{
    public class AppConfig
    {
        public int NumberOfParkingSpots { get; set; }
        public List<string> AllowedVehicleTypes { get; set; }
        public Dictionary<string, decimal> VehiclePrices { get; set; }
        public Dictionary <string, int> VehicleSetup { get; set; }
        public int TotalCapacity { get; set; }
        public string ConfigFilePath { get; set; }
        // I am not adding the file-ending here because I want to be able to add numbers into the string if needed at CheckExsistingParkingGarage() backup handling

        public string ParkingGarageFilePath { get; set; }
        public string PriceListFilePath { get; set; }
        public TimeSpan FreeParkingTime { get; set; }
        public int AvailableBusSpots { get; set; }

        public AppConfig()
        {
            
        }

        public static Dictionary<string, decimal> CheckExsistingPriceList(AppConfig appConfig)
        {
            string priceFilePath = appConfig.PriceListFilePath + ".txt"; // default filename
            bool checkForFile = MyFiles.CheckForFile(priceFilePath);
            if (!checkForFile)
            {

                Dictionary<string, decimal> vehiclePrices = appConfig.VehiclePrices;
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
                    continue; 

                var parts = line.Split(' ', 2);   
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

                prices[type] = price;
            }
            return prices;
        }
        public static AppConfig CheckExsistingConfigFile()
        { 
            string configFilePath = "ConfigFile" + ".json";
            bool checkForFile = MyFiles.CheckForFile(configFilePath);
            
            if (!checkForFile)
            {
                string filePathGarage = "ParkingGarage" + ".json";
                bool checkForGarageFile = MyFiles.CheckForFile(filePathGarage);
                if (checkForGarageFile)
                {
                    ParkingGarage parkingGarage_temp = ParkingGarage.LoadParkingGarage(filePathGarage);
                    AppConfig configFile = new AppConfig();
                    configFile.SetupConfigFile(configFile, parkingGarage_temp);
                    ParkingGarage.SaveConfigFile(configFile);
                    return configFile;
                }
                else
                {
                    AppConfig configFile = new AppConfig();
                    configFile.SetupConfigFile(configFile);
                    ParkingGarage.SaveConfigFile(configFile);
                    return configFile;
                } 
            }
            else
            {
                AppConfig configFile = ParkingGarage.LoadConfigFile(configFilePath);
                return configFile;
            }
        }
        public static Dictionary<string, int> SetupVehicleConfig()
        {
            Dictionary<string, int> vehicleSizes = new Dictionary<string, int> { { "Car", 4 }, { "Motorcycle", 2 }, { "Bicycle", 1 }, { "Bus", 16 } };
            return vehicleSizes;
        }
        public static int DeterminAvailableBusSpots(int NumberOfParkingSpots)
        {
            int availableBusSpots;

            if (NumberOfParkingSpots > 50) { availableBusSpots = 47; return availableBusSpots; }
                
            else if (NumberOfParkingSpots > 4) {availableBusSpots = NumberOfParkingSpots - 3; return availableBusSpots; }

            else{ availableBusSpots = 0;  PrintOut.NoBusParkingAvailable(); return availableBusSpots; }
        }

        public static void ChangePrices(AppConfig appConfig)
        {
            string priceFilePath =  appConfig.PriceListFilePath + ".txt";
            List<string> vehicleTypesToChange = PrintOut.VehiclePriceSelection();
            Dictionary<string, decimal> priceList = CheckExsistingPriceList(appConfig);
            foreach (var type in vehicleTypesToChange)
            {
                priceList[type] = PrintOut.AskForPrice(type);
            }
            MyFiles.WriteDictionaryToTxtFile(priceFilePath, priceList);
            PrintOut.Prices(priceList);
        }
        public bool SetupConfigFile(AppConfig configFile, ParkingGarage parkingGarage)
        {
            bool choice = PrintOut.AskForManualConfigSetUp();
            if (choice)
            {
                NumberOfParkingSpots = PrintOut.AskForNumberOfParkingSpots(configFile, parkingGarage);
                AllowedVehicleTypes = PrintOut.VehicleSelection();
                VehiclePrices = CheckExsistingPriceList(configFile);
                VehicleSetup = SetupVehicleConfig();
                TotalCapacity = PrintOut.AskForTotalCapacity();
                ConfigFilePath = PrintOut.AskForConfigFilePath();
                ParkingGarageFilePath = PrintOut.AskForParkingGarageFilePath();
                PriceListFilePath = PrintOut.AskForPriceListFilePath();
                FreeParkingTime = PrintOut.AskForFreeTimeSpan();
                AvailableBusSpots = DeterminAvailableBusSpots(NumberOfParkingSpots);
                return true;
            }
            else
            {
                NumberOfParkingSpots = 100;
                AllowedVehicleTypes = new List<string>{ "Car", "Motorcycle", "Bicycle", "Bus" };
                VehiclePrices = new Dictionary<string, decimal> { { "Car", 20M }, { "Motorcycle", 10M }, { "Bicycle", 5M }, { "Bus", 80M } };
                VehicleSetup = new Dictionary<string, int> { { "Car", 4 }, { "Motorcycle", 2 }, { "Bicycle", 1 }, { "Bus", 16 } };
                TotalCapacity = 4;
                ConfigFilePath = "ConfigFile";
                ParkingGarageFilePath = "ParkingGarage";
                PriceListFilePath = "PriceList";
                FreeParkingTime = new TimeSpan(0, 10, 0);
                AvailableBusSpots = 47;
                return true;
            }
            
        }
        public bool SetupConfigFile(AppConfig configFile)
        {
            bool choice = PrintOut.AskForManualConfigSetUp();
            if (choice)
            {
                NumberOfParkingSpots = PrintOut.AskForNumberOfParkingSpots(configFile);
                AllowedVehicleTypes = PrintOut.VehicleSelection();
                VehiclePrices = CheckExsistingPriceList(configFile);
                VehicleSetup = SetupVehicleConfig();
                TotalCapacity = PrintOut.AskForTotalCapacity();
                ConfigFilePath = PrintOut.AskForConfigFilePath();
                ParkingGarageFilePath = PrintOut.AskForParkingGarageFilePath();
                PriceListFilePath = PrintOut.AskForPriceListFilePath();
                FreeParkingTime = PrintOut.AskForFreeTimeSpan();
                AvailableBusSpots = DeterminAvailableBusSpots(NumberOfParkingSpots);
                return true;
            }
            else
            {
                NumberOfParkingSpots = 100;
                AllowedVehicleTypes = new List<string>{ "Car", "Motorcycle", "Bicycle", "Bus" };
                VehiclePrices = new Dictionary<string, decimal> { { "Car", 20M }, { "Motorcycle", 10M }, { "Bicycle", 5M }, { "Bus", 80M } };
                VehicleSetup = new Dictionary<string, int> { { "Car", 4 }, { "Motorcycle", 2 }, { "Bicycle", 1 }, { "Bus", 16 } };
                TotalCapacity = 4;
                ConfigFilePath = "ConfigFile";
                ParkingGarageFilePath = "ParkingGarage";
                PriceListFilePath = "PriceList";
                FreeParkingTime = new TimeSpan(0, 10, 0);
                AvailableBusSpots = 47;
                return true;
            }
            
        }
        public static bool ChangeConfigSetup(AppConfig configFile)
        {
            configFile.SetupConfigFile(configFile);
            ParkingGarage.SaveConfigFile(configFile);
            return true;
        }



    }
}

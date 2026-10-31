using Class_Library_PP2;
using Prauge_Parking_2._1.Classes;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;

namespace Prauge_Parking_2._0.Classes
{
    public class ParkingGarage
    {
        /* ---------- Fields ---------- */

        public List<ParkingSpot> ParkingSpots { get; set; } = new List<ParkingSpot>();

        /* ---------- Constructors ---------- */
        public ParkingGarage()
        {

        }
        public ParkingGarage(int totalSpots)
        {
            for (int i = 1; i <= totalSpots; i++)
            {
                ParkingSpots.Add(new ParkingSpot(i, CheckExsistingConfigFile().TotalCapacity));
            }
        }

        /* ---------- Methods ---------- */
        public ParkingSpot FindFirstEmptyParkingSpot(Vehicle vehicle, string filePath)
        {
            foreach (var spot in ParkingSpots)
            {

                if (spot.RemainingSize >= vehicle.Size)
                {
                    spot.ParkVehicleOnSpot(vehicle);
                    this.ParkingSpots.Contains(spot);
                    SaveParkingGarage(filePath, this);
                    return spot;
                }
                else continue;
            }
            return null;
        }
        public ParkingSpot FindLicencePlateInParkingSpot(string requestedLicencePlate)
        {
            foreach (var spot in ParkingSpots)
            {
                Vehicle foundVehicle = CollectVehicleFromLicencePlate(spot, requestedLicencePlate);
                if (foundVehicle != null)
                {
                    return spot;
                }
            }
            return null;

        }
        public Vehicle FindLicencePlate(string requestedLicencePlate)
        {
            Vehicle vehicleInGarage = ParkingSpots.SelectMany(spot => spot.ParkedVehicles).FirstOrDefault(v => v.LicencePlate == requestedLicencePlate);
            return vehicleInGarage;
        }
        public ParkingSpot FindParkingSpotId(int parkingSpotId)
        { // TODO: LINQ query simplify the search
            foreach (var spot in ParkingSpots)
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
            TimeSpan parkedDuration = foundVehicle.CheckIn - DateTime.UtcNow; // TODO look into TimeSpan Duration?
            TimeSpan freeParkingTime = new TimeSpan(0, 10, 0); // TODO point to config file
            Receipt endedParking = new Receipt(currentSpot, parkedDuration, foundVehicle, freeParkingTime);
            currentSpot.VacateVehicleSpot(foundVehicle);
            return endedParking;
        }
        public void MoveVehicle(string requestedLicencePlate, int requestedNewSpot, string filePath)
        {
            ParkingSpot currentSpot = FindLicencePlateInParkingSpot(requestedLicencePlate);
            Vehicle foundVehicle = CollectVehicleFromLicencePlate(currentSpot, requestedLicencePlate);
            ParkingSpot newSpot = FindParkingSpotId(requestedNewSpot);
            if (newSpot.RemainingSize >= foundVehicle.Size)
            {
                newSpot.ParkVehicleOnSpot(foundVehicle);
                this.ParkingSpots.Contains(newSpot);
                SaveParkingGarage(filePath, this);

                currentSpot.VacateVehicleSpot(foundVehicle);
                this.ParkingSpots.Contains(currentSpot);
                SaveParkingGarage(filePath, this);

                PrintOut.parkVehicleAtSpot(newSpot, foundVehicle);
            }
            else PrintOut.parkingSpotIsFull(newSpot, foundVehicle);

        }

        public static Vehicle CollectVehicleFromLicencePlate(ParkingSpot parkingSpot, string requestedLicencePlate)
        {
            Vehicle foundVehicle = parkingSpot.ParkedVehicles.FirstOrDefault(v => v.LicencePlate == requestedLicencePlate);
            return foundVehicle;
        }
        public void ParkCar(string filePath)
        {
            ParkingGarage parkingGarage = LoadParkingGarage(filePath);

            Vehicle car = new Car(PrintOut.getLicencePlate());
            bool validationCheck = Validator.ValidateNewVehicle(car);
            if (validationCheck) { ParkingSpot pSpot = parkingGarage.FindFirstEmptyParkingSpot(car, filePath); PrintOut.parkVehicleAtSpot(pSpot, car); }
            else PrintOut.ParkingFailed();
        }

        public static ParkingGarage LoadParkingGarage(string filePath)
        {
            var unloadedJson = MyFiles.Read(filePath);
            try
            {
                ParkingGarage parkingGarage = JsonSerializer.Deserialize<ParkingGarage>(unloadedJson);
                return parkingGarage;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public static AppConfig LoadConfigFile(string filePath)
        {
            var unloadedJson = MyFiles.Read(filePath);
            try
            {
                AppConfig configFile = JsonSerializer.Deserialize<AppConfig>(unloadedJson);
                return configFile;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool SaveParkingGarage(string filePath, ParkingGarage content)
        {
            string jsonString = JsonSerializer.Serialize(content);
            MyFiles.Save(filePath, jsonString);
            return true;
        }

        public static ParkingGarage CheckExsistingParkingGarage(AppConfig configFile)
        { // 31/10 Fixing backup for if config file and parking garage missmatch. Changed from hardcoded filePath to based in config file and dynamic if missmatch between config and parkingGarage.
            // TODO this should be split up.
            string filePath = configFile.ConfigFilePath + ".json";
            bool checkForFile = MyFiles.CheckForFile(filePath);
            if (!checkForFile)
            {
                ParkingGarage parkingGarage = new ParkingGarage(configFile.NumberOfParkingSpots);
                parkingGarage.SaveParkingGarage(filePath, parkingGarage);
                return parkingGarage;
            }
            else
            {
                ParkingGarage parkingGarage = ParkingGarage.LoadParkingGarage(filePath);
                if (configFile.NumberOfParkingSpots == parkingGarage.ParkingSpots.Count) return parkingGarage;
                else if (parkingGarage.ParkingSpots.Count == 0)
                {
                    parkingGarage = new ParkingGarage(configFile.NumberOfParkingSpots);
                    parkingGarage.SaveParkingGarage(filePath, parkingGarage);
                    PrintOut.WarningParkingGarageOverwriten();
                    return parkingGarage;
                }
                else
                {
                    string output = string.Concat(filePath.Where(Char.IsDigit));
                    bool numberCheck = int.TryParse(output, out int iterationNumber);
                    if (numberCheck)
                    {
                        iterationNumber++;
                        ParkingGarage parkingGarage_placeholder = new ParkingGarage(configFile.NumberOfParkingSpots);
                        int counter = parkingGarage.ParkingSpots.Count;
                        for (int i = 0; i < counter; i++)
                        {
                            parkingGarage_placeholder.ParkingSpots[i] = parkingGarage.ParkingSpots[i]; // reference copy, but is fine since we won't use it after we saved to file.
                        }
                        filePath = configFile.ConfigFilePath + iterationNumber + ".json";
                        parkingGarage_placeholder.SaveParkingGarage(filePath, parkingGarage_placeholder);
                        PrintOut.WarningParkingGarageOverwriten();
                        return parkingGarage;
                    }
                    else
                    {
                        ParkingGarage parkingGarage_placeholder = new ParkingGarage(configFile.NumberOfParkingSpots);
                        int counter = parkingGarage.ParkingSpots.Count;
                        for (int i = 0; i < counter; i++)
                        {
                            parkingGarage_placeholder.ParkingSpots[i] = parkingGarage.ParkingSpots[i]; // reference copy, but is fine since we won't use it after we saved to file.
                        }
                        filePath = configFile.ConfigFilePath + "2" + ".json";
                        parkingGarage_placeholder.SaveParkingGarage(filePath, parkingGarage_placeholder);
                        PrintOut.WarningParkingGarageOverwriten();
                        return parkingGarage;
                    }

                }
            }
        }
        public static AppConfig CheckExsistingConfigFile()
        {// TODO Move to AppConfig where it belongs. 
            string filePath = "ConfigFile" + ".json";
            bool checkForFile = MyFiles.CheckForFile(filePath);
            if (!checkForFile)
            {
                AppConfig configFile = new AppConfig();
                SetupParkingGarageConfiguration(configFile);
                return configFile;
            }
            else
            {
                AppConfig configFile = ParkingGarage.LoadConfigFile(filePath);
                return configFile;
            }
        }

        public void ParkMotorCycle(string filePath)
        {
            ParkingGarage parkingGarage = LoadParkingGarage(filePath);
            Vehicle motorCycle = new Motorcycle(PrintOut.getLicencePlate());
            bool validationCheck = Validator.ValidateNewVehicle(motorCycle);
            if (validationCheck) { ParkingSpot pSpot = parkingGarage.FindFirstEmptyParkingSpot(motorCycle, filePath); PrintOut.parkVehicleAtSpot(pSpot, motorCycle); }
            else PrintOut.ParkingFailed();
        }
        public static bool SetupParkingGarageConfiguration(AppConfig content)
        {
            string jsonString = JsonSerializer.Serialize(content);
            string filePath = content.ConfigFilePath + ".json";
            MyFiles.Save(filePath, jsonString);
            return true;
        }
        public void ParkBicycle(string filePath)
        {// 31/10 added method
            ParkingGarage parkingGarage = LoadParkingGarage(filePath);
            Vehicle bicycle = new Bicycle(PrintOut.getBicycleColor());
            int nrOfBikes = BicycleCounter(parkingGarage);
            int bikeId = nrOfBikes + 1;
            string completeBikeId = bicycle.LicencePlate + bikeId;
            bicycle.LicencePlate = completeBikeId;
            bool validationCheck = Validator.ValidateNewVehicle(bicycle);

            if (validationCheck) { ParkingSpot pSpot = parkingGarage.FindFirstEmptyParkingSpot(bicycle, filePath); PrintOut.parkVehicleAtSpot(pSpot, bicycle); }
            else PrintOut.ParkingFailed();
        }
        public int BicycleCounter(ParkingGarage parkingGarage)
        {// 31/10 added a counter to check for all bicycles in the system
            List<Vehicle> bicycleList = parkingGarage.ParkingSpots.SelectMany(spot => spot.ParkedVehicles).Where(v => v.VehicleType == "Bicycle").ToList();
            return bicycleList.Count;
        }


    }
}



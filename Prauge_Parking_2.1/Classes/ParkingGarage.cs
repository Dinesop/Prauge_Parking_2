using Class_Library_PP2;
using Prauge_Parking_2._1.Classes;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;

namespace Prauge_Parking_2._1.Classes
{
    public class ParkingGarage : IParkingGarage
    {
        /* ---------- Fields ---------- */

        public List<ParkingSpot> ParkingSpots { get; set; } = new List<ParkingSpot>();

        /* ---------- Constructors ---------- */
        public ParkingGarage()
        {

        }
        public ParkingGarage(AppConfig appConfig)
        {
            for (int i = 1; i <= appConfig.NumberOfParkingSpots; i++)
            {
                ParkingSpots.Add(new ParkingSpot(i, appConfig.TotalCapacity));
            }
        }

        /* ---------- Methods ---------- */
        public ParkingSpot FindFirstEmptyParkingSpot(IVehicle vehicle, string filePath)
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
                IVehicle foundVehicle = CollectVehicleFromLicencePlate(spot, requestedLicencePlate);
                if (foundVehicle != null)
                {
                    return spot;
                }
            }
            return null;

        }
        public IVehicle FindLicencePlate(string requestedLicencePlate)
        {
            IVehicle vehicleInGarage = ParkingSpots.SelectMany(spot => spot.ParkedVehicles).FirstOrDefault(v => v.LicencePlate == requestedLicencePlate);
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
        public Receipt RetriveVehicle(string requestedLicencePlate, AppConfig appConfig, string filePath)
        {
            ParkingSpot currentSpot = FindLicencePlateInParkingSpot(requestedLicencePlate);
            if (currentSpot == null)
            {
                PrintOut.ErrorLicencePlateDontExsist();
                return null;
            }
            else
            {
                IVehicle foundVehicle = CollectVehicleFromLicencePlate(currentSpot, requestedLicencePlate);
                TimeSpan parkedDuration = DateTime.UtcNow - foundVehicle.CheckIn; 
                TimeSpan freeParkingTime = appConfig.FreeParkingTime;
                Receipt endedParking = new Receipt(currentSpot, parkedDuration, foundVehicle, freeParkingTime);
                currentSpot.VacateVehicleSpot(foundVehicle);
                SaveParkingGarage(filePath, this);
                return endedParking;
            }
        }
        public void MoveVehicle(string requestedLicencePlate, int requestedNewSpot, string filePath)
        {
            ParkingSpot currentSpot = FindLicencePlateInParkingSpot(requestedLicencePlate);
            if (currentSpot == null)
                PrintOut.ErrorLicencePlateDontExsist();
            else
            {
                IVehicle foundVehicle = CollectVehicleFromLicencePlate(currentSpot, requestedLicencePlate);
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
   
        }
        public static IVehicle CollectVehicleFromLicencePlate(ParkingSpot parkingSpot, string requestedLicencePlate)
        { 
            IVehicle foundVehicle = parkingSpot.ParkedVehicles.FirstOrDefault(v => v.LicencePlate == requestedLicencePlate);
            if (parkingSpot == null)
            {
                PrintOut.ErrorLicencePlateDontExsist(); return null;
            }
            else return foundVehicle;

        }
        public void ParkCar(string filePath, AppConfig appConfig)
        {
            ParkingGarage parkingGarage = LoadParkingGarage(filePath);

            IVehicle car = new Car(PrintOut.getLicencePlate(), appConfig);
            bool validationCheck = Validator.ValidateNewVehicle(car);
            if (validationCheck)
            {
                ParkingSpot pSpot = parkingGarage.FindFirstEmptyParkingSpot(car, filePath);
                if (pSpot != null) PrintOut.parkVehicleAtSpot(pSpot, car);
                else PrintOut.ParkingFailed();
            }
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
        public static AppConfig LoadConfigFile(string configFilePath)
        {
            var unloadedJson = MyFiles.Read(configFilePath);
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
            string filePath = configFile.ParkingGarageFilePath + ".json";
            bool checkForFile = MyFiles.CheckForFile(filePath);
            if (!checkForFile)
            {
                ParkingGarage parkingGarage = new ParkingGarage(configFile);
                parkingGarage.SaveParkingGarage(filePath, parkingGarage);
                return parkingGarage;
            }
            else
            {
                ParkingGarage parkingGarage = ParkingGarage.LoadParkingGarage(filePath);
                if (configFile.NumberOfParkingSpots == parkingGarage.ParkingSpots.Count) return parkingGarage;
                else if (parkingGarage.ParkingSpots.Count == 0)
                {
                    parkingGarage = new ParkingGarage(configFile);
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
                        ParkingGarage parkingGarage_placeholder = new ParkingGarage(configFile);
                        int counter = parkingGarage.ParkingSpots.Count;
                        for (int i = 0; i < counter; i++)
                        {
                            parkingGarage_placeholder.ParkingSpots[i] = parkingGarage.ParkingSpots[i]; // reference copy, but is fine since we won't use it after we saved to file.
                        }
                        filePath = configFile.ParkingGarageFilePath + iterationNumber + ".json";
                        parkingGarage_placeholder.SaveParkingGarage(filePath, parkingGarage_placeholder);
                        PrintOut.WarningParkingGarageOverwriten();
                        return parkingGarage;
                    }
                    else
                    {
                        ParkingGarage parkingGarage_placeholder = new ParkingGarage(configFile);
                        int counter = parkingGarage.ParkingSpots.Count;
                        for (int i = 0; i < counter; i++)
                        {
                            parkingGarage_placeholder.ParkingSpots[i] = parkingGarage.ParkingSpots[i]; // reference copy, but is fine since we won't use it after we saved to file.
                        }
                        filePath = configFile.ParkingGarageFilePath + "2" + ".json";
                        parkingGarage_placeholder.SaveParkingGarage(filePath, parkingGarage_placeholder);
                        PrintOut.WarningParkingGarageOverwriten();
                        return parkingGarage;
                    }

                }
            }
        }
        public void ParkMotorCycle(string filePath, AppConfig appConfig)
        {
            ParkingGarage parkingGarage = LoadParkingGarage(filePath);
            IVehicle motorCycle = new Motorcycle(PrintOut.getLicencePlate(), appConfig);
            bool validationCheck = Validator.ValidateNewVehicle(motorCycle);
            if (validationCheck) 
            { 
                ParkingSpot pSpot = parkingGarage.FindFirstEmptyParkingSpot(motorCycle, filePath);
                if (pSpot != null) PrintOut.parkVehicleAtSpot(pSpot, motorCycle);
                else PrintOut.ParkingFailed();

            }
            else PrintOut.ParkingFailed();
        }
        public static bool SaveConfigFile(AppConfig content)
        {// Saves the config file
            string jsonString = JsonSerializer.Serialize(content);
            string configFilePath = content.ConfigFilePath + ".json";
            MyFiles.Save(configFilePath, jsonString);
            return true;
        }
        public void ParkBicycle(string filePath, AppConfig appConfig)
        {// 31/10 added method
            ParkingGarage parkingGarage = LoadParkingGarage(filePath);
            IVehicle bicycle = new Bicycle(PrintOut.getBicycleColor(), appConfig);
            int nrOfBikes = BicycleCounter(parkingGarage);
            int bikeId = nrOfBikes + 1;
            string completeBikeId = bicycle.LicencePlate + bikeId;
            bicycle.LicencePlate = completeBikeId;
            bool validationCheck = Validator.ValidateNewVehicle(bicycle);

            if (validationCheck) 
            { 
                ParkingSpot pSpot = parkingGarage.FindFirstEmptyParkingSpot(bicycle, filePath);
                if (pSpot != null) PrintOut.parkVehicleAtSpot(pSpot, bicycle);
                else PrintOut.ParkingFailed();
            }
            else PrintOut.ParkingFailed();
        }
        public int BicycleCounter(ParkingGarage parkingGarage)
        {// 31/10 added a counter to check for all bicycles in the system
            List<IVehicle> bicycleList = parkingGarage.ParkingSpots.SelectMany(spot => spot.ParkedVehicles).Where(v => v.VehicleType == "Bicycle").ToList();
            return bicycleList.Count;
        }
        public void ParkBus(string filePath, AppConfig appConfig)
        {
            ParkingGarage parkingGarage = LoadParkingGarage(filePath);
            IVehicle bus = new Bus(PrintOut.getLicencePlate(), appConfig);
            bool validationCheck = Validator.ValidateNewVehicle(bus);
            if (validationCheck) 
            {
                List<ParkingSpot> pSpot = parkingGarage.FindFirstEmptyParkingSpotForBus(bus, filePath, appConfig);
                if (pSpot != null) PrintOut.parkBusAtSpot(pSpot, bus);
            }
            else PrintOut.ParkingFailed();
        }
        public List<ParkingSpot> FindFirstEmptyParkingSpotForBus(IVehicle vehicle, string filePath, AppConfig appConfig)
        {
            int index = 0;
            for (index = 0; index < appConfig.AvailableBusSpots; index++)// if spot 47 isn't empty, bus won't fit on the last 4 spots before spot 50.
            {
                if (ParkingSpots[index].IsEmpty)
                {
                    if (ParkingSpots[index + 1].IsEmpty && ParkingSpots[index + 2].IsEmpty && ParkingSpots[index + 3].IsEmpty)
                    {
                        List<ParkingSpot> selectedParkingSpots = new List<ParkingSpot> { ParkingSpots[index], ParkingSpots[index + 1], ParkingSpots[index + 2], ParkingSpots[index + 3] };

                        AddBusToSystem(selectedParkingSpots, vehicle, filePath);
                        return selectedParkingSpots;
                    }
                    else continue;
                }
                else continue;
            }
            PrintOut.parkingSpotIsFull(index, vehicle);
            return null;
        }
        public void MoveBus(string requestedLicencePlate, int requestedNewSpot,string filePath, AppConfig appConfig)
        {
            ParkingSpot currentSpot = FindLicencePlateInParkingSpot(requestedLicencePlate);
            if (currentSpot == null)
                PrintOut.ErrorLicencePlateDontExsist();
            else
            {
                IVehicle foundVehicle = CollectVehicleFromLicencePlate(currentSpot, requestedLicencePlate);
                if (requestedNewSpot + 4 < appConfig.AvailableBusSpots)
                {
                    List<ParkingSpot> selectedNewParkingSpots = FindBusParkingSpots(requestedNewSpot);
                    if (selectedNewParkingSpots[0].IsEmpty && selectedNewParkingSpots[1].IsEmpty && selectedNewParkingSpots[3].IsEmpty && selectedNewParkingSpots[3].IsEmpty)
                    {
                        AddBusToSystem(selectedNewParkingSpots, foundVehicle, filePath);

                        List<ParkingSpot> selectedOldParkingSpots = FindBusParkingSpots(currentSpot);

                        RemoveBusFromSystem(selectedOldParkingSpots, foundVehicle, filePath);
                        PrintOut.parkBusAtSpot(selectedNewParkingSpots, foundVehicle);
                    }
                    
                }
                else PrintOut.parkingSpotIsFull(requestedNewSpot, foundVehicle);
            }
        }
        public void AddBusToSystem (List<ParkingSpot> selectedParkingSpots, IVehicle vehicle, string filePath)
        {
            foreach (var spot in selectedParkingSpots)
            {
                spot.ParkVehicleOnSpot(vehicle);
                this.ParkingSpots.Contains(spot);
                SaveParkingGarage(filePath, this);
            }
        }
        public void RemoveBusFromSystem (List<ParkingSpot> selectedParkingSpots, IVehicle vehicle, string filePath)
        {
            foreach (var spot in selectedParkingSpots)
            {
                spot.VacateVehicleSpot(vehicle);
                this.ParkingSpots.Contains(spot);
                SaveParkingGarage(filePath, this);
            }
        }
        public Receipt RetriveBus(string requestedLicencePlate, AppConfig appConfig, string filePath)
        {
            ParkingSpot currentSpot = FindLicencePlateInParkingSpot(requestedLicencePlate);
            if (currentSpot == null)
            {
                PrintOut.ErrorLicencePlateDontExsist();
                return null;
            }

            else
            {
                List<ParkingSpot> selectedParkingSpots = FindBusParkingSpots(currentSpot);
                IVehicle foundVehicle = CollectVehicleFromLicencePlate(currentSpot, requestedLicencePlate);
                TimeSpan parkedDuration = DateTime.UtcNow - foundVehicle.CheckIn; 
                TimeSpan freeParkingTime = appConfig.FreeParkingTime;
                Receipt endedParking = new Receipt(currentSpot, parkedDuration, foundVehicle, freeParkingTime);
                RemoveBusFromSystem(selectedParkingSpots, foundVehicle, filePath);

                SaveParkingGarage(filePath, this);
                return endedParking;
            }
        }
        public List<ParkingSpot> FindBusParkingSpots (ParkingSpot currentSpot)
        {
            ParkingSpot spot1 = FindParkingSpotId(currentSpot.ParkingSpotId);
            ParkingSpot spot2 = FindParkingSpotId(currentSpot.ParkingSpotId + 1);
            ParkingSpot spot3 = FindParkingSpotId(currentSpot.ParkingSpotId + 2);
            ParkingSpot spot4 = FindParkingSpotId(currentSpot.ParkingSpotId + 3);

            List<ParkingSpot> selectedParkingSpots = new List<ParkingSpot> { spot1, spot2, spot3, spot4 };
            return selectedParkingSpots;
        }
        public List<ParkingSpot> FindBusParkingSpots (int requestedSpot)
        {
            ParkingSpot spot1 = FindParkingSpotId(requestedSpot);
            ParkingSpot spot2 = FindParkingSpotId(requestedSpot + 1);
            ParkingSpot spot3 = FindParkingSpotId(requestedSpot + 2);
            ParkingSpot spot4 = FindParkingSpotId(requestedSpot + 3);

            List<ParkingSpot> selectedParkingSpots = new List<ParkingSpot> { spot1, spot2, spot3, spot4 };
            return selectedParkingSpots;
        }

    }

}




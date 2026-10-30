using Class_Library_PP2;
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

        public List<ParkingSpot> ParkingSpots { get; set;  } = new List<ParkingSpot>();

        /* ---------- Constructors ---------- */
        public ParkingGarage()
        {
            
        }
        public ParkingGarage(int totalSpots)
        { 
            for (int i = 1; i <= totalSpots; i++)
            {
                ParkingSpots.Add(new ParkingSpot(i, CheckExsistingConfigFile().totalCapacity));
            } 
        }

        /* ---------- Methods ---------- */
        public ParkingSpot FindFirstEmptyParkingSpot(Vehicle vehicle)
        { 
            foreach (var spot in ParkingSpots)
            {

                if (spot.RemainingSize >= vehicle.Size)
                {
                    spot.ParkVehicleOnSpot(vehicle);
                    this.ParkingSpots.Contains(spot);
                    SaveParkingGarage("parkingGarage.json", this);
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
        public void MoveVehicle(string requestedLicencePlate, int requestedNewSpot)
        {
            ParkingSpot currentSpot = FindLicencePlateInParkingSpot(requestedLicencePlate);
            Vehicle foundVehicle = CollectVehicleFromLicencePlate(currentSpot, requestedLicencePlate);
            ParkingSpot newSpot = FindParkingSpotId(requestedNewSpot);
            if (newSpot.RemainingSize >= foundVehicle.Size)
            {
                newSpot.ParkVehicleOnSpot(foundVehicle);
                this.ParkingSpots.Contains(newSpot);
                SaveParkingGarage("parkingGarage.json", this);

                currentSpot.VacateVehicleSpot(foundVehicle);
                this.ParkingSpots.Contains(currentSpot);
                SaveParkingGarage("parkingGarage.json", this);

                PrintOut.parkVehicleAtSpot(newSpot, foundVehicle);
            }
            else PrintOut.parkingSpotIsFull(newSpot, foundVehicle);
                
        }

        public static Vehicle CollectVehicleFromLicencePlate(ParkingSpot parkingSpot, string requestedLicencePlate)
        {
            Vehicle foundVehicle = parkingSpot.ParkedVehicles.FirstOrDefault(v => v.LicencePlate == requestedLicencePlate);
            return foundVehicle;
        }
        public void ParkCar()
        {
            ParkingGarage parkingGarage = LoadParkingGarage("parkingGarage.json");

            Vehicle car = new Car(PrintOut.getLicencePlate());

            ParkingSpot pSpot = parkingGarage.FindFirstEmptyParkingSpot(car);
            
            PrintOut.parkVehicleAtSpot(pSpot, car);
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

        public static ParkingGarage CheckExsistingParkingGarage()
        {
            bool checkForFile = MyFiles.CheckForFile("parkingGarage.json");
            if (!checkForFile)
            {
                AppConfig configFile = CheckExsistingConfigFile();
                ParkingGarage parkingGarage = new ParkingGarage(configFile.numberOfParkingSpots);
                parkingGarage.SaveParkingGarage("parkingGarage.json", parkingGarage);
                return parkingGarage;
            }
            else
            {
                ParkingGarage parkingGarage = ParkingGarage.LoadParkingGarage("parkingGarage.json");
                return parkingGarage;
            }

        }
        public static AppConfig CheckExsistingConfigFile()
        {// TODO Move to AppConfig where it belongs. 
            bool checkForFile = MyFiles.CheckForFile("PP2_config.json");
            if (!checkForFile)
            {
                AppConfig configFile = new AppConfig();
                SetupParkingGarageConfiguration(configFile);
                return configFile;
            }
            else
            {
                AppConfig configFile = ParkingGarage.LoadConfigFile("PP2_config.json");
                return configFile;
            }

        }

        public void ParkMotorCycle()
        {
            ParkingGarage parkingGarage = LoadParkingGarage("parkingGarage.json");

            Vehicle motorCycle = new Motorcycle(PrintOut.getLicencePlate());

            ParkingSpot pSpot = parkingGarage.FindFirstEmptyParkingSpot(motorCycle);

            PrintOut.parkVehicleAtSpot(pSpot, motorCycle);
        }
        public static bool SetupParkingGarageConfiguration(AppConfig content)
        {
            string jsonString = JsonSerializer.Serialize(content);
            MyFiles.Save("PP2_config.json", jsonString);
            return true;
        }
        //public static bool ConfigNumberOfParkingSpots()
        //{

        //    return true;
        //}
        //public static bool ConfigVehicleTypes()
        //{

        //    return true;
        //}
        //public static bool ConfigPSpotTotalCapacity()
        //{

        //    return true;
        //}
    }
}



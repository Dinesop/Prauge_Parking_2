using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._1.Classes
{
    public static class GarageTestData
    {
        private static readonly Random _rng = new();

        public static void Populate(AppConfig appConfig, int vehicles)
        {
            string filePath = appConfig.ParkingGarageFilePath + ".json";
            ParkingGarage parkingGarage = ParkingGarage.LoadParkingGarage(filePath);

            for (int i = 0; i < vehicles; i++)
            {
                CreateRandomVehicle(appConfig, parkingGarage, filePath);
            }
            PrintOut.pressAnyKeyToContinue();
        }

        public static IVehicle CreateRandomVehicle(AppConfig appConfig, ParkingGarage parkingGarage, string filePath)
        {

            return _rng.Next(4) switch
            {
                0 => SimParkCar(appConfig, parkingGarage, filePath),
                1 => SimParkMC(appConfig, parkingGarage, filePath),
                2 => SimParkBus(appConfig, parkingGarage, filePath),
                _ => SimParkBicycle(appConfig, parkingGarage, filePath)
            };
        }
        public static IVehicle SimParkCar(AppConfig appConfig, ParkingGarage parkingGarage, string filePath)
        {
            
            IVehicle car = new Car(GenerateLicencePlate(), appConfig);
            bool validationCheck = Validator.ValidateNewVehicle(car);
            if (validationCheck) { ParkingSpot pSpot = parkingGarage.FindFirstEmptyParkingSpot(car, filePath); PrintOut.simParkVehicleAtSpot(pSpot, car); }
            else PrintOut.ParkingFailed();
            return car;
        }
        public static IVehicle SimParkMC(AppConfig appConfig, ParkingGarage parkingGarage, string filePath)
        {
            IVehicle motorcycle = new Motorcycle(GenerateLicencePlate(), appConfig);
            bool validationCheck = Validator.ValidateNewVehicle(motorcycle);
            if (validationCheck) { ParkingSpot pSpot = parkingGarage.FindFirstEmptyParkingSpot(motorcycle, filePath); PrintOut.simParkVehicleAtSpot(pSpot, motorcycle); }
            else PrintOut.ParkingFailed();

            return motorcycle;
        }
        public static IVehicle SimParkBus(AppConfig appConfig, ParkingGarage parkingGarage, string filePath)
        {
            IVehicle bus = new Bus(GenerateLicencePlate(), appConfig);
            bool validationCheck = Validator.ValidateNewVehicle(bus);
            if (validationCheck) { List<ParkingSpot> pSpot = parkingGarage.FindFirstEmptyParkingSpotForBus(bus, filePath, appConfig); PrintOut.simParkBusAtSpot(pSpot, bus); }
            else PrintOut.ParkingFailed();
            return bus;
        }
        public static IVehicle SimParkBicycle(AppConfig appConfig, ParkingGarage parkingGarage, string filePath)
        {
            int nrOfBikes = parkingGarage.BicycleCounter(parkingGarage); ;
            int bikeId = nrOfBikes + 1;
            string completeBikeId = GenerateBicycleColor() + bikeId;
            IVehicle bike = new Bicycle(completeBikeId, appConfig);
            bool validationCheck = Validator.ValidateNewVehicle(bike);

            if (validationCheck) { ParkingSpot pSpot = parkingGarage.FindFirstEmptyParkingSpot(bike, filePath); PrintOut.simParkVehicleAtSpot(pSpot, bike); }
            else PrintOut.ParkingFailed();
            return bike;
        }
        public static string GenerateLicencePlate(Random? rng = null)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digits = "0123456789";
            int length = 10;

            rng ??= Random.Shared;
            var letters = length / 2;
            var numbers = length - letters;

            var plate = new char[letters + numbers];
            for (int i = 0; i < letters; i++)
                plate[i] = chars[rng.Next(chars.Length)];
            for (int i = letters; i < plate.Length; i++)
                plate[i] = digits[rng.Next(digits.Length)];

            return new string(plate);
        }
        public static string GenerateBicycleColor(Random? rng = null)
        {
            string[] Palette =
            {
            "Red", "Blue", "Green", "Yellow", "Orange", "Purple",
            "Pink", "Brown", "Black", "White", "Gray", "Cyan",
            "Magenta", "Lime", "Teal", "Navy", "Olive", "Maroon"
             };
            rng ??= Random.Shared;
            return Palette[rng.Next(Palette.Length)];
        }

    }
}

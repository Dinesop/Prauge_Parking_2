using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._1.Classes
{
    public static class Validator
    {
        /* ---------- Methods ---------- */
        public static bool ValidateLicencePlate(string submittedLicencePlate)
        {// 31/10 commented out CheckedLicencePlateLenght because realiszed it was not in the new spec. 

            bool test1 = CheckNullOrWhiteSpace(submittedLicencePlate);
            bool test2 = CheckLicencePlateLenght(submittedLicencePlate);

            if (test1 && test2) return true;
            else return false;
        }
        static bool CheckNullOrWhiteSpace(string submittedLicencePlate)
        {
            if (String.IsNullOrWhiteSpace(submittedLicencePlate))
            {
                PrintOut.ErrorNullOrWhiteSpace();
                return false;
            }

            else return true;
        }
        static bool CheckLicencePlateLenght(string submittedLicencePlate)
        {
            if (submittedLicencePlate.Length > 10)
            {
                PrintOut.ErrorLicencePlateLenght();
                return false;
            }

            else return true;
        }
        public static bool ValidateNewVehicle(IVehicle vehicle)
        {
            if (vehicle.LicencePlate == null) return false;

            else return true;
        }
        public static bool TrySetNumberOfParkingSpots(int newCount, AppConfig configFile)
        {
            if (newCount < 0)
                return false;

            if (newCount >= configFile.NumberOfParkingSpots)
            {
                return true;
            }
            return true;
        }
        public static bool TrySetNumberOfParkingSpots(int newCount, AppConfig configFile, ParkingGarage parkingGarage)
        {
            if (newCount < 0)
                return false;

            if (newCount >= configFile.NumberOfParkingSpots)
            {
                return true;
            }

            for (int i = newCount; i < configFile.NumberOfParkingSpots; i++)
            {
                if (!parkingGarage.ParkingSpots[i].IsEmpty)
                    return false; 
            }
            return true;
        }
    }
}

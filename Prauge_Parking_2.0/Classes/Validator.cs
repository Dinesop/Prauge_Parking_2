using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public static class Validator
    {
        /* ---------- Methods ---------- */
        public static bool ValidateLicencePlate(string submittedLicencePlate)
        {
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
        public static bool ValidateNewVehicle(Vehicle vehicle)
        {
            if (vehicle.LicencePlate == null) return false;

            else return true;
        }
    }
}

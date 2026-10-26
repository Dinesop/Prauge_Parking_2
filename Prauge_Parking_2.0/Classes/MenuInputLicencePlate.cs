using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class MenuInputLicencePlate
    {
        public static string GetMenuInputLicencePlate()
        {
            var name = AnsiConsole.Ask<string>("Please input the vehicle licence plate:");
            return name;
            

        }

    }
}

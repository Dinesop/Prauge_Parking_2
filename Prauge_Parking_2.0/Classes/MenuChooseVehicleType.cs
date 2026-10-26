using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class MenuChooseVehicleType : Menu
    {
        /* ---------- Constructor ---------- */
        public MenuChooseVehicleType()
        {
            MenuChoice = AnsiConsole.Prompt(
                         new SelectionPrompt<string>()
                         .Title("Select the vehicle you wish to park:")
                         .AddChoices("Car", "Motorcycle", "Bus", "Bicycle", "Back"));

        }

    }
}




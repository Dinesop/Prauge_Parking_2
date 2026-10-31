using Prauge_Parking_2._1.Classes;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._1.Classes
{
    public class MenuChooseVehicleType : IMenu
    {
        public string MenuChoice { get; set; }
        /* ---------- Constructor ---------- */
        public MenuChooseVehicleType(List<string> allowedVehicleTypes)
        {
            MenuChoice = AnsiConsole.Prompt(
                         new SelectionPrompt<string>()
                         .Title("Select the vehicle you wish to park:")
                         .AddChoices(allowedVehicleTypes)
                         .AddChoices("Back"));
        }

        
    }
}




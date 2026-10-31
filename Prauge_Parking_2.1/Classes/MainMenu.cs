using Prauge_Parking_2._1.Classes;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._1.Classes
{
    public class MainMenu : IMenu
    {
        public string MenuChoice { get; set; }
        public MainMenu()
        {
            List<string> menuChoices = new List<string>{ "Add a vehicle", "Move a vehicle", "Retrieve a vehicle", "Search for a vehicle", "Overview", "Change pricing", "Change parking garage configuration", "Quit" };
            AnsiConsole.Clear();
            MenuChoice = AnsiConsole.Prompt(
                         new SelectionPrompt<string>()
                         .Title("Select an [green]option[/]:")
                         .AddChoices(menuChoices)); 
        }



    }
}

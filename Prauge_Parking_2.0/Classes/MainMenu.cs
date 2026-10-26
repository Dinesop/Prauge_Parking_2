using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class MainMenu : Menu
    {
        public MainMenu()
        {
            AnsiConsole.Clear();
            MenuChoice = AnsiConsole.Prompt(
                         new SelectionPrompt<string>()
                         .Title("Select an [green]option[/]:")
                         .AddChoices("Add a vehicle", "Move a vehicle", "Retrieve a vehicle", "Search for a vehicle", "Optimize MC parking", "Overview", "Quit"));
        }

    }
}

using Prauge_Parking_2._0.Classes;
using Spectre.Console;
using System.Drawing;

namespace Prauge_Parking_2._0
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            
            PowerSwitch powerSwitch = new PowerSwitch();
            ParkingGarage praugeParking = new ParkingGarage(5);
            while (powerSwitch.IsOn)
            {
                AnsiConsole.Clear();
                var choice = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("Select an [green]option[/]:")
                                .AddChoices("Add a vehicle", "Move a vehicle", "Retrieve a vehicle", "Search for a vehicle", "Optimize MC parking", "Overview", "Quit"));

                switch (choice)
                {
                    case "Add a vehicle":
                        MenuChooseVehicleType chooseVehicleType = new MenuChooseVehicleType();
                        
                        break;

                    case "Move a vehicle":
                        break;

                    case "Retrieve a vehicle":

                        break;

                    case "Search for a vehicle":
                        break;

                    case "Optimize MC parking":
                        break;

                    case "Overview":
                        break;

                    case "Quit":
                        powerSwitch.TurnOff();
                        break;
                }
            }





            //praugeParking.FindFirstEmptyParkingSpot(new Car("tre123"));
            //praugeParking.FindFirstEmptyParkingSpot(new Car("abc456"));
            //praugeParking.FindFirstEmptyParkingSpot(new Car("vbn678"));
            //praugeParking.FindFirstEmptyParkingSpot(new Car("rty246"));
            //praugeParking.RetriveVehicle("abc456");
            //praugeParking.MoveVehicle("vbn678", 5);

            //Menu meny = new Menu();

            Console.WriteLine("Placeholder");
        }
    }
}





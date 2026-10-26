using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class MenuChooseVehicleType : Menu
    {
        public MenuChooseVehicleType()
        {
            PowerSwitch powerSwitch2 = new PowerSwitch();
            //ParkingGarage praugeParking = new ParkingGarage(5);
            while (powerSwitch2.IsOn)
            {
                var choice = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("Select the vehicle you wish to park:")
                                .AddChoices("Car", "Motorcycle", "Bus", "Bicycle", "Back"));

                switch (choice)
                {
                    case "Car":
                        //MenuInputLicencePlate temp = new MenuInputLicencePlate();
                       
                        Vehicle car = new Car();
                        praugeParking.FindFirstEmptyParkingSpot(car);
                        powerSwitch2.TurnOff();
                        break;

                    case "Motorcycle":
                        break;

                    case "Bus":

                        break;

                    case "Bicycle":
                        break;

                    case "Back":
                        powerSwitch2.TurnOff();
                        break;
                }
            }


        }

    }
}




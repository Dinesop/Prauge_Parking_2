using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class MainMenuSwitch : Menu
    {

        public MainMenuSwitch()
        {
            
            PowerSwitch powerSwitchMainMenu = new PowerSwitch();
            while (powerSwitchMainMenu.IsOn)
            {
                Menu mainMenu = new MainMenu();
                switch (mainMenu.MenuChoice)
                {
                    case "Add a vehicle":
                        MenuChooseVehicleTypeSwitch addAVehicleSwitch = new MenuChooseVehicleTypeSwitch();
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
                        powerSwitchMainMenu.TurnOff();
                        break;
                }
            }
        }
    }
}

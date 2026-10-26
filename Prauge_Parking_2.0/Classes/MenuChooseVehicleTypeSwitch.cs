using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class MenuChooseVehicleTypeSwitch : Menu
    {
        public MenuChooseVehicleTypeSwitch()
        {
            PowerSwitch powerSwitchChooseVehicleType = new PowerSwitch();
            while (powerSwitchChooseVehicleType.IsOn)
            {
                Menu menuChooseVehicleType = new MenuChooseVehicleType();
                switch (menuChooseVehicleType.MenuChoice)
                {
                    case "Car":
                        Vehicle car = new Car();
                        //praugeParking.FindFirstEmptyParkingSpot(car);
                        powerSwitchChooseVehicleType.TurnOff();
                        break;

                    case "Motorcycle":
                        break;

                    case "Bus":

                        break;

                    case "Bicycle":
                        break;

                    case "Back":
                        powerSwitchChooseVehicleType.TurnOff();
                        break;
                }
            }
        }
    }
}

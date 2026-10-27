using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class MainMenuSwitch : Menu
    {
        public MainMenuSwitch(ParkingGarage parkingGarage)
        {
            PowerSwitch powerSwitchMainMenu = new PowerSwitch();
            while (powerSwitchMainMenu.IsOn)
            {
                Menu mainMenu = new MainMenu();
                ParkingSpot pSpot = null;
                Receipt endedParking = null;
                string requestedLicencePlate = "";
                int newSpot = 0;

                switch (mainMenu.MenuChoice)
                {
                    case "Add a vehicle":
                        MenuChooseVehicleType chooseVehicleTypeToAdd = new MenuChooseVehicleType();
                        switch (chooseVehicleTypeToAdd.MenuChoice)
                        {
                            case "Car":
                                Vehicle car = new Car();
                                pSpot = parkingGarage.FindFirstEmptyParkingSpot(car);
                                PrintOut.parkVehicleAtSpot(pSpot);
                                break;

                            case "Motorcycle":
                                Vehicle motorCycle = new Motorcycle();
                                pSpot = parkingGarage.FindFirstEmptyParkingSpot(motorCycle);
                                PrintOut.parkVehicleAtSpot(pSpot);
                                break;

                            case "Bus":

                                break;

                            case "Bicycle":

                                break;

                        }
                        break;

                    case "Move a vehicle":
                        MenuChooseVehicleType chooseVehicleTypeToMove = new MenuChooseVehicleType();
                        
                        switch (chooseVehicleTypeToMove.MenuChoice)
                        {
                            case "Car":
                                requestedLicencePlate = PrintOut.getLicencePlate();
                                newSpot = PrintOut.requestedNewSpot();
                                parkingGarage.MoveVehicle(requestedLicencePlate, newSpot);
                                break;

                            case "Motorcycle":
                                requestedLicencePlate = PrintOut.getLicencePlate();
                                newSpot = PrintOut.requestedNewSpot();
                                parkingGarage.MoveVehicle(requestedLicencePlate, newSpot);
                                break;

                            case "Bus":

                                break;

                            case "Bicycle":
                                break;

                        }
                        
                        break;

                    case "Retrieve a vehicle":
                        MenuChooseVehicleType chooseVehicleTypeToRetrieve = new MenuChooseVehicleType();
                        requestedLicencePlate = "";

                        switch (chooseVehicleTypeToRetrieve.MenuChoice)
                        {
                            case "Car":
                                requestedLicencePlate = PrintOut.getLicencePlate();
                                endedParking = parkingGarage.RetriveVehicle(requestedLicencePlate);
                                PrintOut.retrieveVehicleAtSpot(endedParking);
                                break;

                            case "Motorcycle":
                                requestedLicencePlate = PrintOut.getLicencePlate();
                                endedParking = parkingGarage.RetriveVehicle(requestedLicencePlate);
                                PrintOut.retrieveVehicleAtSpot(endedParking);
                                break;

                            case "Bus":

                                break;

                            case "Bicycle":
                                break;

                        }
                        break;

                    case "Search for a vehicle":
                        requestedLicencePlate = PrintOut.getLicencePlate();
                        pSpot = parkingGarage.FindLicencePlateInParkingSpot(requestedLicencePlate);
                        PrintOut.vehicleParkedAt(pSpot);
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

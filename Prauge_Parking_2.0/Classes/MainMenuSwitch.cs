using Class_Library_PP2;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

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

                ParkingGarage parkingGarage = ParkingGarage.CheckExsistingParkingGarage();

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
                                parkingGarage.ParkCar(); // TODO skicka med phus ist för att ladda in igen
                                break;

                            case "Motorcycle":
                                //Vehicle motorCycle = new Motorcycle();
                                //pSpot = parkingGarage.FindFirstEmptyParkingSpot(motorCycle);
                                //PrintOut.parkVehicleAtSpot(pSpot, motorCycle);
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
                        Vehicle requestedVehicle = parkingGarage.FindLicencePlate(requestedLicencePlate);
                        PrintOut.vehicleParkedAt(pSpot, requestedVehicle);
                        break;

                    case "Optimize MC parking":

                        break;

                    case "Overview":

                        break;

                    case "Quit":
                        powerSwitchMainMenu.TurnOff();
                        Console.WriteLine("The End");
                        break;
                }
            }
        }


    }
}

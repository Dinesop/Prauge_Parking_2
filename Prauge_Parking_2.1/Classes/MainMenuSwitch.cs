using Class_Library_PP2;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Prauge_Parking_2._1.Classes
{
    public class MainMenuSwitch
    {
        public MainMenuSwitch()
        {
            PowerSwitch powerSwitchMainMenu = new PowerSwitch();
            while (powerSwitchMainMenu.IsOn)
            {
                AppConfig configFile = AppConfig.CheckExsistingConfigFile();
                ParkingGarage parkingGarage = ParkingGarage.CheckExsistingParkingGarage(configFile);
                IMenu mainMenu = new MainMenu();
                
                ParkingSpot pSpot = null;
                Receipt endedParking = null;
                string requestedLicencePlate = "";
                string filePath = configFile.ParkingGarageFilePath + ".json";
                int newSpot = 0;

                switch (mainMenu.MenuChoice)
                {// TODO consider adding a default
                    case "Add a vehicle":
                        MenuChooseVehicleType chooseVehicleTypeToAdd = new MenuChooseVehicleType(configFile.AllowedVehicleTypes);
                        switch (chooseVehicleTypeToAdd.MenuChoice)
                        { // TODO consider adding a default
                            case "Car":
                                parkingGarage.ParkCar(filePath, configFile); 
                                break;

                            case "Motorcycle":
                                parkingGarage.ParkMotorCycle(filePath, configFile);
                                break;

                            case "Bus":
                                parkingGarage.ParkBus(filePath, configFile);
                                break;

                            case "Bicycle":
                                parkingGarage.ParkBicycle(filePath, configFile);
                                break;
                            
                            case "Back":

                                break;
                        }
                        break;

                    case "Move a vehicle":
                        MenuChooseVehicleType chooseVehicleTypeToMove = new MenuChooseVehicleType(configFile.AllowedVehicleTypes);

                        switch (chooseVehicleTypeToMove.MenuChoice)
                        {
                            case "Car":
                                requestedLicencePlate = PrintOut.getLicencePlate();
                                newSpot = PrintOut.requestedNewSpot();
                                parkingGarage.MoveVehicle(requestedLicencePlate, newSpot, filePath);
                                break;

                            case "Motorcycle":
                                requestedLicencePlate = PrintOut.getLicencePlate();
                                newSpot = PrintOut.requestedNewSpot();
                                parkingGarage.MoveVehicle(requestedLicencePlate, newSpot, filePath);
                                break;

                            case "Bus":
                                requestedLicencePlate = PrintOut.getLicencePlate();
                                newSpot = PrintOut.requestedNewSpot();
                                parkingGarage.MoveBus(requestedLicencePlate, newSpot, filePath);
                                break;

                            case "Bicycle":
                                break;

                        }

                        break;

                    case "Retrieve a vehicle":
                        MenuChooseVehicleType chooseVehicleTypeToRetrieve = new MenuChooseVehicleType(configFile.AllowedVehicleTypes);
                        requestedLicencePlate = "";

                        switch (chooseVehicleTypeToRetrieve.MenuChoice)
                        { // TODO change to a method instead.
                            case "Car":
                                requestedLicencePlate = PrintOut.getLicencePlate();
                                endedParking = parkingGarage.RetriveVehicle(requestedLicencePlate, configFile, filePath);
                                PrintOut.retrieveVehicleAtSpot(endedParking);
                                break;

                            case "Motorcycle":
                                requestedLicencePlate = PrintOut.getLicencePlate();
                                endedParking = parkingGarage.RetriveVehicle(requestedLicencePlate, configFile, filePath);
                                PrintOut.retrieveVehicleAtSpot(endedParking);
                                break;

                            case "Bus":
                                requestedLicencePlate = PrintOut.getLicencePlate();
                                endedParking = parkingGarage.RetriveBus(requestedLicencePlate, configFile, filePath);
                                PrintOut.retrieveVehicleAtSpot(endedParking);
                                break;

                            case "Bicycle":
                                requestedLicencePlate = PrintOut.getLicencePlate();
                                endedParking = parkingGarage.RetriveVehicle(requestedLicencePlate, configFile, filePath);
                                PrintOut.retrieveVehicleAtSpot(endedParking);
                                break;

                        }
                        break;

                    case "Search for a vehicle":
                        requestedLicencePlate = PrintOut.getLicencePlate();
                        pSpot = parkingGarage.FindLicencePlateInParkingSpot(requestedLicencePlate);
                        IVehicle requestedVehicle = parkingGarage.FindLicencePlate(requestedLicencePlate);
                        PrintOut.vehicleParkedAt(pSpot, requestedVehicle);
                        break;

                    case "Optimize parking":
                        // TODO add an optimizer

                        break;

                    case "Overview":
                        GraphicLayout.VisualizeParkingGarage(parkingGarage);
                        break;

                    case "Change pricing":

                        break;

                    case "Change parking garage configuration":

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

using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class Menu
    {
        // Properties
        public int MenuChoice { get; set; }
        // Constructor
        public Menu()
        {
            int MenuChoice = 1;
            PowerSwitch powerSwitch = new PowerSwitch();
            while (powerSwitch.IsOn)
            {
                Console.Clear();
                Console.WriteLine("Use the arrowkeys (Up/Down) and press Enter to make your choice:");
                Console.WriteLine(MenuChoice == 1 ? "> Add a vehicle" : "  Add a vehicle");
                Console.WriteLine(MenuChoice == 2 ? "> Move a vehicle" : "  Move a vehicle");
                Console.WriteLine(MenuChoice == 3 ? "> Retrieve a vehicle" : "  Retrieve a vehicle");
                Console.WriteLine(MenuChoice == 4 ? "> Search for a vehicle" : "  Search for a vehicle");
                Console.WriteLine(MenuChoice == 5 ? "> Optimize MC parking" : "  Optimize MC parking");
                Console.WriteLine(MenuChoice == 6 ? "> Overview" : "  Overview");
                Console.WriteLine(MenuChoice == 7 ? "> Quit" : "  Quit");

                var knapp = Console.ReadKey(false);
                if (knapp.Key == ConsoleKey.DownArrow && MenuChoice < 7) MenuChoice++;


                else if (knapp.Key == ConsoleKey.UpArrow && MenuChoice > 1) MenuChoice--;
                else if (knapp.Key == ConsoleKey.Enter) break;
            }


            switch (MenuChoice)
            {
                case 1:
                    {
                        // TODO: Gör en underklass eller metod för att visa VehicleMenu
                        Console.WriteLine("Choose the vehicle type you wish to park:");
                        PowerSwitch powerSwitch2 = new PowerSwitch();
                        while (powerSwitch2.IsOn)
                        {
                            Console.Clear();
                            Console.WriteLine("Use the arrowkeys (Up/Down) and press Enter to make your choice:");
                            Console.WriteLine(MenuChoice == 1 ? "> Car" : "  Car");
                            Console.WriteLine(MenuChoice == 2 ? "> Motorcycle" : "  Motorcycle");
                            Console.WriteLine(MenuChoice == 3 ? "> Bus" : "  Bus");
                            Console.WriteLine(MenuChoice == 4 ? "> Bicycle" : "  Bicycle");
                            Console.WriteLine(MenuChoice == 5 ? "> Back" : "  Back");

                            var knapp = Console.ReadKey(false);
                            if (knapp.Key == ConsoleKey.DownArrow && MenuChoice < 5) MenuChoice++;


                            else if (knapp.Key == ConsoleKey.UpArrow && MenuChoice > 1) MenuChoice--;
                            else if (knapp.Key == ConsoleKey.Enter) break;
                        }
                        switch (MenuChoice)
                        { // TODO: En ange reg metod eller klass tack!
                            case 1:
                                Console.WriteLine("Ange registreringsnumret:");
                                try
                                {

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"Oops something went wrong: {e.Message}");
                                }
                                break;

                            case 2:
                                //LicencePlateInput();
                                break;

                            case 3:

                                //LicencePlateInput();
                                break;

                            case 4:
                                //LicencePlateInput();
                                break;

                            case 5:
                                // TODO: Fixa så detta menyval leder tillbaka till huvudmenyn.
                                powerSwitch2.TurnOff();
                                break;
                        }
                    }
                    break;
                case 2:
                    //flyttaFordon();
                    break;
                case 3:
                    //hämtaUtFordon();
                    break;
                case 4:
                    //menyVal4();
                    break;
                case 5:
                    //optimeraMcParkering();
                    break;
                case 6:
                    //visualiseraPhusFärg();
                    break;
                case 7:
                    powerSwitch.TurnOff();
                    break;
            }

        }
    }
}

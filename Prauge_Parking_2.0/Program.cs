using Prauge_Parking_2._0.Classes;
using Spectre.Console;
using System.Drawing;

namespace Prauge_Parking_2._0
{

    internal class Program
    {
        static void Main(string[] args)
        {
            ParkingGarage parkingGarage = new ParkingGarage(5);
            MainMenuSwitch mainMenuSwitch = new MainMenuSwitch(parkingGarage);

            Console.WriteLine("The End");
        }
    }
}





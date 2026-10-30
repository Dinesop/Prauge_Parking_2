using Class_Library_PP2;
using Prauge_Parking_2._0.Classes;
using Spectre.Console;
using System.Drawing;
using System.Text.Json;

namespace Prauge_Parking_2._0
{

    internal class Program
    {
        static void Main(string[] args)
        { // TODO: när saker returnerar null om de går fel, kan man använda ArgumentNullException.ThrowIfNull eller liknande.

            //ParkingGarage parkingGarage = ParkingGarage.LoadParkingGarage("parkingGarage2.json");

            var unloadedJson = System.IO.File.ReadAllText("parkingGarage2.json");

            try
            {
                ParkingGarage parkingGarage2 = JsonSerializer.Deserialize<ParkingGarage>(unloadedJson);
                Console.WriteLine($"Loaded: spot 1 has {parkingGarage2?.ParkingSpots[0].ParkedVehicles.Count} vehicles");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            //MainMenuSwitch mainMenuSwitch = new MainMenuSwitch();

            //GraphicLayout.TestLive();


        }
    }
}





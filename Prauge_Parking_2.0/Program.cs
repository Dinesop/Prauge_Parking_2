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

            //ParkingGarage parkingGarage = new ParkingGarage(5);
            //MainMenuSwitch mainMenuSwitch = new MainMenuSwitch(parkingGarage);

            //GraphicLayout.TestLive();


            //// Serialize from object to JSON
            //Vehicle vehicle = new Car();
            //string jsonString = JsonSerializer.Serialize(vehicle);

            //// Write to file
            //File.WriteAllText("file_name.json", jsonString);

            // Define two dates.
            DateTime date1 = new DateTime(2010, 1, 1, 8, 0, 15);
            DateTime date2 = new DateTime(2010, 1, 1, 8, 20, 30);

            //// Calculate the interval between the two dates.
            TimeSpan interval = date2 - date1;

            TimeSpan rounded = TimeSpan.FromHours(Math.Round(interval.TotalHours));
            
            Console.WriteLine(interval);
            Console.WriteLine(rounded);

            Console.WriteLine("The End");
        }
    }
}





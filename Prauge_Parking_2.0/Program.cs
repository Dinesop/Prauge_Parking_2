using Prauge_Parking_2._0.Classes;
using Spectre.Console;
using System.Drawing;

namespace Prauge_Parking_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParkingGarage praugeParking = new ParkingGarage(5);

            //Vehicle namn1 = new Car("tre123");

            praugeParking.FindFirstEmptyParkingSpot(new Car("tre123"));
            praugeParking.FindFirstEmptyParkingSpot(new Car("abc456"));
            praugeParking.FindFirstEmptyParkingSpot(new Car("vbn678"));
            praugeParking.FindFirstEmptyParkingSpot(new Car("rty246"));
            // praugeParking.RetriveVehicle("abc456");
            // praugeParking.MoveVehicle("vbn678", 4);
            Console.WriteLine("Klar!");
        }
    }
}





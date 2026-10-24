namespace ParkingDemo
{
    // Object 1: The Car
    public class Car
    {
        public string LicensePlate { get; private set; }
        public string Model { get; private set; }

        public Car(string licensePlate, string model)
        {
            LicensePlate = licensePlate;
            Model = model;
        }
    }

    // Object 2: The Parking Spot
    public class ParkingSpot
    {
        public int SpotNumber { get; private set; }
        public bool IsOccupied { get; private set; }

        // This attribute holds a reference to the Car object currently parking here
        public Car ParkedCar { get; private set; }

        public ParkingSpot(int spotNumber)
        {
            SpotNumber = spotNumber;
            IsOccupied = false;
            ParkedCar = null; // No car initially
        }

        // The Interaction Method: It accepts a Car object as a parameter
        public bool ParkVehicle(Car car)
        {
            if (IsOccupied)
            {
                Console.WriteLine($"Spot #{SpotNumber} is already taken!");
                return false;
            }

            // Object Interaction Happens Here:
            IsOccupied = true;         // Change internal state
            ParkedCar = car;           // Link the Car object to this spot object

            Console.WriteLine($"Success: {car.Model} [{car.LicensePlate}] is now parked in Spot #{SpotNumber}.");
            return true;
        }

        public void VacateSpot()
        {
            if (IsOccupied)
            {
                Console.WriteLine($"{ParkedCar.Model} left Spot #{SpotNumber}.");
                IsOccupied = false;
                ParkedCar = null; // Break the link to the car object
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Instantiating our objects
            Car myCar = new Car("ABC-123", "Tesla Model Y");
            ParkingSpot spot101 = new ParkingSpot(101);

            Console.WriteLine("--- Arriving at the Parking Lot ---");

            // INTERACTION: We pass the 'myCar' object into the 'spot101' object's method
            spot101.ParkVehicle(myCar);

            // The ParkingSpot object can now read attributes belonging to the Car object
            if (spot101.IsOccupied)
            {
                Console.WriteLine($"Security Check: The vehicle in spot 101 has plate: {spot101.ParkedCar.LicensePlate}");
            }

            Console.WriteLine("\n--- Leaving Later ---");
            spot101.VacateSpot();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Prauge_Parking_2._0.Classes
{
    public class Receipt 
    {
        public IVehicle ParkedVehicle { get; }
        public TimeSpan ParkedDuration { get; }
        public int ParkingSpotId { get; }
        public decimal CostOfParking { get;  }
        public TimeSpan FreeParkingTime { get; }
        public Receipt(ParkingSpot parkingSpot, TimeSpan parkedDuration, IVehicle foundVehicle, TimeSpan freeParkingTime)
        {
            ParkedVehicle = foundVehicle;
            ParkedDuration = parkedDuration;
            ParkingSpotId = parkingSpot.ParkingSpotId;
            CostOfParking = CalculatedCostOfParking(parkedDuration, foundVehicle, freeParkingTime);
            FreeParkingTime = freeParkingTime;
        }

        public decimal CalculatedCostOfParking(TimeSpan parkedDuration, IVehicle vehicle, TimeSpan freeParkingTime)
        {
            if (parkedDuration < freeParkingTime) return 0M;

            TimeSpan bufferTime = new TimeSpan(0, 30, 0);
            TimeSpan hourStarted = parkedDuration + bufferTime;
            int covertedTimespan = Convert.ToInt32(hourStarted);// TODO lägg i ett try catch block
            return vehicle.Price * covertedTimespan;

        }
    }
}

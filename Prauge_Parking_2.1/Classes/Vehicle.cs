using Prauge_Parking_2._1.Classes;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json.Serialization;

namespace Prauge_Parking_2._1.Classes
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Car), "Car")]
    [JsonDerivedType(typeof(Motorcycle), "Motorcycle")]
    [JsonDerivedType(typeof(Bicycle), "Bicycle")]
    //[JsonDerivedType(typeof(Bus), "Bus")]
    public abstract class Vehicle : IVehicle
    {
        /* ---------- Properties ---------- */
        // TODO if there is time, try changing to private set with JsonInclude instead
        public string LicencePlate { get;  set; }
        public abstract int Size { get; set; }
        public DateTime CheckIn { get; set; }
        public abstract string VehicleType { get; set; }
        public abstract decimal Price { get; set; }

        /* ---------- Constructors ---------- */
        public Vehicle()
        {
            
        }
        public Vehicle(string licencePlate)
        {
            LicencePlate = licencePlate;
            CheckIn = DateTime.UtcNow;
        }
        public Vehicle(string licencePlate, AppConfig appConfig)
        {
            LicencePlate = licencePlate;
            CheckIn = DateTime.UtcNow;
        }
    }
}

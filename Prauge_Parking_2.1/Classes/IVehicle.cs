using Prauge_Parking_2._1.Classes;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json.Serialization;

namespace Prauge_Parking_2._0.Classes
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Car), "Car")]
    [JsonDerivedType(typeof(Motorcycle), "Motorcycle")]
    [JsonDerivedType(typeof(Bicycle), "Bicycle")]
    //[JsonDerivedType(typeof(Bus), "Bus")]
    public interface IVehicle
    {
        /* ---------- Properties ---------- */
        string LicencePlate { get;  set; }
        int Size { get; set; }
        DateTime CheckIn { get; set; }
        string VehicleType { get; set; }
        decimal Price { get; set; }

    }
}

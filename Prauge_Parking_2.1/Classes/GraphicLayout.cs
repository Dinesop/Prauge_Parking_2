using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Prauge_Parking_2._1.Classes
{
    internal class GraphicLayout
    {
        public static int ColumnSetupMax { get; private set; }
        public static int RowSetupMax { get; private set; }

        public GraphicLayout()
        {
            AppConfig configFile = AppConfig.CheckExsistingConfigFile();
            int testOfDivisability = configFile.NumberOfParkingSpots % 10;
            if (testOfDivisability == 0)
            {
                RowSetupMax = configFile.NumberOfParkingSpots / 10;
                ColumnSetupMax = 10;
            }
            else
            {
                RowSetupMax = 0;
                ColumnSetupMax = configFile.NumberOfParkingSpots;
            }
        }

        public static void VisualizeParkingGarage(ParkingGarage parkingGarage)
        {//TODO need to be related to the config file and number of parking spots
         // Tabel setup

            GraphicLayout graphicLayout = new GraphicLayout();
            //ParkingGarage parkingGarage = ParkingGarage.LoadParkingGarage(filePath);

            var table = new Table()
            .RoundedBorder()
            .ShowRowSeparators()
            .BorderColor(Spectre.Console.Color.Grey)
            .Title("[bold]The Parkinggarage[/]");

            // Colum setup


            for (int colSetup = 0; colSetup < ColumnSetupMax; colSetup++)
            {
                table.AddColumn($"{colSetup + 1}", col => col.Width(100));
            }

            // Row setup

            for (int rowSetup = 0; rowSetup < RowSetupMax; rowSetup++)
            {
                table.AddRow("", "", "", "", "", "", "", "", "", "");
            }

            // Fyll tabellen med stapeldiagram för att visa om p-platserna är fulla, halvfulla eller tomma. 

            //for (int index = 0; index < parkingGarage.ParkingSpots.Count; index++)
            //{// Added a for loop with index to stop eternal looping of rows.
            int index = 0;
            for (int row = 0; row < RowSetupMax; row++)
            {
                for (int col = 0; col < ColumnSetupMax; col++)
                {
                    {
                        if (parkingGarage.ParkingSpots[index].IsEmpty)
                        {
                            table.UpdateCell(row, col, new BarChart()
                             .HideValues()
                             .AddItem($"", 1, Spectre.Console.Color.Green)
                             .AddItem($"", 1, Spectre.Console.Color.Green));
                        }

                        else if (parkingGarage.ParkingSpots[index].RemainingSize != 0)
                        {
                            table.UpdateCell(row, col, new BarChart()
                            .HideValues()
                            .AddItem($"", 1, Spectre.Console.Color.Yellow));
                        }

                        else //(parkingGarage[index].Contains("BIL") || parkingGarage[index].Contains("|"))
                        {
                            table.UpdateCell(row, col, new BarChart()
                             .HideValues()
                             .AddItem($"", 1, Spectre.Console.Color.Red3)
                             .AddItem($"", 1, Spectre.Console.Color.Red3));
                        }

                    }
                    index++;
                }

            }
            //}
            // Skriver ut tabellen i konsolfönstret
            AnsiConsole.Write(table);
            PrintOut.pressAnyKeyToContinue();
        }

    }
}


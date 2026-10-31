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

            for (int index = 0; index < parkingGarage.ParkingSpots.Count; index++)
            {// Added a for loop with index to stop eternal looping of rows.
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
                    }
                }
            }
            // Skriver ut tabellen i konsolfönstret
            AnsiConsole.Write(table);
            PrintOut.pressAnyKeyToContinue();
        }

        public static void TestLive()
        {
            // Create status table
            var statusTable = new Table()
                .Border(TableBorder.Rounded)
                .BorderColor(Color.Cyan)
                .AddColumn("Service")
                .AddColumn("Status")
                .AddColumn("Requests/sec");

            // Create metrics table
            var metricsTable = new Table()
                .Border(TableBorder.Rounded)
                .BorderColor(Color.Yellow)
                .AddColumn("Metric")
                .AddColumn("Current")
                .AddColumn("Average");

            // Create layout with both tables
            var layout = new Layout("Root")
                .SplitRows(
                    new Layout("Header"),
                    new Layout("Body").SplitColumns(
                        new Layout("Status"),
                        new Layout("Metrics")
                    )
                );

            layout["Header"].Update(
                new Panel("[bold cyan]Real-Time Dashboard[/]")
                    .BorderColor(Color.Blue)
                    .Padding(1, 0)
            );

            layout["Status"].Update(new Panel(statusTable).Header("Services"));
            layout["Metrics"].Update(new Panel(metricsTable).Header("System Metrics"));

            AnsiConsole.Live(layout)
                .Start(ctx =>
                {
                    for (int i = 0; i < 15; i++)
                    {
                        // Update status table
                        statusTable.Rows.Clear();
                        statusTable.AddRow("API Gateway", "[green]Healthy[/]", $"{Random.Shared.Next(100, 500)}");
                        statusTable.AddRow("Auth Service", "[green]Healthy[/]", $"{Random.Shared.Next(50, 200)}");
                        statusTable.AddRow("Database", i > 10 ? "[yellow]Degraded[/]" : "[green]Healthy[/]", $"{Random.Shared.Next(200, 800)}");
                        statusTable.AddRow("Cache", "[green]Healthy[/]", $"{Random.Shared.Next(1000, 3000)}");

                        // Update metrics table
                        metricsTable.Rows.Clear();
                        metricsTable.AddRow("CPU", $"{Random.Shared.Next(20, 75)}%", "45%");
                        metricsTable.AddRow("Memory", $"{Random.Shared.Next(4, 12)} GB", "8 GB");
                        metricsTable.AddRow("Disk I/O", $"{Random.Shared.Next(10, 90)} MB/s", "45 MB/s");
                        metricsTable.AddRow("Network", $"{Random.Shared.Next(100, 500)} MB/s", "250 MB/s");

                        ctx.Refresh();
                        Thread.Sleep(1000);
                    }
                });
        }
    }
}


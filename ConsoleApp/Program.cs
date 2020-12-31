using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp {
    class Program {
        static void Main(string[] args) {
            var list = new List<IVehicle>() {
                new LandVehicle(150, IVehicle.FuelType.LPG, 4),
                new LandVehicle(300, IVehicle.FuelType.Diesel, 4),
                new LandVehicle(80, IVehicle.FuelType.Benzine, 2),
                new AirVehicle(1000, IVehicle.FuelType.Diesel),
                new AirVehicle(2000, IVehicle.FuelType.Diesel),
                new SeaVehicle(500, 1000),
                new SeaVehicle(464, 950)
            };

            list[0].IncreaseSpeed(100);
            list[2].IncreaseSpeed(15);
            list[3].IncreaseSpeed(33);
            list[4].IncreaseSpeed(295);
            list[5].IncreaseSpeed(21);
            list[6].IncreaseSpeed(12);

            foreach(var el in list) {
                Console.WriteLine(el);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tylko pojazdy lądowe:");

            foreach(var el in list) {
                if(el is LandVehicle) {
                    Console.WriteLine(el);
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Pojazdy od najwolniejszego:");
            var list1 = list.Select(x => x).OrderBy(x => x.ConvertUnitToKmh());
            foreach(var el in list1) {
                Console.WriteLine(el);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tylko pojazdy w środowisku lądowym od najwolniejszego:");
            var list2 = list.Select(x => x)
                .Where(x => (x.CurrentEnvironment.Type == IEnvironment.Types.Land))
                .OrderBy(x => x.Speed);
            foreach(var el in list2) {
                Console.WriteLine(el);
            }
        }
    }
}

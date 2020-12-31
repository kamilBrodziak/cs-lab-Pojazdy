using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary {

    public static class Environments {
        // klasa stworzona po to, by nie tworzyć dla każdego nowego pojazdu nowego środowiska
        private static LandEnvironment landEnvironment = new LandEnvironment();
        private static SeaEnvironment seaEnvironment = new SeaEnvironment();
        private static AirEnvironment airEnvironment = new AirEnvironment();
        public static LandEnvironment Land => landEnvironment;
        public static SeaEnvironment Sea => seaEnvironment;
        public static AirEnvironment Air => airEnvironment;

    }

    public interface IEnvironment {
        public int MinSpeed { get; }
        public int MaxSpeed { get; }
        public string Unit { get; }
        public enum Types { Air, Land, Sea};
        public Types Type { get; }
    }

    public class LandEnvironment : IEnvironment {
        public int MinSpeed => 1;
        public int MaxSpeed => 350;
        public string Unit => "km/h";

        public IEnvironment.Types Type => IEnvironment.Types.Land;
    }

    public class SeaEnvironment : IEnvironment {
        public int MinSpeed => 1;
        public int MaxSpeed => 40;
        public string Unit => "knot";
        public IEnvironment.Types Type => IEnvironment.Types.Sea;
    }

    public class AirEnvironment : IEnvironment {
        public int MinSpeed => 20;
        public int MaxSpeed => 200;
        public string Unit => "m/s";
        public IEnvironment.Types Type => IEnvironment.Types.Air;
    }
}

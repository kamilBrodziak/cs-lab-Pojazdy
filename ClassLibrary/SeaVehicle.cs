using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary {
    public class SeaVehicle : IVehicle {
        public int HorsePower { get; }
        public int Buyoancy { get; }
        public IVehicle.FuelType Fuel { get; }
        public IEnvironment CurrentEnvironment { get; private set; } = Environments.Sea;
        public int Speed { get; private set; } = 0;
        public SeaVehicle(int horsePower, int buyoancy) {
            HorsePower = horsePower;
            Fuel = IVehicle.FuelType.Diesel;
            Buyoancy = buyoancy;
        }
        public override string ToString() {
            var vehicle = ((IVehicle)this);
            var unit = CurrentEnvironment.Unit;
            return $"Type:Land Vehicle, Current Environment: {CurrentEnvironment.Type}," +
                $" State:{vehicle.State}, Min Speed:{CurrentEnvironment.MinSpeed}{unit}," +
                $"Max Speed:{CurrentEnvironment.MinSpeed}{unit}, Speed:{Speed}{unit}, " +
                $"Horse Power:{HorsePower}, Fuel type: {Fuel}, Buyoancy: {Buyoancy}";
        }

        public void DecreaseSpeed(int speed) {
            if(Speed - speed >= CurrentEnvironment.MinSpeed) {
                Speed -= speed;
            } else {
                Speed = 0;
            }
        }

        public void IncreaseSpeed(int speed) {
            if(Speed + speed <= CurrentEnvironment.MaxSpeed) {
                Speed += speed;
            }
        }
    }
}

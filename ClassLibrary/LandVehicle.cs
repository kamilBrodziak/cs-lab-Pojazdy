using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary {

    public class LandVehicle : IVehicle {
        public int HorsePower { get; }
        public int WheelCount { get; }
        public IVehicle.FuelType Fuel { get; }
        public IEnvironment CurrentEnvironment { get; private set; } = Environments.Land;
        public int Speed { get; private set; } = 0;
        public LandVehicle(int horsePower, IVehicle.FuelType fuel, int wheelCount) {
            HorsePower = horsePower;
            Fuel = fuel;
            WheelCount = wheelCount;
        }
        public override string ToString() {
            var vehicle = ((IVehicle)this);
            var unit = CurrentEnvironment.Unit;
            return $"Type:Land Vehicle, Current Environment: {CurrentEnvironment.Type}," +
                $" State:{vehicle.State}, Min Speed:{CurrentEnvironment.MinSpeed}{unit}," +
                $"Max Speed:{CurrentEnvironment.MinSpeed}{unit}, Speed:{Speed}{unit}, " +
                $"Horse Power:{HorsePower}, Fuel type: {Fuel}, Wheel Count: {WheelCount}";
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

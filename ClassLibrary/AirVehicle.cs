using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary {
    public class AirVehicle : IVehicle {
        public int HorsePower { get; }
        public IVehicle.FuelType Fuel { get; }
        public IEnvironment CurrentEnvironment { get; private set; } = Environments.Land;
        public int Speed { get; private set; } = 0;
        public AirVehicle(int horsePower, IVehicle.FuelType fuel) {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public override string ToString() {
            var vehicle = ((IVehicle)this);
            var unit = CurrentEnvironment.Unit;
            return $"Type:Land Vehicle, Current Environment: {CurrentEnvironment.Type}," +
                $" State:{vehicle.State}, Min Speed:{CurrentEnvironment.MinSpeed}{unit}," +
                $"Max Speed:{CurrentEnvironment.MinSpeed}{unit}, Speed:{Speed}{unit}, " +
                $"Horse Power:{HorsePower}, Fuel type: {Fuel}";
        }

        public void DecreaseSpeed(int speed) {
            
            if(Speed - speed > CurrentEnvironment.MinSpeed) {
                Speed -= speed;
            } else {
                if(CurrentEnvironment.Type == IEnvironment.Types.Air) {
                    Speed = CurrentEnvironment.MinSpeed;
                    CurrentEnvironment = Environments.Land;
                    Speed = (int)(Speed * 3.6);
                } else {
                    Speed = 0;
                }
            }
        }

        public void IncreaseSpeed(int speed) {
            if(Speed + speed <= CurrentEnvironment.MaxSpeed) {
                Speed += speed;
            }
            if(CurrentEnvironment.Type == IEnvironment.Types.Land) {
                if(Speed / 3.6 > Environments.Air.MinSpeed) {
                    Speed = (int)(Speed / 3.6);
                    CurrentEnvironment = Environments.Air;
                }

            }
        }
    }
}

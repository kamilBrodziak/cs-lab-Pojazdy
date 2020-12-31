using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary {

    public interface IVehicle {
        public enum VehicleState { Moving, Standby }
        public VehicleState State => Speed > 0 ? VehicleState.Moving : VehicleState.Standby;
        public int Speed { get; }
        public int HorsePower { get;}
        public enum FuelType { Benzine, LPG, Diesel, Electricity }
        public FuelType Fuel { get; }
        public IEnvironment CurrentEnvironment { get; }
        public void IncreaseSpeed(int speed);
        public void DecreaseSpeed(int speed);
        public void Stop() {
            if(CurrentEnvironment.Type != IEnvironment.Types.Air) {
                DecreaseSpeed(Speed);
            }

        }

        public int ConvertUnitToKmh() {
            if(CurrentEnvironment.Type == IEnvironment.Types.Air) {
                return (int)(Speed * 3.6);
            } else if(CurrentEnvironment.Type == IEnvironment.Types.Sea) {
                return (int)(Speed * 1.852);
            }
            return Speed;
        }
        public void Start() {
            IncreaseSpeed(CurrentEnvironment.MinSpeed);
        }

    }
}

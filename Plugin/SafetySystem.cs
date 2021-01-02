using OpenBveApi.Runtime;
namespace Plugin {
    class SafetySystem {
        public int SpeedLimit = 70;
        public bool DoorBrake = true;
        public bool DoorOpened = true;
        public int PowerNotch = 3;
        public int BrakeNotch = 3;
        public int B67Notch = 2;
        public void update(ElapseData data) {
            if (SpeedLimit != -1 && data.Vehicle.Speed.KilometersPerHour > SpeedLimit) {
                data.Handles.PowerNotch = 0;
            }

            if (DoorOpened && DoorBrake) {
                data.Handles.PowerNotch = 0;
                data.Handles.BrakeNotch = 3;
            }
        }
    }
}

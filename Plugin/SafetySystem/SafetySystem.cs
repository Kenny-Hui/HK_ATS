using OpenBveApi.Runtime;
namespace Plugin {
    static class SafetySystem {
        public static int SpeedLimit { get; set; }

        public static bool DoorOpened { get; set; }

        public static int PowerNotch = 3;
        public static int BrakeNotch = 3;

        public static void update(ElapseData data) {
            if (SpeedLimit != -1 && data.Vehicle.Speed.KilometersPerHour > SpeedLimit) {
                data.Handles.PowerNotch = 0;
            }
        }
    }
}

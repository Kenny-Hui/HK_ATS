using OpenBveApi.Runtime;
namespace Plugin {
    static class SafetySystem {
        public static int SpeedLimit { get; set; }
        public static bool LimitSpeed { get; set; }
        public static bool DoorOpened { get; set; }

        public static void update(ElapseData data) {
            if (SpeedLimit != -1 && data.Vehicle.Speed.KilometersPerHour > SpeedLimit && LimitSpeed) {
                data.Handles.PowerNotch = 0;
            }
        }
    }
}

using OpenBveApi.Runtime;
namespace Plugin {
    static class SafetySystem {
        internal static int SpeedLimit { get; set; }
        internal static bool LimitSpeed { get; set; }
        internal static bool DoorOpened { get; set; }

        internal static void update(ElapseData data) {
            if (SpeedLimit != -1 && data.Vehicle.Speed.KilometersPerHour > SpeedLimit && LimitSpeed) {
                data.Handles.PowerNotch = 0;
            }
        }
    }
}

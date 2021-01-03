using OpenBveApi.Runtime;
namespace Plugin {
    static class SafetySystem {
        internal static int SpeedLimit { get; set; }
        internal static int LimitSpeed { get; set; }
        internal static bool DoorOpened { get; set; }
        internal static bool OverspeedApplyBrake = false;
        internal static int BrakeNotches { get; set; }

        internal static void update(ElapseData data) {
            if (SpeedLimit != -1 && data.Vehicle.Speed.KilometersPerHour > SpeedLimit) {
                if (LimitSpeed == 1) {
                    data.Handles.PowerNotch = 0;
                } else if (LimitSpeed == 2) {
                    OverspeedApplyBrake = true;
                }
            }

            if (OverspeedApplyBrake) {
                if (data.Vehicle.Speed.KilometersPerHour > 0) {
                    data.Handles.PowerNotch = 0;
                    data.Handles.BrakeNotch = BrakeNotches + 1;
                } else {
                    OverspeedApplyBrake = false;
                }
            }
        }
    }
}

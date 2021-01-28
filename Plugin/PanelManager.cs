using OpenBveApi.Runtime;

namespace Plugin {
    static class PanelManager {
        internal static int[] Keys = new int[38];
        internal static int[] Keysup = new int[38];
        internal static int Overspd { get; set; }
        internal static int OvrspdEMBrake { get; set; }
        internal static int SpeedLimit { get; set; }
        internal static int IdleTimer { get; set; }
        internal static int TravelMeter { get; set; }
        internal static int TravelMeter1 { get; set; }
        internal static int TravelMeter2 { get; set; }
        internal static int TravelMeter3 { get; set; }
        internal static int TravelMeter4 { get; set; }
        internal static int TravelMeter5 { get; set; }
        internal static int TravelMeter6 { get; set; }
        internal static int CameraViewMode { get; set; }
        internal static int Crash { get; set; }
        internal static int[] Beacon = new int[512];
        internal static int Pendingbeacon;

        internal static void update(ElapseData data, int[] Panel) {
            if (Pendingbeacon != 0) {
                Panel[Beacon[Pendingbeacon]] = 1;
            }

            if (TravelMeter != 0) {
                Panel[TravelMeter] = Misc.TravelMeter;
            }

            Panel[TravelMeter1] = Func.GetDigit(Misc.TravelMeter, 1);
            Panel[TravelMeter2] = Func.GetDigit(Misc.TravelMeter, 2);
            Panel[TravelMeter3] = Func.GetDigit(Misc.TravelMeter, 3);
            Panel[TravelMeter4] = Func.GetDigit(Misc.TravelMeter, 4);
            Panel[TravelMeter5] = Func.GetDigit(Misc.TravelMeter, 5);
            Panel[TravelMeter6] = Func.GetDigit(Misc.TravelMeter, 6);

            if (SafetySystem.SpeedLimit != 1 && data.Vehicle.Speed.KilometersPerHour > SafetySystem.SpeedLimit) {
                Panel[Overspd] = 1;
            } else {
                Panel[Overspd] = 0;
            }
            if (SafetySystem.OverspeedApplyBrake) {
                Panel[OvrspdEMBrake] = 1;
            } else {
                Panel[OvrspdEMBrake] = 0;
            }
            Panel[SpeedLimit] = (int) data.Vehicle.Speed.KilometersPerHour;

            if (DVS.DSDTimerTimeout != 0 && DVS.DSDTimer > DVS.DSDTimerTimeout) {
                Panel[IdleTimer] = 1;
            } else {
                Panel[IdleTimer] = 0;
            }

            if (CameraViewMode != 0) {
                Panel[CameraViewMode] = (int) data.CameraViewMode;
            }
        }

        internal static void OnBeacon (int beaconNum, int[] Panel){
            Pendingbeacon = beaconNum;
        }

        internal static void KeyDown(VirtualKeys key, int[] Panel) {
            if (Keys[Func.Key2ArrIndex(key)] != 0) {
                if (Keysup[Func.Key2ArrIndex(key)] == 1) {
                    Panel[Keys[Func.Key2ArrIndex(key)]] = 1;
                } else {
                    Panel[Keys[Func.Key2ArrIndex(key)]] ^= 1;
                }
            }

        }

        internal static void KeyUp(VirtualKeys key, int[] Panel) {
            if (Keysup[Func.Key2ArrIndex(key)] == 1) Panel[Keys[Func.Key2ArrIndex(key)]] = 0;
        }

    }
}

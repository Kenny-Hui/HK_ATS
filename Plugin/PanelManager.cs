using OpenBveApi.Runtime;

namespace Plugin {
    static class PanelManager {
        internal static int[] Keys = new int[38];
        internal static int Overspd { get; set; }
        internal static int OvrspdEMBrake { get; set; }
        internal static int SpeedLimit { get; set; }
        internal static int IdleTimer { get; set; }
        internal static int[] Beacon = new int[512];
        internal static int Pendingbeacon;

        internal static void update(ElapseData data, int[] Panel) {
            if (Pendingbeacon != 0) {
                Panel[Beacon[Pendingbeacon]] = 1;
            }

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

            if (DSD.DSDTimerTimeout != 0 && DSD.DSDTimer > DSD.DSDTimerTimeout) {
                Panel[IdleTimer] = 1;
            } else {
                Panel[IdleTimer] = 0;
            }
        }

        internal static void OnBeacon (int beaconNum, int[] Panel){
            Pendingbeacon = beaconNum;
        }

        internal static void KeyDown(VirtualKeys key, int[] Panel) {
            VirtualKeys virtualKey = key;
            switch (virtualKey) {
                case VirtualKeys.S:
                    Panel[Keys[10]] ^= 1;
                    break;
                case VirtualKeys.A1:
                    Panel[Keys[37]] ^= 1;
                    break;
                case VirtualKeys.A2:
                    Panel[Keys[36]] ^= 1;
                    break;
                case VirtualKeys.B1:
                    Panel[Keys[35]] ^= 1;
                    break;
                case VirtualKeys.B2:
                    Panel[Keys[34]] ^= 1;
                    break;
                case VirtualKeys.C1:
                    Panel[Keys[33]] ^= 1;
                    break;
                case VirtualKeys.C2:
                    Panel[Keys[32]] ^= 1;
                    break;
                case VirtualKeys.D:
                    Panel[Keys[2]] ^= 1;
                    break;
                case VirtualKeys.E:
                    Panel[Keys[3]] ^= 1;
                    break;
                case VirtualKeys.F:
                    Panel[Keys[4]] ^= 1;
                    break;
                case VirtualKeys.G:
                    Panel[Keys[5]] ^= 1;
                    break;
                case VirtualKeys.H:
                    Panel[Keys[6]] ^= 1;
                    break;
                case VirtualKeys.I:
                    Panel[Keys[7]] ^= 1;
                    break;
                case VirtualKeys.J:
                    Panel[Keys[8]] ^= 1;
                    break;
                case VirtualKeys.K:
                    Panel[Keys[9]] ^= 1;
                    break;
                case VirtualKeys.L:
                    Panel[Keys[0]] ^= 1;
                    break;
                default:
                    break;
            }
        }
    }
}

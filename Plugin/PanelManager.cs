using OpenBveApi.Runtime;

namespace Plugin {
    static class PanelManager {

        internal static int Key0 { get; set; }
        internal static int Key2 { get; set; }
        internal static int Key3 { get; set; }
        internal static int Key4 { get; set; }
        internal static int Key5 { get; set; }
        internal static int Key6 { get; set; }
        internal static int Key7 { get; set; }
        internal static int Key8 { get; set; }
        internal static int Key9 { get; set; }
        internal static int KeyDel { get; set; }
        internal static int KeyIns { get; set; }
        internal static int KeyHome { get; set; }
        internal static int KeyEnd { get; set; }
        internal static int KeyPgUp { get; set; }
        internal static int KeyPgDn { get; set; }
        internal static int KeySpace { get; set; }
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

        internal static void OnBeacon (int beaconNum){
            Pendingbeacon = beaconNum;
        }

        internal static void KeyDown(VirtualKeys key, int[] Panel) {
            VirtualKeys virtualKey = key;
            switch (virtualKey) {
                case VirtualKeys.S:
                    Panel[KeySpace] ^= 1;
                    break;
                case VirtualKeys.A1:
                    Panel[KeyIns] ^= 1;
                    break;
                case VirtualKeys.A2:
                    Panel[KeyDel] ^= 1;
                    break;
                case VirtualKeys.B1:
                    Panel[KeyHome] ^= 1;
                    break;
                case VirtualKeys.B2:
                    Panel[KeyEnd] ^= 1;
                    break;
                case VirtualKeys.C1:
                    Panel[KeyPgUp] ^= 1;
                    break;
                case VirtualKeys.C2:
                    Panel[KeyPgDn] ^= 1;
                    break;
                case VirtualKeys.D:
                    Panel[Key2] ^= 1;
                    break;
                case VirtualKeys.E:
                    Panel[Key3] ^= 1;
                    break;
                case VirtualKeys.F:
                    Panel[Key4] ^= 1;
                    break;
                case VirtualKeys.G:
                    Panel[Key5] ^= 1;
                    break;
                case VirtualKeys.H:
                    Panel[Key6] ^= 1;
                    break;
                case VirtualKeys.I:
                    Panel[Key7] ^= 1;
                    break;
                case VirtualKeys.J:
                    Panel[Key8] ^= 1;
                    break;
                case VirtualKeys.K:
                    Panel[Key9] ^= 1;
                    break;
                case VirtualKeys.L:
                    Panel[Key0] ^= 1;
                    break;
                default:
                    break;
            }
        }
    }
}

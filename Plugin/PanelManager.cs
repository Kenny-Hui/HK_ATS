using OpenBveApi.Runtime;

namespace Plugin {
    static class PanelManager {
        internal static int[] Keys = new int[38];
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

            if (DSD.DSDTimerTimeout != 0 && DSD.DSDTimer > DSD.DSDTimerTimeout) {
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
                case VirtualKeys.EngineStart:
                    Panel[Keys[31]] ^= 1;
                    break;
                case VirtualKeys.EngineStop:
                    Panel[Keys[30]] ^= 1;
                    break;
                case VirtualKeys.Blowers:
                    Panel[Keys[29]] ^= 1;
                    break;
                case VirtualKeys.ExhaustSteamInjector:
                    Panel[Keys[28]] ^= 1;
                    break;
                case VirtualKeys.IncreaseCutoff:
                    Panel[Keys[27]] ^= 1;
                    break;
                case VirtualKeys.DecreaseCutoff:
                    Panel[Keys[26]] ^= 1;
                    break;
                case VirtualKeys.FillFuel:
                    Panel[Keys[25]] ^= 1;
                    break;
                case VirtualKeys.GearDown:
                    Panel[Keys[24]] ^= 1;
                    break;
                case VirtualKeys.GearUp:
                    Panel[Keys[23]] ^= 1;
                    break;
                case VirtualKeys.LeftDoors:
                    Panel[Keys[22]] ^= 1;
                    break;
                case VirtualKeys.RightDoors:
                    Panel[Keys[21]] ^= 1;
                    break;
                case VirtualKeys.LiveSteamInjector:
                    Panel[Keys[20]] ^= 1;
                    break;
                case VirtualKeys.LowerPantograph:
                    Panel[Keys[19]] ^= 1;
                    break;
                case VirtualKeys.RaisePantograph:
                    Panel[Keys[18]] ^= 1;
                    break;
                case VirtualKeys.MainBreaker:
                    Panel[Keys[17]] ^= 1;
                    break;
                case VirtualKeys.WiperSpeedDown:
                    Panel[Keys[16]] ^= 1;
                    break;
                case VirtualKeys.WiperSpeedUp:
                    Panel[Keys[15]] ^= 1;
                    break;
                default:
                    break;
            }
        }
    }
}

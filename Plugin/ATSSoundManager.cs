using OpenBveApi.Runtime;

namespace Plugin {
    static class ATSSoundManager {
        internal static int[] Keys = new int[38];
        internal static int[] Beacon = new int[512];
        internal static int DSDTimerExceeded { get; set; }
        internal static int DSDTimerBrake { get; set; }
        internal static int Pendingbeacon;
        internal static void OnBeacon(int beaconSound) {
            Pendingbeacon = beaconSound;
            SoundManager.Play(Beacon[Pendingbeacon], 1.0, 1.0, false);
        }
            internal static void PlayOnce(VirtualKeys key) {
            VirtualKeys virtualKey = key;
            switch (virtualKey) {
                case VirtualKeys.S:
                    SoundManager.Play(Keys[10], 1.0, 1.0, false);
                    break;
                case VirtualKeys.A1:
                    SoundManager.Play(Keys[37], 1.0, 1.0, false);
                    break;
                case VirtualKeys.A2:
                    SoundManager.Play(Keys[36], 1.0, 1.0, false);
                    break;
                case VirtualKeys.B1:
                    SoundManager.Play(Keys[35], 1.0, 1.0, false);
                    break;
                case VirtualKeys.B2:
                    SoundManager.Play(Keys[34], 1.0, 1.0, false);
                    break;
                case VirtualKeys.C1:
                    SoundManager.Play(Keys[33], 1.0, 1.0, false);
                    break;
                case VirtualKeys.C2:
                    SoundManager.Play(Keys[32], 1.0, 1.0, false);
                    break;
                case VirtualKeys.D:
                    SoundManager.Play(Keys[2], 1.0, 1.0, false);
                    break;
                case VirtualKeys.E:
                    SoundManager.Play(Keys[3], 1.0, 1.0, false);
                    break;
                case VirtualKeys.F:
                    SoundManager.Play(Keys[4], 1.0, 1.0, false);
                    break;
                case VirtualKeys.G:
                    SoundManager.Play(Keys[5], 1.0, 1.0, false);
                    break;
                case VirtualKeys.H:
                    SoundManager.Play(Keys[6], 1.0, 1.0, false);
                    break;
                case VirtualKeys.I:
                    SoundManager.Play(Keys[7], 1.0, 1.0, false);
                    break;
                case VirtualKeys.J:
                    SoundManager.Play(Keys[8], 1.0, 1.0, false);
                    break;
                case VirtualKeys.K:
                    SoundManager.Play(Keys[9], 1.0, 1.0, false);
                    break;
                case VirtualKeys.L:
                    SoundManager.Play(Keys[0], 1.0, 1.0, false);
                    break;
                case VirtualKeys.EngineStart:
                    SoundManager.Play(Keys[31], 1.0, 1.0, false);
                    break;
                case VirtualKeys.EngineStop:
                    SoundManager.Play(Keys[30], 1.0, 1.0, false);
                    break;
                case VirtualKeys.Blowers:
                    SoundManager.Play(Keys[29], 1.0, 1.0, false);
                    break;
                case VirtualKeys.ExhaustSteamInjector:
                    SoundManager.Play(Keys[28], 1.0, 1.0, false);
                    break;
                case VirtualKeys.IncreaseCutoff:
                    SoundManager.Play(Keys[27], 1.0, 1.0, false);
                    break;
                case VirtualKeys.DecreaseCutoff:
                    SoundManager.Play(Keys[26], 1.0, 1.0, false);
                    break;
                case VirtualKeys.FillFuel:
                    SoundManager.Play(Keys[25], 1.0, 1.0, false);
                    break;
                case VirtualKeys.GearDown:
                    SoundManager.Play(Keys[24], 1.0, 1.0, false);
                    break;
                case VirtualKeys.GearUp:
                    SoundManager.Play(Keys[23], 1.0, 1.0, false);
                    break;
                case VirtualKeys.LeftDoors:
                    SoundManager.Play(Keys[22], 1.0, 1.0, false);
                    break;
                case VirtualKeys.RightDoors:
                    SoundManager.Play(Keys[21], 1.0, 1.0, false);
                    break;
                case VirtualKeys.LiveSteamInjector:
                    SoundManager.Play(Keys[20], 1.0, 1.0, false);
                    break;
                case VirtualKeys.LowerPantograph:
                    SoundManager.Play(Keys[19], 1.0, 1.0, false);
                    break;
                case VirtualKeys.RaisePantograph:
                    SoundManager.Play(Keys[18], 1.0, 1.0, false);
                    break;
                case VirtualKeys.MainBreaker:
                    SoundManager.Play(Keys[17], 1.0, 1.0, false);
                    break;
                case VirtualKeys.WiperSpeedDown:
                    SoundManager.Play(Keys[16], 1.0, 1.0, false);
                    break;
                case VirtualKeys.WiperSpeedUp:
                    SoundManager.Play(Keys[15], 1.0, 1.0, false);
                    break;
                default:
                    break;
            }
        }
    }
}

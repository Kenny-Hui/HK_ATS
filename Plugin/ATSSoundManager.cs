using OpenBveApi.Runtime;

namespace Plugin {
    static class ATSSoundManager {
        internal static int[] Keys = new int[38];
        internal static int[] Keysloop = new int[38];
        internal static int[] Beacon = new int[512];
        internal static int DSDTimerExceeded { get; set; }
        internal static int DSDTimerBrake { get; set; }
        internal static int Pendingbeacon;
        internal static int Crash { get; set; }
        internal static void OnBeacon(int beaconSound) {
            Pendingbeacon = beaconSound;
            SoundManager.Play(Beacon[Pendingbeacon], 1.0, 1.0, false);
        }
        internal static void PlayOnce(VirtualKeys key) {
            SoundManager.Play(Keys[Func.Key2ArrIndex(key)], 1.0, 1.0, false);
        }
        internal static void PlayLoop(VirtualKeys key) {
            VirtualKeys virtualKey = key;
            switch (virtualKey) {
                case VirtualKeys.S:
                    if (SoundManager.IsPlaying(Keysloop[10])) SoundManager.Stop(Keysloop[10]);
                    else SoundManager.Play(Keysloop[10], 1.0, 1.0, true);
                    break;
                case VirtualKeys.A1:
                    if (SoundManager.IsPlaying(Keysloop[37])) SoundManager.Stop(Keysloop[37]);
                    else SoundManager.Play(Keysloop[37], 1.0, 1.0, true);
                    break;
                case VirtualKeys.A2:
                    if (SoundManager.IsPlaying(Keysloop[36])) SoundManager.Stop(Keysloop[36]);
                    else SoundManager.Play(Keysloop[36], 1.0, 1.0, true);
                    break;
                case VirtualKeys.B1:
                    if (SoundManager.IsPlaying(Keysloop[35])) SoundManager.Stop(Keysloop[35]);
                    else SoundManager.Play(Keysloop[35], 1.0, 1.0, true);
                    break;
                case VirtualKeys.B2:
                    if (SoundManager.IsPlaying(Keysloop[34])) SoundManager.Stop(Keysloop[34]);
                    else SoundManager.Play(Keysloop[34], 1.0, 1.0, true);
                    break;
                case VirtualKeys.C1:
                    if (SoundManager.IsPlaying(Keysloop[33])) SoundManager.Stop(Keysloop[33]);
                    else SoundManager.Play(Keysloop[33], 1.0, 1.0, true);
                    break;
                case VirtualKeys.C2:
                    if (SoundManager.IsPlaying(Keysloop[32])) SoundManager.Stop(Keysloop[32]);
                    else SoundManager.Play(Keysloop[32], 1.0, 1.0, true);
                    break;
                case VirtualKeys.D:
                    if (SoundManager.IsPlaying(Keysloop[2])) SoundManager.Stop(Keysloop[2]);
                    else SoundManager.Play(Keysloop[2], 1.0, 1.0, true);
                    break;
                case VirtualKeys.E:
                    if (SoundManager.IsPlaying(Keysloop[3])) SoundManager.Stop(Keysloop[3]);
                    else SoundManager.Play(Keysloop[3], 1.0, 1.0, true);
                    break;
                case VirtualKeys.F:
                    if (SoundManager.IsPlaying(Keysloop[4])) SoundManager.Stop(Keysloop[4]);
                    else SoundManager.Play(Keysloop[4], 1.0, 1.0, true);
                    break;
                case VirtualKeys.G:
                    if (SoundManager.IsPlaying(Keysloop[5])) SoundManager.Stop(Keysloop[5]);
                    else SoundManager.Play(Keysloop[5], 1.0, 1.0, true);
                    break;
                case VirtualKeys.H:
                    if (SoundManager.IsPlaying(Keysloop[6])) SoundManager.Stop(Keysloop[6]);
                    else SoundManager.Play(Keysloop[6], 1.0, 1.0, true);
                    break;
                case VirtualKeys.I:
                    if (SoundManager.IsPlaying(Keysloop[7])) SoundManager.Stop(Keysloop[7]);
                    else SoundManager.Play(Keysloop[7], 1.0, 1.0, true);
                    break;
                case VirtualKeys.J:
                    if (SoundManager.IsPlaying(Keysloop[8])) SoundManager.Stop(Keysloop[8]);
                    else SoundManager.Play(Keysloop[8], 1.0, 1.0, true);
                    break;
                case VirtualKeys.K:
                    if (SoundManager.IsPlaying(Keysloop[9])) SoundManager.Stop(Keysloop[9]);
                    else SoundManager.Play(Keysloop[9], 1.0, 1.0, true);
                    break;
                case VirtualKeys.L:
                    if (SoundManager.IsPlaying(Keysloop[0])) SoundManager.Stop(Keysloop[0]);
                    else SoundManager.Play(Keysloop[0], 1.0, 1.0, true);
                    break;
                case VirtualKeys.EngineStart:
                    if (SoundManager.IsPlaying(Keysloop[31])) SoundManager.Stop(Keysloop[31]);
                    else SoundManager.Play(Keysloop[31], 1.0, 1.0, true);
                    break;
                case VirtualKeys.EngineStop:
                    if (SoundManager.IsPlaying(Keysloop[30])) SoundManager.Stop(Keysloop[30]);
                    else SoundManager.Play(Keysloop[30], 1.0, 1.0, true);
                    break;
                case VirtualKeys.Blowers:
                    if (SoundManager.IsPlaying(Keysloop[29])) SoundManager.Stop(Keysloop[29]);
                    else SoundManager.Play(Keysloop[29], 1.0, 1.0, true);
                    break;
                case VirtualKeys.ExhaustSteamInjector:
                    if (SoundManager.IsPlaying(Keysloop[28])) SoundManager.Stop(Keysloop[28]);
                    else SoundManager.Play(Keysloop[28], 1.0, 1.0, true);
                    break;
                case VirtualKeys.IncreaseCutoff:
                    if (SoundManager.IsPlaying(Keysloop[27])) SoundManager.Stop(Keysloop[27]);
                    else SoundManager.Play(Keysloop[27], 1.0, 1.0, true);
                    break;
                case VirtualKeys.DecreaseCutoff:
                    if (SoundManager.IsPlaying(Keysloop[26])) SoundManager.Stop(Keysloop[26]);
                    else SoundManager.Play(Keysloop[26], 1.0, 1.0, true);
                    break;
                case VirtualKeys.FillFuel:
                    if (SoundManager.IsPlaying(Keysloop[25])) SoundManager.Stop(Keysloop[25]);
                    else SoundManager.Play(Keysloop[25], 1.0, 1.0, true);
                    break;
                case VirtualKeys.GearDown:
                    if (SoundManager.IsPlaying(Keysloop[24])) SoundManager.Stop(Keysloop[24]);
                    else SoundManager.Play(Keysloop[24], 1.0, 1.0, true);
                    break;
                case VirtualKeys.GearUp:
                    if (SoundManager.IsPlaying(Keysloop[23])) SoundManager.Stop(Keysloop[23]);
                    else SoundManager.Play(Keysloop[23], 1.0, 1.0, true);
                    break;
                case VirtualKeys.LeftDoors:
                    if (SoundManager.IsPlaying(Keysloop[22])) SoundManager.Stop(Keysloop[22]);
                    else SoundManager.Play(Keysloop[22], 1.0, 1.0, true);
                    break;
                case VirtualKeys.RightDoors:
                    if (SoundManager.IsPlaying(Keysloop[21])) SoundManager.Stop(Keysloop[21]);
                    else SoundManager.Play(Keysloop[21], 1.0, 1.0, true);
                    break;
                case VirtualKeys.LiveSteamInjector:
                    if (SoundManager.IsPlaying(Keysloop[20])) SoundManager.Stop(Keysloop[20]);
                    else SoundManager.Play(Keysloop[20], 1.0, 1.0, true);
                    break;
                case VirtualKeys.LowerPantograph:
                    if (SoundManager.IsPlaying(Keysloop[19])) SoundManager.Stop(Keysloop[19]);
                    else SoundManager.Play(Keysloop[19], 1.0, 1.0, true);
                    break;
                case VirtualKeys.RaisePantograph:
                    if (SoundManager.IsPlaying(Keysloop[18])) SoundManager.Stop(Keysloop[18]);
                    else SoundManager.Play(Keysloop[18], 1.0, 1.0, true);
                    break;
                case VirtualKeys.MainBreaker:
                    if (SoundManager.IsPlaying(Keysloop[17])) SoundManager.Stop(Keysloop[17]);
                    else SoundManager.Play(Keysloop[17], 1.0, 1.0, true);
                    break;
                case VirtualKeys.WiperSpeedDown:
                    if (SoundManager.IsPlaying(Keysloop[16])) SoundManager.Stop(Keysloop[20]);
                    else SoundManager.Play(Keysloop[16], 1.0, 1.0, true);
                    break;
                case VirtualKeys.WiperSpeedUp:
                    if (SoundManager.IsPlaying(Keysloop[15])) SoundManager.Stop(Keysloop[20]);
                    else SoundManager.Play(Keysloop[15], 1.0, 1.0, true);
                    break;
                default:
                    break;
            }
        }
    }
}

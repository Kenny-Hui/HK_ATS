using OpenBveApi.Runtime;

namespace Plugin {
    static class ATSSoundManager {
        internal static int Key0 { get; set; }
        internal static int Key2 { get; set; }
        internal static int Key3 { get; set; }
        internal static int Key4 { get; set; }
        internal static int Key5 { get; set; }
        internal static int Key6 { get; set; }
        internal static int Key7 { get; set; }
        internal static int Key8 { get; set; }
        internal static int Key9 { get; set; }
        internal static int KeyIns { get; set; }
        internal static int KeyDel { get; set; }
        internal static int KeyHome { get; set; }
        internal static int KeyEnd { get; set; }
        internal static int KeyPgUp { get; set; }
        internal static int KeyPgDn { get; set; }
        internal static int KeySpace { get; set; }
        internal static int DSDTimerExceeded { get; set; }
        internal static int DSDTimerBrake { get; set; }

        internal static void PlayOnce(VirtualKeys key) {
            VirtualKeys virtualKey = key;
            switch (virtualKey) {
                case VirtualKeys.S:
                    SoundManager.Play(KeySpace, 1.0, 1.0, false);
                    break;
                case VirtualKeys.A1:
                    SoundManager.Play(KeyIns, 1.0, 1.0, false);
                    break;
                case VirtualKeys.A2:
                    SoundManager.Play(KeyDel, 1.0, 1.0, false);
                    break;
                case VirtualKeys.B1:
                    SoundManager.Play(KeyHome, 1.0, 1.0, false);
                    break;
                case VirtualKeys.B2:
                    SoundManager.Play(KeyEnd, 1.0, 1.0, false);
                    break;
                case VirtualKeys.C1:
                    SoundManager.Play(KeyPgUp, 1.0, 1.0, false);
                    break;
                case VirtualKeys.C2:
                    SoundManager.Play(KeyPgDn, 1.0, 1.0, false);
                    break;
                case VirtualKeys.D:
                    SoundManager.Play(Key2, 1.0, 1.0, false);
                    break;
                case VirtualKeys.E:
                    SoundManager.Play(Key3, 1.0, 1.0, false);
                    break;
                case VirtualKeys.F:
                    SoundManager.Play(Key4, 1.0, 1.0, false);
                    break;
                case VirtualKeys.G:
                    SoundManager.Play(Key5, 1.0, 1.0, false);
                    break;
                case VirtualKeys.H:
                    SoundManager.Play(Key6, 1.0, 1.0, false);
                    break;
                case VirtualKeys.I:
                    SoundManager.Play(Key7, 1.0, 1.0, false);
                    break;
                case VirtualKeys.J:
                    SoundManager.Play(Key8, 1.0, 1.0, false);
                    break;
                case VirtualKeys.K:
                    SoundManager.Play(Key9, 1.0, 1.0, false);
                    break;
                case VirtualKeys.L:
                    SoundManager.Play(Key0, 1.0, 1.0, false);
                    break;
                default:
                    break;
            }
        }
    }
}

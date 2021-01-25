using OpenBveApi.Runtime;

namespace Plugin {
    internal static class Func {
        internal static int GetDigit(int number, int digit) {
            return (number / (int)System.Math.Pow(10, digit - 1)) % 10;
        }

        internal static int KeyStr2ArrIndex(string keyname) {
            switch (keyname) {
                case "key2":
                    return 2;
                case "key3":
                    return 3;
                case "key4":
                    return 4;
                case "key5":
                    return 5;
                case "key6":
                    return 6;
                case "key7":
                    return 7;
                case "key8":
                    return 8;
                case "key9":
                    return 9;
                case "key0":
                    return 0;
                case "keyspace":
                    return 10;
                case "keywiperup":
                    return 15;
                case "keywiperdown":
                    return 16;
                case "keymainbreaker":
                    return 17;
                case "keyraisepan":
                    return 18;
                case "keylowerpan":
                    return 19;
                case "keylivesteaminjector":
                    return 20;
                case "keyrightdoor":
                    return 21;
                case "keyleftdoor":
                    return 22;
                case "keygearup":
                    return 23;
                case "keygeardown":
                    return 24;
                case "keyfillfuel":
                    return 25;
                case "keydecreasecutoff":
                    return 26;
                case "keyincreasecutoff":
                    return 27;
                case "keysteaminjector":
                    return 28;
                case "keyblowers":
                    return 29;
                case "keyenginestop":
                    return 30;
                case "keyenginestart":
                    return 31;
                case "keypgup":
                    return 32;
                case "keypgdn":
                    return 33;
                case "keyend":
                    return 34;
                case "keyhome":
                    return 35;
                case "keydel":
                    return 36;
                case "keyins":
                    return 37;
                default:
                    return 1;
            }
        }

        internal static int Key2ArrIndex(VirtualKeys key) {
            switch (key) {
                case VirtualKeys.D:
                    return 2;
                case VirtualKeys.E:
                    return 3;
                case VirtualKeys.F:
                    return 4;
                case VirtualKeys.G:
                    return 5;
                case VirtualKeys.H:
                    return 6;
                case VirtualKeys.I:
                    return 7;
                case VirtualKeys.J:
                    return 8;
                case VirtualKeys.K:
                    return 9;
                case VirtualKeys.L:
                    return 0;
                case VirtualKeys.S:
                    return 10;
                case VirtualKeys.WiperSpeedUp:
                    return 15;
                case VirtualKeys.WiperSpeedDown:
                    return 16;
                case VirtualKeys.MainBreaker:
                    return 17;
                case VirtualKeys.RaisePantograph:
                    return 18;
                case VirtualKeys.LowerPantograph:
                    return 19;
                case VirtualKeys.LiveSteamInjector:
                    return 20;
                case VirtualKeys.RightDoors:
                    return 21;
                case VirtualKeys.LeftDoors:
                    return 22;
                case VirtualKeys.GearUp:
                    return 23;
                case VirtualKeys.GearDown:
                    return 24;
                case VirtualKeys.FillFuel:
                    return 25;
                case VirtualKeys.DecreaseCutoff:
                    return 26;
                case VirtualKeys.IncreaseCutoff:
                    return 27;
                case VirtualKeys.ExhaustSteamInjector:
                    return 28;
                case VirtualKeys.Blowers:
                    return 29;
                case VirtualKeys.EngineStop:
                    return 30;
                case VirtualKeys.EngineStart:
                    return 31;
                case VirtualKeys.C1:
                    return 32;
                case VirtualKeys.C2:
                    return 33;
                case VirtualKeys.B2:
                    return 34;
                case VirtualKeys.B1:
                    return 35;
                case VirtualKeys.A2:
                    return 36;
                case VirtualKeys.A1:
                    return 37;
                default:
                    return 1;
            }
        }

        internal static object String2VKey(string keyname) {
            switch (keyname) {
                case "key2":
                    return VirtualKeys.D;
                case "key3":
                    return VirtualKeys.E;
                case "key4":
                    return VirtualKeys.F;
                case "key5":
                    return VirtualKeys.G;
                case "key6":
                    return VirtualKeys.H;
                case "key7":
                    return VirtualKeys.I;
                case "key8":
                    return VirtualKeys.J;
                case "key9":
                    return VirtualKeys.K;
                case "key0":
                    return VirtualKeys.L;
                case "keyspace":
                    return VirtualKeys.S;
                case "keywiperup":
                    return VirtualKeys.WiperSpeedUp;
                case "keywiperdown":
                    return VirtualKeys.WiperSpeedDown;
                case "keymainbreaker":
                    return VirtualKeys.MainBreaker;
                case "keyraisepan":
                    return VirtualKeys.RaisePantograph;
                case "keylowerpan":
                    return VirtualKeys.LowerPantograph;
                case "keylivesteaminjector":
                    return VirtualKeys.LowerPantograph;
                case "keyrightdoor":
                    return VirtualKeys.RightDoors;
                case "keyleftdoor":
                    return VirtualKeys.LeftDoors;
                case "keygearup":
                    return VirtualKeys.GearUp;
                case "keygeardown":
                    return VirtualKeys.GearDown;
                case "keyfillfuel":
                    return VirtualKeys.FillFuel;
                case "keydecreasecutoff":
                    return VirtualKeys.DecreaseCutoff;
                case "keyincreasecutoff":
                    return VirtualKeys.IncreaseCutoff;
                case "keysteaminjector":
                    return VirtualKeys.ExhaustSteamInjector;
                case "keyblowers":
                    return VirtualKeys.Blowers;
                case "keyenginestop":
                    return VirtualKeys.EngineStop;
                case "keyenginestart":
                    return VirtualKeys.EngineStart;
                case "keypgup":
                    return VirtualKeys.C1;
                case "keypgdn":
                    return VirtualKeys.C2;
                case "keyend":
                    return VirtualKeys.B2;
                case "keyhome":
                    return VirtualKeys.B1;
                case "keydel":
                    return VirtualKeys.A2;
                case "keyins":
                    return VirtualKeys.A1;
                default:
                    return null;
            }
        }
    }
}

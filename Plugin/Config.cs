using System;
using OpenBveApi.Runtime;

namespace Plugin {
    internal static class Config {
        static string currentSection;
        internal static void Load(LoadProperties prop) {
            string cfgfile = System.IO.Path.Combine(prop.PluginFolder, "hkconfig.cfg");
            string[] lines = System.IO.File.ReadAllLines(cfgfile);
            foreach (string line in lines) {
                if (!line.StartsWith(";")) { /* Semicolon is our comment identifier, ignore the line if it starts with semicolon */
                    if (line.StartsWith("[")) {
                        currentSection = line.Trim().Substring(1, line.Length - 2).ToLowerInvariant();
                    } else {
                        string[] cfg = line.Split('=');
                        if (!(cfg.Length < 2)) {
                            string key = cfg[0].Trim();
                            string valstr = cfg[1].Trim();
                            int val;
                            switch (currentSection) {
                                case "indicator":
                                    switch (key) {
                                        case "key2":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.Key2 = val;
                                            }
                                            break;
                                        case "key3":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.Key3 = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "key4":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.Key4 = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "key5":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.Key5 = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "key6":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.Key6 = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "key7":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.Key7 = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "key8":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.Key8 = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "key9":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.Key9 = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "key0":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.Key0 = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "keypgup":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.KeyPgUp = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "keypgdn":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.KeyPgDn = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "keyend":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.KeyEnd = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "keyhome":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.KeyHome = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "keydel":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.KeyDel = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "keyins":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.KeyIns = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "keyspace":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.KeyIns = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "overspeed":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.Overspd = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "speedlimit":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.SpeedLimit = Convert.ToInt32(val);
                                            }
                                            break;
                                        case "idletimerexceed":
                                            if (int.TryParse(valstr, out val)) {
                                                PanelManager.IdleTimer = Convert.ToInt32(val);
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "system":
                                    switch (key) {
                                        case "speedlimit":
                                            if (int.TryParse(valstr, out val)) {
                                                SafetySystem.SpeedLimit = val;
                                            }
                                            break;
                                        case "limitspeed":
                                            if (int.TryParse(valstr, out val)) {
                                                SafetySystem.LimitSpeed = val;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "interlock":
                                    switch (key) {
                                        case "door":
                                            if (int.TryParse(valstr, out val)) {
                                                if (val == 1) {
                                                    Interlocker.DoorInterlocked = true;
                                                } else {
                                                    Interlocker.DoorInterlocked = false;
                                                }
                                            }
                                            break;
                                        case "doorpowerlock":
                                            if (int.TryParse(valstr, out val)) {
                                                if (val == 1) {
                                                    Interlocker.DoorBrake = true;
                                                } else {
                                                    Interlocker.DoorBrake = false;
                                                }
                                            }
                                            break;
                                        case "station":
                                            if (int.TryParse(valstr, out val)) {
                                                if (val == 1) {
                                                    Interlocker.StationInterlock = true;
                                                } else {
                                                    Interlocker.StationInterlock = false;
                                                }
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "dsdtimer":
                                    switch (key) {
                                        case "resettimerkey":
                                            switch (valstr) {
                                                case "keyspace":
                                                    DSD.rsettimerkey = VirtualKeys.S;
                                                    break;
                                                case "keyins":
                                                    DSD.rsettimerkey = VirtualKeys.A1;
                                                    break;
                                                case "keydel":
                                                    DSD.rsettimerkey = VirtualKeys.A2;
                                                    break;
                                                case "keyhome":
                                                    DSD.rsettimerkey = VirtualKeys.B1;
                                                    break;
                                                case "keyend":
                                                    DSD.rsettimerkey = VirtualKeys.B2;
                                                    break;
                                                case "keypgup":
                                                    DSD.rsettimerkey = VirtualKeys.C1;
                                                    break;
                                                case "keypgdn":
                                                    DSD.rsettimerkey = VirtualKeys.C2;
                                                    break;
                                                case "key2":
                                                    DSD.rsettimerkey = VirtualKeys.D;
                                                    break;
                                                case "key3":
                                                    DSD.rsettimerkey = VirtualKeys.E;
                                                    break;
                                                case "key4":
                                                    DSD.rsettimerkey = VirtualKeys.F;
                                                    break;
                                                case "key5":
                                                    DSD.rsettimerkey = VirtualKeys.G;
                                                    break;
                                                case "key6":
                                                    DSD.rsettimerkey = VirtualKeys.H;
                                                    break;
                                                case "key7":
                                                    DSD.rsettimerkey = VirtualKeys.I;
                                                    break;
                                                case "key8":
                                                    DSD.rsettimerkey = VirtualKeys.J;
                                                    break;
                                                case "key9":
                                                    DSD.rsettimerkey = VirtualKeys.K;
                                                    break;
                                                case "key0":
                                                    DSD.rsettimerkey = VirtualKeys.L;
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        case "dsdtimerlimit":
                                            if (int.TryParse(valstr, out val)) {
                                                DSD.DSDTimerTimeout = val;
                                            }
                                            break;
                                        case "dsdtimerbrake":
                                            if (int.TryParse(valstr, out val)) {
                                                DSD.DSDTimerBrakeTimeout = DSD.DSDTimerTimeout + val;
                                            }
                                            break;
                                        case "disableontrainstop":
                                            if (int.TryParse(valstr, out val)) {
                                                if (val == 1) {
                                                    DSD.DSDDisableOnTrainStop = true;
                                                }
                                            }
                                            break;
                                        case "resetondoormove":
                                            if (int.TryParse(valstr, out val)) {
                                                if (val == 1) {
                                                    DSD.ResetOnDoorMove = true;
                                                }
                                            }
                                            break;
                                        case "resetonnotchmove":
                                            if (int.TryParse(valstr, out val)) {
                                                if (val == 1) {
                                                    DSD.ResetOnNotchMove = true;
                                                }
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case "sound":
                                    switch (key) {
                                        case "key0":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.Key0 = val;
                                            }
                                            break;
                                        case "key2":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.Key2 = val;
                                            }
                                            break;
                                        case "key3":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.Key3 = val;
                                            }
                                            break;
                                        case "key4":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.Key4 = val;
                                            }
                                            break;
                                        case "key5":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.Key5 = val;
                                            }
                                            break;
                                        case "key6":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.Key6 = val;
                                            }
                                            break;
                                        case "key7":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.Key7 = val;
                                            }
                                            break;
                                        case "key8":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.Key8 = val;
                                            }
                                            break;
                                        case "key9":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.Key9 = val;
                                            }
                                            break;
                                        case "keyins":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.KeyIns = val;
                                            }
                                            break;
                                        case "keydel":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.KeyDel = val;
                                            }
                                            break;
                                        case "keyhome":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.KeyHome = val;
                                            }
                                            break;
                                        case "keyend":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.KeyEnd = val;
                                            }
                                            break;
                                        case "keypgup":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.KeyPgUp = val;
                                            }
                                            break;
                                        case "keypgdn":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.KeyPgDn = val;
                                            }
                                            break;
                                        case "dsdtimerexceeded":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.DSDTimerExceeded = val;
                                            }
                                            break;
                                        case "dsdtimerbrake":
                                            if (int.TryParse(valstr, out val)) {
                                                ATSSoundManager.DSDTimerBrake = val;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}

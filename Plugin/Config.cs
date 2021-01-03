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
                            case "atskey":
                                switch (key) {
                                    case "key2":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.Key2 = val;
                                        }
                                        break;
                                    case "key3":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.Key3 = Convert.ToInt32(val);
                                        }
                                        break;
                                    case "key4":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.Key4 = Convert.ToInt32(val);
                                        }
                                        break;
                                    case "key5":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.Key5 = Convert.ToInt32(val);
                                        }
                                        break;
                                    case "key6":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.Key6 = Convert.ToInt32(val);
                                        }
                                        break;
                                    case "key7":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.Key7 = Convert.ToInt32(val);
                                        }
                                        break;
                                    case "key8":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.Key8 = Convert.ToInt32(val);
                                        }
                                        break;
                                    case "key9":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.Key9 = Convert.ToInt32(val);
                                        }
                                        break;
                                    case "key0":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.Key0 = Convert.ToInt32(val);
                                        }
                                        break;
                                    case "keypgup":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.KeyPgUp = Convert.ToInt32(val);
                                        }
                                        break;
                                    case "keypgdn":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.KeyPgDn = Convert.ToInt32(val);
                                        }
                                        break;
                                    case "keyend":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.KeyEnd = Convert.ToInt32(val);
                                        }
                                        break;
                                    case "keyhome":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.KeyHome = Convert.ToInt32(val);
                                        }
                                        break;
                                    case "keydel":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.KeyDel = Convert.ToInt32(val);
                                        }
                                        break;
                                    case "keyins":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.KeyIns = Convert.ToInt32(val);
                                        }
                                        break;
                                    case "keyspace":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.KeyIns = Convert.ToInt32(val);
                                        }
                                        break;
                                    case "overspeed":
                                        if (int.TryParse(valstr, out val)) {
                                            panel.Overspd = Convert.ToInt32(val);
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

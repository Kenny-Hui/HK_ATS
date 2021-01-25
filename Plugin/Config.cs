using System;
using System.IO;
using OpenBveApi.Runtime;

namespace Plugin {
    internal static class Config {
        internal static string currentSection;
        internal static int[] Keys = new int[38];
        internal static void Load(LoadProperties prop) {
            string cfgfile = Path.Combine(prop.PluginFolder, "hkats.ini");
            if (File.Exists(cfgfile)) {
                string[] lines = File.ReadAllLines(cfgfile);
                foreach (string line in lines) {
                    if (!line.StartsWith(";")) { /* Semicolon is our comment identifier, ignore the line if it starts with semicolon */
                        if (line.StartsWith("[")) { /* Square bracket is our section identifier, set the currentSection to the section name without the bracket */
                            currentSection = line.Trim().Substring(1, line.Length - 2).ToLowerInvariant();
                        } else {
                            string[] cfg = line.Split('=');
                            if (!(cfg.Length < 2)) {
                                string key = cfg[0].Trim().ToLowerInvariant();
                                string valstr = cfg[1].Trim().ToLowerInvariant();
                                int val;
                                string[] seperated = valstr.Split(',');
                                switch (currentSection) {
                                    case "keydown":
                                        if (int.TryParse(seperated[0], out val)) PanelManager.Keys[Func.Keys(key)] = val;
                                        if (seperated.Length > 1) if (int.TryParse(seperated[1], out val)) ATSSoundManager.Keys[Func.Keys(key)] = val;
                                        break;
                                    case "system":
                                        switch (key) {
                                            case "overspeedPanel":
                                                if (int.TryParse(valstr, out val)) {
                                                    PanelManager.Overspd = val;
                                                }
                                                break;
                                            case "speedlimitPanel":
                                                if (int.TryParse(valstr, out val)) {
                                                    PanelManager.SpeedLimit = val;
                                                }
                                                break;
                                            case "idletimerexceedPanel":
                                                if (int.TryParse(valstr, out val)) {
                                                    PanelManager.IdleTimer = val;
                                                }
                                                break;
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
                                            case "doorapplybrake":
                                                if (int.TryParse(valstr, out val)) {
                                                    if (val == 1) {
                                                        Interlocker.DoorBrake = true;
                                                    } else {
                                                        Interlocker.DoorBrake = false;
                                                    }
                                                }
                                                break;
                                            case "doorpowerlock":
                                                if (int.TryParse(valstr, out val)) {
                                                    if (val == 1) {
                                                        Interlocker.DoorPowerLock = true;
                                                    } else {
                                                        Interlocker.DoorPowerLock = false;
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
                                                    case "keywiperup":
                                                        DSD.rsettimerkey = VirtualKeys.WiperSpeedUp;
                                                        break;
                                                    case "keywiperdown":
                                                        DSD.rsettimerkey = VirtualKeys.WiperSpeedDown;
                                                        break;
                                                    case "keymainbreaker":
                                                        DSD.rsettimerkey = VirtualKeys.MainBreaker;
                                                        break;
                                                    case "raisepan":
                                                        DSD.rsettimerkey = VirtualKeys.RaisePantograph;
                                                        break;
                                                    case "lowerpan":
                                                        DSD.rsettimerkey = VirtualKeys.LowerPantograph;
                                                        break;
                                                    case "keylivesteaminjector":
                                                        DSD.rsettimerkey = VirtualKeys.LiveSteamInjector;
                                                        break;
                                                    case "keyrightdoor":
                                                        DSD.rsettimerkey = VirtualKeys.RightDoors;
                                                        break;
                                                    case "keyleftdoor":
                                                        DSD.rsettimerkey = VirtualKeys.LeftDoors;
                                                        break;
                                                    case "keygearup":
                                                        DSD.rsettimerkey = VirtualKeys.GearUp;
                                                        break;
                                                    case "keygeardown":
                                                        DSD.rsettimerkey = VirtualKeys.GearDown;
                                                        break;
                                                    case "keyfillfuel":
                                                        DSD.rsettimerkey = VirtualKeys.FillFuel;
                                                        break;
                                                    case "keydecreasecutoff":
                                                        DSD.rsettimerkey = VirtualKeys.DecreaseCutoff;
                                                        break;
                                                    case "keyincreasecutoff":
                                                        DSD.rsettimerkey = VirtualKeys.IncreaseCutoff;
                                                        break;
                                                    case "keysteaminjector":
                                                        DSD.rsettimerkey = VirtualKeys.ExhaustSteamInjector;
                                                        break;
                                                    case "keyblowers":
                                                        DSD.rsettimerkey = VirtualKeys.Blowers;
                                                        break;
                                                    case "keyenginestop":
                                                        DSD.rsettimerkey = VirtualKeys.EngineStop;
                                                        break;
                                                    case "keyenginestart":
                                                        DSD.rsettimerkey = VirtualKeys.EngineStart;
                                                        break;
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
                                    case "beacon":
                                        if (key.StartsWith("beacon")) {
                                            if (int.TryParse(seperated[0], out val))
                                                if (int.TryParse(key.Substring(6), out int beaconNum)) BeaconManager.RegisterPanelBeacon(beaconNum, val);
                                            if (seperated.Length > 1)
                                                if (int.TryParse(key.Substring(6), out int beaconSound))
                                                    if (int.TryParse(seperated[1], out int bSoundIndex))
                                                        BeaconManager.RegisterSoundBeacon(beaconSound, bSoundIndex);
                                        }
                                        switch (key) {
                                            case "speedlimit":
                                                if (int.TryParse(valstr, out val)) {
                                                    BeaconManager.SpeedLimit = val;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    case "misc":
                                        switch (key) {
                                            case "travelmeterpanel":
                                                if (seperated.Length > 1) {
                                                    switch (seperated[0]) {
                                                        case "1":
                                                            if (int.TryParse(seperated[1], out val))
                                                                PanelManager.TravelMeter1 = val;
                                                            break;
                                                        case "2":
                                                            if (int.TryParse(seperated[1], out val))
                                                                PanelManager.TravelMeter2 = val;
                                                            break;
                                                        case "3":
                                                            if (int.TryParse(seperated[1], out val))
                                                                PanelManager.TravelMeter3 = val;
                                                            break;
                                                        case "4":
                                                            if (int.TryParse(seperated[1], out val))
                                                                PanelManager.TravelMeter4 = val;
                                                            break;
                                                        case "5":
                                                            if (int.TryParse(seperated[1], out val))
                                                                PanelManager.TravelMeter5 = val;
                                                            break;
                                                        case "6":
                                                            if (int.TryParse(seperated[1], out val))
                                                                PanelManager.TravelMeter6 = val;
                                                            break;
                                                    }
                                                } else {
                                                    if (int.TryParse(valstr, out val)) {
                                                        PanelManager.TravelMeter = val;
                                                    }
                                                }
                                                break;
                                            case "cameramodepanel":
                                                if (int.TryParse(valstr, out val)) {
                                                    PanelManager.CameraViewMode = val;
                                                }
                                                break;
                                            case "disabletimeaccel":
                                                if (int.TryParse(valstr, out val)) {
                                                    if (val == 1) Misc.DisableTimeAccel = true;
                                                }
                                                break;
                                            case "crash":
                                                if (int.TryParse(seperated[0], out val)) PanelManager.Crash = val;
                                                if(seperated.Length > 1) if (int.TryParse(seperated[1], out val)) ATSSoundManager.Crash = val;
                                                break;
                                            case "crashspeed":
                                                if (int.TryParse(valstr, out val)) Plugin.CrashSpeed = val;
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
            } else {
                System.Windows.Forms.MessageBox.Show("Placeholder message: Cannot find configuration file");
            }
        }
    }
}

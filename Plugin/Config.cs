using System.IO;
using OpenBveApi.Runtime;
using System.Text;
using System;

namespace Plugin {
    internal static class Config {
        internal static string currentSection;
        internal static int[] Keys = new int[38];
        internal static bool Load(LoadProperties prop) {
            /* prop.PluginFolder will return the folder the plugin is placed on. */
            /* The final path will be "Your\TrainDirectory\hkats.ini" or "Your\TrainDirectory\Plugin\hkats.ini" */
            string cfgfile = Path.Combine(prop.PluginFolder, "hkats.ini");
            /* If it can find the config file by the path given above */
            if (File.Exists(cfgfile)) {
                /* Seperates each line to an array */
                string[] lines = File.ReadAllLines(cfgfile);
                /* Loop through each array (or lines) from the top */
                foreach (string line in lines) {
                    /* Semicolon is our comment identifier, ignore the line if it starts with semicolon */
                    if (!line.StartsWith(";")) {
                        /* Square bracket is our section identifier, set the currentSection to the section name */
                        if (line.StartsWith("[")) {
                            /* Shift the string to remove the first character, which has to be bracket. Since we shifted 1 character, we have to remove 2 characters in order to remove the last brackets*/
                            currentSection = line.Trim().Substring(1, line.Length - 2).ToLowerInvariant();
                        } else {
                            /* Seperate the key and the value by equal sign, as an array */
                            string[] cfg = line.Split('=');
                            /* After seperating, there should be at least 2 array, one represents the key and one represents the value. Only parse them if there are at least 2 array */
                            if (!(cfg.Length < 2)) {
                                /* assign the first array to a variable called "key", use the trim function to remove unnecessary spacing and convert them into lower cases */
                                string key = cfg[0].Trim().ToLowerInvariant();
                                /* assign the second array to a variable called "valstr", use the trim function to remove unnecessary spacing and convert them into lower cases */
                                string valstr = cfg[1].Trim().ToLowerInvariant();
                                /* Used later on to parse integer */
                                int val;
                                /* Seperate the value by comma as an array, this allows an value to have multiple arguments. */
                                string[] seperated = valstr.Split(',');
                                /* Check what is the currentSection */
                                switch (currentSection) {
                                    /* If the current section is keydown */
                                    case "keydown":
                                        /* If it managed to parse the first value to an integer, assign the value (PanelIndex) to the keys array on PanelManager. The array index is parsed by Functions.cs */
                                        if (int.TryParse(seperated[0], out val)) PanelManager.Keys[Func.KeyStr2ArrIndex(key)] = val;
                                        /* If there is 2 argument and it is able parse the second argument to an integer,  assign the value (SoundIndex) to the keys array on ATSSoundManager. The array index is parsed by Functions.cs*/
                                        if (seperated.Length == 2) if (int.TryParse(seperated[1], out val)) ATSSoundManager.Keys[Func.KeyStr2ArrIndex(key)] = val;
                                        /* If there is more than 2 argument and it is able parse the third argument to an integer,  assign the value (SoundIndex) to the keys array on ATSSoundManager. The array index is parsed by Functions.cs*/
                                        if (seperated.Length > 2) if (seperated[2].ToLowerInvariant() == "hold") PanelManager.Keysup[Func.KeyStr2ArrIndex(key)] = 1;
                                        break;
                                    /* If the current section is system */
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
                                    case "vigilance":
                                        switch (key) {
                                            case "resettimerkey":
                                                if(Func.String2VKey(valstr) != null)
                                                    DVS.rsettimerkey = (VirtualKeys) Func.String2VKey(valstr);
                                                break;
                                            case "timerlimit":
                                                if (int.TryParse(valstr, out val)) {
                                                    DVS.DSDTimerTimeout = val;
                                                }
                                                break;
                                            case "timerbrake":
                                                if (int.TryParse(valstr, out val)) {
                                                    DVS.DSDTimerBrakeTimeout = DVS.DSDTimerTimeout + val;
                                                }
                                                break;
                                            case "disableontrainstop":
                                                if (int.TryParse(valstr, out val)) {
                                                    if (val == 1) {
                                                        DVS.DSDDisableOnTrainStop = true;
                                                    }
                                                }
                                                break;
                                            case "resetondoormove":
                                                if (int.TryParse(valstr, out val)) {
                                                    if (val == 1) {
                                                        DVS.ResetOnDoorMove = true;
                                                    }
                                                }
                                                break;
                                            case "resetonnotchmove":
                                                if (int.TryParse(valstr, out val)) {
                                                    if (val == 1) {
                                                        DVS.ResetOnNotchMove = true;
                                                    }
                                                }
                                                break;
                                            case "timerexceedPanel":
                                                if (int.TryParse(valstr, out val)) {
                                                    PanelManager.IdleTimer = val;
                                                }
                                                break;
                                            case "resetonklaxon":
                                                if (int.TryParse(valstr, out val)) {
                                                    if (val <= 4) {
                                                        DVS.ResetOnKlaxon = val;
                                                    }
                                                }
                                                break;
                                            case "timerexceededsound":
                                                if (int.TryParse(valstr, out val)) {
                                                    ATSSoundManager.DSDTimerExceeded = val;
                                                }
                                                break;
                                            case "timerbrakesound":
                                                if (int.TryParse(valstr, out val)) {
                                                    ATSSoundManager.DSDTimerBrake = val;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    case "soundloop":
                                        if (int.TryParse(valstr, out val)) ATSSoundManager.Keysloop[Func.KeyStr2ArrIndex(key)] = val;
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
                return true;
            } else {
                /* If the file cannot be found */
                StringBuilder builder = new StringBuilder();
                builder.AppendLine($"; This file is automatically generated by {Plugin.brand}. ;");
                builder.AppendLine("; Please follow the template on https://github.com/Kenny-Hui/HK_ATS ;");
                builder.AppendLine("[keydown]");
                builder.AppendLine("key2" + "=" + "105");
                builder.AppendLine("key2" + "=" + "106");
                builder.AppendLine("");
                builder.AppendLine("[system]");
                builder.AppendLine("overspeedPanel" + "=" + "0");
                builder.AppendLine("speedlimit" + "=" + "70");
                builder.AppendLine("limitspeed" + "=" + "2");
                builder.AppendLine("");
                builder.AppendLine("[vigilance]");
                builder.AppendLine("resettimerkey" + "=" + "keyspace");
                builder.AppendLine("timerlimit" + "=" + "60");
                builder.AppendLine("timerbrake" + "=" + "5");
                builder.AppendLine("resetonnotchmove" + "=" + "1");
                builder.AppendLine("");
                builder.AppendLine("[interlock]");
                builder.AppendLine("doorapplybrake" + "=" + "1");
                builder.AppendLine("");
                builder.AppendLine("[misc]");
                builder.AppendLine("cameramodepanel" + "=" + "212");
                builder.AppendLine("disabletimeaccel" + "=" + "1");
                /* Try to save it */
                try {
                    File.WriteAllText(cfgfile, builder.ToString());
                    return true;
                } catch (Exception ex) {
                    prop.FailureReason = $"\n{Plugin.brand}: Cannot generate config file, error: {ex.Message}\nAre you sure you have write permission and the file isn't locked?";
                    return false;
                }
            }
        }
    }
}

﻿using System;
using OpenBveApi.Runtime;

namespace Plugin {
    class Config {
        SafetySystem safety = new SafetySystem();
        public int Key0 { get; set; }
        public int Key2 { get; set; }
        public int Key3 { get; set; }
        public int Key4 { get; set; }
        public int Key5 { get; set; }
        public int Key6 { get; set; }
        public int Key7 { get; set; }
        public int Key8 { get; set; }
        public int Key9 { get; set; }
        public int KeyDel { get; set; }
        public int KeyIns { get; set; }
        public int KeyHome { get; set; }
        public int KeyEnd { get; set; }
        public int KeyPgUp { get; set; }
        public int KeyPgDn { get; set; }
        public int KeySpace { get; set; }
        public void Load(LoadProperties prop) {
            string cfgfile = System.IO.Path.Combine(prop.PluginFolder, "config.txt");
            string[] lines = System.IO.File.ReadAllLines(cfgfile);
            foreach (string line in lines) {
                    string[] cfg = line.Split('=');
                    string key = cfg[0].Trim();
                        string valstr = cfg[1].Trim();
                        int val;
                        switch (key) {
                            case "key2":
                                if (int.TryParse(valstr, out val)) {
                                    Key2 = val;
                        }
                                break;
                            case "key3":
                                if (int.TryParse(valstr, out val)) {
                                    Key3 = Convert.ToInt32(val);
                                }
                                break;
                            case "key4":
                                if (int.TryParse(valstr, out val)) {
                                    Key4 = Convert.ToInt32(val);
                                }
                                break;
                            case "key5":
                                if (int.TryParse(valstr, out val)) {
                                    Key5 = Convert.ToInt32(val);
                                }
                                break;
                            case "key6":
                                if (int.TryParse(valstr, out val)) {
                                    Key6 = Convert.ToInt32(val);
                                }
                                break;
                            case "key7":
                                if (int.TryParse(valstr, out val)) {
                                    Key7 = Convert.ToInt32(val);
                                }
                                break;
                            case "key8":
                                if (int.TryParse(valstr, out val)) {
                                    Key8 = Convert.ToInt32(val);
                                }
                                break;
                            case "key9":
                                if (int.TryParse(valstr, out val)) {
                                    Key9 = Convert.ToInt32(val);
                                }
                                break;
                            case "key0":
                                if (int.TryParse(valstr, out val)) {
                                    Key0 = Convert.ToInt32(val);
                                }
                                break;
                            case "keypgup":
                                if (int.TryParse(valstr, out val)) {
                                    KeyPgUp = Convert.ToInt32(val);
                                }
                                break;
                            case "keypgdn":
                                if (int.TryParse(valstr, out val)) {
                                    KeyPgDn = Convert.ToInt32(val);
                                }
                                break;
                            case "keyend":
                                if (int.TryParse(valstr, out val)) {
                                    KeyEnd = Convert.ToInt32(val);
                                }
                                break;
                            case "keyhome":
                                if (int.TryParse(valstr, out val)) {
                                    KeyHome = Convert.ToInt32(val);
                                }
                                break;
                            case "keydel":
                                if (int.TryParse(valstr, out val)) {
                                    KeyDel = Convert.ToInt32(val);
                                }
                                break;
                            case "keyins":
                                if (int.TryParse(valstr, out val)) {
                                    KeyIns = Convert.ToInt32(val);
                                }
                                break;
                            case "keyspace":
                                if (int.TryParse(valstr, out val)) {
                                    KeyIns = Convert.ToInt32(val);
                                }
                                break;
                            case "speedlimit":
                                if (int.TryParse(valstr, out val)) {
                                    safety.SpeedLimit = Convert.ToInt32(val);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
}
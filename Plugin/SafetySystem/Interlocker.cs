using OpenBveApi.Runtime;

namespace Plugin {
    static class Interlocker {
        internal static bool DoorInterlocked = false;
        internal static bool DoorBrake = true;
        internal static bool StationInterlock { get; set; }  
        private static int p;
        internal static Station nextStation;
        internal static int B67Notch { get; set; }
        internal static void update(ElapseData data) {
            /* Hacky way to determine the next station */
            while (p < data.Stations.Count - 1 && data.Stations[p].StopPosition + 5 < data.Vehicle.Location) p++;
            while (p > 1 && data.Stations[p - 1].StopPosition + 5 > data.Vehicle.Location) p--;
            nextStation = data.Stations[p];

            if (data.Vehicle.Location > nextStation.DefaultTrackPosition && data.Vehicle.Location < (nextStation.StopPosition + 5)) {
                /* If it's true, it means the train is approaching to a station */
                if (StationInterlock) { /* If StationInterlock is enabled on the config file */
                    if (data.Vehicle.Speed.KilometersPerHour < 1) {
                        if (nextStation.OpenLeftDoors && nextStation.OpenRightDoors) {
                            data.DoorInterlockState = DoorInterlockStates.Unlocked;
                        } else {
                            if (nextStation.OpenLeftDoors) {
                                data.DoorInterlockState = DoorInterlockStates.Left;
                            } else if (nextStation.OpenRightDoors) {
                                data.DoorInterlockState = DoorInterlockStates.Right;
                            } else {
                                data.DoorInterlockState = DoorInterlockStates.Locked;
                            }
                        }
                    } else {
                        data.DoorInterlockState = DoorInterlockStates.Locked;
                    }
                }
            } else {
                if (DoorInterlocked) {
                    if (data.Vehicle.Speed.KilometersPerHour > 1) {
                        data.DoorInterlockState = DoorInterlockStates.Locked;
                    } else {
                        data.DoorInterlockState = DoorInterlockStates.Unlocked;
                    }
                } else {
                    data.DoorInterlockState = DoorInterlockStates.Locked;
                }
            }

            if (SafetySystem.DoorOpened && DoorBrake) {
                data.Handles.PowerNotch = 0;
                data.Handles.BrakeNotch = B67Notch;
            }
        }
    }
}

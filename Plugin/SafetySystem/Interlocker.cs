using OpenBveApi.Runtime;

namespace Plugin {
    class Interlocker {
        public bool DoorInterlocked = false;
        public bool DoorBrake = true;
        public static bool StationInterlock { get; set; }  
        private int p;
        public Station nextStation;
        public int B67Notch { get; set; }
        public void update(ElapseData data) {
            /* Hacky way to determine the next station */
            while (p < data.Stations.Count - 1 && data.Stations[p].StopPosition < data.Vehicle.Location) p++;
            while (p > 1 && data.Stations[p - 1].StopPosition > data.Vehicle.Location) p--;
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

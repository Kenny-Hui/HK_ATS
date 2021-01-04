using OpenBveApi.Runtime;

namespace Plugin {
    static class DSD {
        internal static bool DoorOpened { get; set; }
        internal static double DSDTimer { get; set; }
        internal static double DSDLastTimer { get; set; }
        internal static int DSDTimerTimeout { get; set; }
        internal static bool DSDTimerExceeded { get; set; }
        internal static int DSDTimerBrakeTimeout { get; set; }
        internal static bool DSDTimerBrakeExceeded = false;
        internal static VirtualKeys rsettimerkey { get; set; }
        internal static double currentTime;
        internal static bool ScheduleResetTimer;
        internal static bool DSDDisableOnTrainStop { get; set; }
        internal static bool ResetOnDoorMove { get; set; }
        internal static bool ResetOnNotchMove { get; set; }

        internal static void update(ElapseData data) {
            currentTime = data.TotalTime.Seconds;

            if (ScheduleResetTimer) {
                ResetTimer();
                ScheduleResetTimer = false;
            }

            if (DSDDisableOnTrainStop && data.Vehicle.Speed.KilometersPerHour < 1) {
                ResetTimer();
            }

            if (DSDTimerBrakeExceeded) {
                if (data.Vehicle.Speed.KilometersPerHour > 1) {
                    data.Handles.PowerNotch = 0;
                    data.Handles.BrakeNotch = SafetySystem.BrakeNotches + 1;
                } else {
                    DSDTimerBrakeExceeded = false;
                }
            }

            if (DSDTimerTimeout != 0 && DSDTimer > DSDTimerTimeout) {
                if (DSDTimer < DSDTimerBrakeTimeout) {
                    SoundManager.Play(ATSSoundManager.DSDTimerExceeded, 1.0, 1.0, true);
                } else if (DSDTimer > DSDTimerBrakeTimeout) {
                    if (DSDTimerBrakeTimeout != DSDTimerTimeout) {
                        DSDTimerBrakeExceeded = true;
                    }
                    SoundManager.Stop(ATSSoundManager.DSDTimerExceeded);
                    SoundManager.Play(ATSSoundManager.DSDTimerBrake, 1.0, 1.0, true);
                }
            } else {
                DSDTimerExceeded = false;
                SoundManager.Stop(ATSSoundManager.DSDTimerExceeded);
                SoundManager.Stop(ATSSoundManager.DSDTimerBrake);
            }

            DSDTimer = data.TotalTime.Seconds - DSDLastTimer;
        }

        internal static void KeyDown(VirtualKeys key) {
            if (key == rsettimerkey) {
                ScheduleResetTimer = true;
            } else {
                switch (key) {
                    case VirtualKeys.LeftDoors:
                        if (ResetOnDoorMove) ScheduleResetTimer = true;
                        break;
                    case VirtualKeys.RightDoors:
                        if (ResetOnDoorMove) ScheduleResetTimer = true;
                        break;
                    default:
                        break;
                }
            }
        }

        internal static void NotchMove() {
            ScheduleResetTimer = true;
        }

        internal static void ResetTimer() {
            DSDLastTimer = currentTime;
            DSDTimer = 0;
            DSDTimerExceeded = false;
        }
    }
}

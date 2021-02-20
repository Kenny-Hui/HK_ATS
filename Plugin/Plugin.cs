using OpenBveApi.Runtime;

namespace Plugin {
    /// <summary>The interface to be implemented by the plugin.</summary>
    public partial class Plugin : IRuntime {
        internal static bool crashed;
        internal static int CrashSpeed;
        private int[] Panel = null;
        /// <summary>Is called when the plugin is loaded.</summary>
        public bool Load(LoadProperties properties) {
            MessageManager.Initialise(properties.AddMessage);
            SoundManager.Initialise(properties.PlaySound, 256);
            Config.Load(properties);
            Panel = new int[512];
            Sound = new SoundHelper(properties.PlaySound, 256);
            properties.Panel = Panel;
            properties.FailureReason = "HK_ATS failed to initalize, some functions will be unavailable.";
            properties.AISupport = AISupport.None;
            return true;
        }

        public void Unload() {
        }

        /// <summary>Is called after loading to inform the plugin about the specifications of the train.</summary>
        public void SetVehicleSpecs(VehicleSpecs specs) {
            SafetySystem.BrakeNotches = specs.BrakeNotches;
            Interlocker.B67Notch = specs.B67Notch;
        }

        /// <summary>Is called when the plugin should initialize, reinitialize or jumping stations.</summary>
        public void Initialize(InitializationModes mode) {
            Misc.Initializing = true;
            DVS.ScheduleResetTimer = true;
        }

        /// <summary>Is called every frame.</summary>
        public void Elapse(ElapseData data) {
            if (data.PrecedingVehicle != null) {
                if (data.PrecedingVehicle.Distance < 0.2 && data.PrecedingVehicle.Distance > -1 && !crashed) {
                    if (data.Vehicle.Speed.KilometersPerHour > CrashSpeed) {
                        crashed = true;
                        Panel[PanelManager.Crash] = 1;
                        SoundManager.Play(ATSSoundManager.Crash, 1.0, 1.0, false);
                    }
                }
            }

            Interlocker.update(data);
            SafetySystem.update(data);
            PanelManager.update(data, Panel);
            DVS.update(data);
            Misc.Update(data);
            Sound.Update();
        }

        public void SetReverser(int reverser) {
            if (DVS.ResetOnNotchMove) DVS.ResetTimer();
        }

        public void SetPower(int powerNotch) {
            if(DVS.ResetOnNotchMove) DVS.ResetTimer();
        }

        public void SetBrake(int brakeNotch) {
            if (DVS.ResetOnNotchMove) DVS.ResetTimer();
        }

        /// <summary>Is called when a virtual key is pressed.</summary>
        public void KeyDown(VirtualKeys key) {
            DVS.KeyDown(key);
            PanelManager.KeyDown(key, Panel);
            ATSSoundManager.PlayOnce(key);
            ATSSoundManager.PlayLoop(key);
        }

        /// <summary>Is called when a virtual key is released.</summary>
        public void KeyUp(VirtualKeys key) {
            PanelManager.KeyUp(key, Panel);
        }

        public void HornBlow(HornTypes type) {
            if (DVS.ResetOnKlaxon == 4) {
                DVS.ResetTimer();
            } else {
                if (type == HornTypes.Primary && DVS.ResetOnKlaxon == 1) DVS.ResetTimer();
                if (type == HornTypes.Secondary && DVS.ResetOnKlaxon == 2) DVS.ResetTimer();
                if (type == HornTypes.Music && DVS.ResetOnKlaxon == 3) DVS.ResetTimer();
            }
        }

        /// <summary>Is called when the state of the doors changes.</summary>
        public void DoorChange(DoorStates oldState, DoorStates newState) {
            if (oldState == DoorStates.None & newState != DoorStates.None) /* Door is opened */
            {
                SafetySystem.DoorOpened = true;
            } else if (oldState != DoorStates.None & newState == DoorStates.None) /* Door is closed */
              {
                SafetySystem.DoorOpened = false;
            }
        }
        public void SetSignal(SignalData[] signal) {
            
        }

        /// <summary>Is called when the train passes a beacon.</summary>
        /// <param name="beacon">The beacon data.</param>
        public void SetBeacon(BeaconData beacon) {
            BeaconManager.ProcessBeacon(beacon, Panel);
        }

        public void PerformAI(AIData data) {
        }
    }
}
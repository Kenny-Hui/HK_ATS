using OpenBveApi.Runtime;

namespace Plugin {
    /// <summary>The interface to be implemented by the plugin.</summary>
    public partial class Plugin : IRuntime {

        private int[] Panel = null;
        /// <summary>Is called when the plugin is loaded.</summary>
        public bool Load(LoadProperties properties) {
            MessageManager.Initialise(properties.AddMessage);
            SoundManager.Initialise(properties.PlaySound, 256);
            Config.Load(properties);
            Panel = new int[256];
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
            DSD.ScheduleResetTimer = true;
        }

        /// <summary>Is called every frame.</summary>
        public void Elapse(ElapseData data) {
            Interlocker.update(data);
            SafetySystem.update(data);
            PanelManager.update(data, Panel);
            DSD.update(data);
            Sound.Update();
        }

        public void SetReverser(int reverser) {
            DSD.NotchMove();
        }

        public void SetPower(int powerNotch) {
            DSD.NotchMove();
        }

        public void SetBrake(int brakeNotch) {
            DSD.NotchMove();
        }

        /// <summary>Is called when a virtual key is pressed.</summary>
        public void KeyDown(VirtualKeys key) {
            DSD.KeyDown(key);
            PanelManager.KeyDown(key, Panel);
            ATSSoundManager.PlayOnce(key);
        }

        /// <summary>Is called when a virtual key is released.</summary>
        public void KeyUp(VirtualKeys key) {
        }

        public void HornBlow(HornTypes type) {
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
            BeaconManager.ProcessBeacon(beacon);
            switch (beacon.Type) {
                case 120:
                    if (beacon.Optional > 0.1) {
                        SafetySystem.SpeedLimit = beacon.Optional;
                    }
                    break;
                default:
                    break;
            }
        }

        public void PerformAI(AIData data) {
        }
    }
}
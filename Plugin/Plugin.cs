using OpenBveApi.Runtime;

namespace Plugin
{
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
		}

		/// <summary>Is called every frame.</summary>
		public void Elapse(ElapseData data) {
			Interlocker.update(data);
			SafetySystem.update(data);
			PanelManager.update(data, Panel);
			Sound.Update();
		}

		public void SetReverser(int reverser)
		{
		}

		public void SetPower(int powerNotch)
		{
		}

		public void SetBrake(int brakeNotch)
		{
		}

		/// <summary>Is called when a virtual key is pressed.</summary>
		public void KeyDown(VirtualKeys key)
		{
			KeyManager.KeyDown(key, Panel);
		}

		/// <summary>Is called when a virtual key is released.</summary>
		public void KeyUp(VirtualKeys key)
		{
		}

		public void HornBlow(HornTypes type)
		{
		}

		/// <summary>Is called when the state of the doors changes.</summary>
		public void DoorChange(DoorStates oldState, DoorStates newState)
		{
			if (oldState == DoorStates.None & newState != DoorStates.None) /* Door is opened */
			{
				SafetySystem.DoorOpened = true;
			}
			else if (oldState != DoorStates.None & newState == DoorStates.None) /* Door is closed */
			{
				SafetySystem.DoorOpened = false;
			}
		}
		public void SetSignal(SignalData[] signal)
		{
		}

		/// <summary>Is called when the train passes a beacon.</summary>
		/// <param name="beacon">The beacon data.</param>
		public void SetBeacon(BeaconData beacon)
		{
			switch (beacon.Type)
			{
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
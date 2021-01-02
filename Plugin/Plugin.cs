﻿using OpenBveApi.Runtime;
using OpenBveApi.Colors;

namespace Plugin
{
	/// <summary>The interface to be implemented by the plugin.</summary>
	public partial class Plugin : IRuntime {

		private int[] Panel = null;
		public int PowerNotch;
		public int BrakeNotch;
		public int B67Notch;
		Config cfg = new Config();
		Interlocker interlock = new Interlocker();
		/// <summary>Is called when the plugin is loaded.</summary>
		public bool Load(LoadProperties properties) {
			MessageManager.Initialise(properties.AddMessage);
			cfg.Load(properties);
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
			SafetySystem.PowerNotch = specs.PowerNotches;
			SafetySystem.BrakeNotch = specs.BrakeNotches;
			interlock.B67Notch = specs.B67Notch;
		}

		/// <summary>Is called when the plugin should initialize, reinitialize or jumping stations.</summary>
		public void Initialize(InitializationModes mode) {
		}

		/// <summary>Is called every frame.</summary>
		public void Elapse(ElapseData data) {
			interlock.update(data);
			SafetySystem.update(data);
			MessageManager.PrintMessage(Interlocker.StationInterlock.ToString(), MessageColor.Orange, 0.5);
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
			VirtualKeys virtualKey = key;
			switch (virtualKey) {
				case VirtualKeys.S:
					Panel[cfg.KeySpace] ^= 1;
					break;
				case VirtualKeys.A1:
					Panel[cfg.KeyIns] ^= 1;
					break;
				case VirtualKeys.A2:
					Panel[cfg.KeyDel] ^= 1;
					break;
				case VirtualKeys.B1:
					Panel[cfg.KeyHome] ^= 1;
					break;
				case VirtualKeys.B2:
					Panel[cfg.KeyEnd] ^= 1;
					break;
				case VirtualKeys.C1:
					Panel[cfg.KeyPgUp] ^= 1;
					break;
				case VirtualKeys.C2:
					Panel[cfg.KeyPgDn] ^= 1;
					break;
				case VirtualKeys.D:
					Panel[cfg.Key2] ^= 1;
					break;
				case VirtualKeys.E:
					Panel[cfg.Key3] ^= 1;
					break;
				case VirtualKeys.F:
					Panel[cfg.Key4] ^= 1;
					break;
				case VirtualKeys.G:
					Panel[cfg.Key5] ^= 1;
					break;
				case VirtualKeys.H:
					Panel[cfg.Key6] ^= 1;
					break;
				case VirtualKeys.I:
					Panel[cfg.Key7] ^= 1;
					break;
				case VirtualKeys.J:
					Panel[cfg.Key8] ^= 1;
					break;
				case VirtualKeys.K:
					Panel[cfg.Key9] ^= 1;
					break;
				case VirtualKeys.L:
					Panel[cfg.Key0] ^= 1;
					break;
				default:
					break;
			}
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
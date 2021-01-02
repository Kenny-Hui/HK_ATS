﻿using OpenBveApi.Runtime;
using OpenBveApi.Colors;
using System.Windows.Forms;

namespace Plugin
{
	/// <summary>The interface to be implemented by the plugin.</summary>
	public partial class Plugin : IRuntime {

		private int[] Panel = null;
		public int PowerNotch;
		public int BrakeNotch;
		public int B67Notch;
		Config cfg = new Config();
		Panel panel = new Panel();
		SafetySystem safety = new SafetySystem();
		/// <summary>Is called when the plugin is loaded.</summary>
		public bool Load(LoadProperties properties) {
			MessageManager.Initialise(properties.AddMessage);
			cfg.Load(properties);
			Panel panel = new Panel();
			MessageBox.Show(cfg.Key2.ToString());
			Panel = new int[256];
			Sound = new SoundHelper(properties.PlaySound, 256);
			properties.Panel = Panel;
			properties.FailureReason = "HKTrainSys failed to initalize, some functions will be unavailable.";
			properties.AISupport = AISupport.None;
			return true;
		}

		public void Unload() {
		}

		/// <summary>Is called after loading to inform the plugin about the specifications of the train.</summary>
		public void SetVehicleSpecs(VehicleSpecs specs) {
			safety.PowerNotch = specs.PowerNotches;
			safety.BrakeNotch = specs.BrakeNotches;
			safety.B67Notch = specs.B67Notch;
		}

		/// <summary>Is called when the plugin should initialize, reinitialize or jumping stations.</summary>
		public void Initialize(InitializationModes mode) {
		}

		/// <summary>Is called every frame.</summary>
		public void Elapse(ElapseData data) {
			//safety.update(data);
			if (data.Vehicle.Speed.KilometersPerHour > 2) {
				data.DoorInterlockState = DoorInterlockStates.Locked;
			} else {
				data.DoorInterlockState = DoorInterlockStates.Unlocked;
			}

			
			/*if (data.PrecedingVehicle != null)
			{
				if (data.PrecedingVehicle.Distance < 0.1 && data.PrecedingVehicle.Distance > -1 && crashed == false)
				{
						Sound[223] = SoundInstructions.PlayOnce; //Crash Sound
						Panel[105] = 0;
						Panel[106] = 0;
						Panel[101] = 1;
						Panel[213] = 1;
						Panel[100] = 1;
						crashed = true;
				}

			}*/

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
					MessageManager.PrintMessage(cfg.Key2.ToString(), MessageColor.Orange, 5.0);
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
			if (oldState == DoorStates.None & newState != DoorStates.None) //Door is opened
			{
				//safety.DoorOpened = true;
			}
			else if (oldState != DoorStates.None & newState == DoorStates.None) //Door is closed
			{
				//safety.DoorOpened = false;
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
				case 12:
					//Set speed limit
					if (beacon.Optional > 0.1) {
						safety.SpeedLimit = beacon.Optional;
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
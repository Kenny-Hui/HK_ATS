using OpenBveApi.Runtime;

namespace Plugin {
    static class BeaconManager {

        internal static int SpeedLimit { get; set; }

        internal static void RegisterPanelBeacon(int beaconNum, int val) {
            PanelManager.Beacon[beaconNum] = val;
        }

        internal static void RegisterSoundBeacon(int beaconSound, int val) {
            ATSSoundManager.Beacon[beaconSound] = val;
        }

        internal static void ProcessBeacon(BeaconData beacon, int[] panel) {
            if (beacon.Type >= 0) {
                if (beacon.Type == SpeedLimit) {
                    SafetySystem.SpeedLimit = beacon.Optional;
                } else {
                    PanelManager.OnBeacon(beacon.Type, panel);
                    ATSSoundManager.OnBeacon(beacon.Type);
                }
            }
        }
    }
}

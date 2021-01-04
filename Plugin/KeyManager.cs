using OpenBveApi.Runtime;

namespace Plugin {
    static class KeyManager {
        internal static void KeyDown(VirtualKeys key, int[] Panel) {
            PanelManager.KeyDown(key, Panel);
            ATSSoundManager.PlayOnce(key);
        }
    }
}

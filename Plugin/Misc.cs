using OpenBveApi.Runtime;

namespace Plugin {
    internal static class Misc {
        internal static int TravelMeter { get; set; }
        internal static int Travelled { get; set; }
        internal static int currentLoc { get; set; }

        internal static bool Initializing;
        internal static bool DisableTimeAccel { get; set; }
        internal static string LanguageCode;

        internal static void Update(ElapseData data) {
            currentLoc = (int) data.Vehicle.Location;
            if (Initializing) {
                TravelMeter = 0;
                Travelled = currentLoc;
                LanguageCode = data.CurrentLanguageCode;
                Initializing = false;
            }

            if (DisableTimeAccel) data.DisableTimeAcceleration = true;
            TravelMeter = currentLoc - Travelled;
        }
    }
}

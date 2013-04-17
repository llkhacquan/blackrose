using WOT.Resources;

namespace WOT {
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings {
        private static TankResources _localizedResources = new TankResources();

        public TankResources LocalizedResources { get { return _localizedResources; } }
    }
}
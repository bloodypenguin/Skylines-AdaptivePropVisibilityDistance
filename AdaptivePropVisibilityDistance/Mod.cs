using AdaptivePropVisibilityDistance.OptionsFramework;
using AdaptivePropVisibilityDistance.OptionsFramework.Extensions;
using ICities;

namespace AdaptivePropVisibilityDistance
{
    public class Mod : IUserMod
    {
        public string Name => "Adaptive Prop Visibility Distance";
        public string Description => "Adaptive Prop Visibility Distance";

        public void OnSettingsUI(UIHelperBase helper)
        {
            helper.AddOptionsGroup<Options>();
        }
    }
}

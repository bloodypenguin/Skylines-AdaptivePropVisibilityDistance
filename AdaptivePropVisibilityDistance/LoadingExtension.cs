using AdaptivePropVisibilityDistance.Redirection;
using ICities;

namespace AdaptivePropVisibilityDistance
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnCreated(ILoading loading)
        {
            base.OnCreated(loading);
            AssemblyRedirector.Deploy();
        }

        public override void OnReleased()
        {
            base.OnReleased();
            AssemblyRedirector.Revert();
        }
    }
}
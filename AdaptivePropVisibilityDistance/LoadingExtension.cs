using System.Collections.Generic;
using System.Reflection;
using AdaptivePropVisibilityDistance.Redirection;
using ColossalFramework.IO;
using ICities;
using UnityEngine;

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
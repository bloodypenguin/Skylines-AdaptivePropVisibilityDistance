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

        private static Dictionary<MethodInfo, RedirectCallsState> redirects;

        public override void OnCreated(ILoading loading)
        {
            base.OnCreated(loading);
            Redirect();
        }

        public override void OnReleased()
        {
            base.OnReleased();
            RevertRedirect();
        }

        public static void Redirect()
        {
            redirects = new Dictionary<MethodInfo, RedirectCallsState>();
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                redirects.AddRange(RedirectionUtil.RedirectType(type));
            }
        }

        private static void RevertRedirect()
        {
            if (redirects == null)
            {
                return;
            }
            foreach (var kvp in redirects)
            {
                RedirectionHelper.RevertRedirect(kvp.Key, kvp.Value);
            }
            redirects.Clear();
        }
    }
}
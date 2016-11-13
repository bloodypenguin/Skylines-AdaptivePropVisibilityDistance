using AdaptivePropVisibilityDistance.Redirection;
using AdaptivePropVisibilityDistance.Redirection.Attributes;
using UnityEngine;

namespace AdaptivePropVisibilityDistance.Detours
{
    [TargetType(typeof(TreeInfo))]
    public class TreeInfoDetour : TreeInfo
    {
        [RedirectMethod]
        public override void RefreshLevelOfDetail()
        {
            float num = RenderManager.LevelOfDetailFactor * Options.lodFactorMultiplier;
            if (m_generatedInfo.m_triangleArea == 0.0f)
            {
                m_lodRenderDistance = Options.fallbackRenderDistance * Options.lodDistanceMultiplier;
            }
            else
            {
                m_lodRenderDistance = (float)(Mathf.Sqrt(m_generatedInfo.m_triangleArea) * (double)num + Options.distanceOffset) * Options.lodDistanceMultiplier;
            }
        }
    }
}
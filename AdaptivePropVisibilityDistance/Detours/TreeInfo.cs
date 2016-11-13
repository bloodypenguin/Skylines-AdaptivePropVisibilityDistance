using AdaptivePropVisibilityDistance.OptionsFramework;
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
            float num = RenderManager.LevelOfDetailFactor * OptionsWrapper<Options>.Options.LodFactorMultiplierTrees;
            if (m_generatedInfo.m_triangleArea == 0.0f)
            {
                m_lodRenderDistance = Options.FallbackRenderDistance * OptionsWrapper<Options>.Options.LodDistanceMultiplierTrees;
            }
            else
            {
                m_lodRenderDistance = (float)(Mathf.Sqrt(m_generatedInfo.m_triangleArea) * (double)num + OptionsWrapper<Options>.Options.DistanceOffsetTrees) * OptionsWrapper<Options>.Options.LodDistanceMultiplierTrees;
            }
        }
    }
}
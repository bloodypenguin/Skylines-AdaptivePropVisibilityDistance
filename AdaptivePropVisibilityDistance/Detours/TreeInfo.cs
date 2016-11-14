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
            if (m_generatedInfo.m_triangleArea == 0.0f || float.IsNaN(m_generatedInfo.m_triangleArea))
            {
                m_lodRenderDistance = RenderManager.LevelOfDetailFactor * OptionsWrapper<Options>.Options.FallbackLodFactorMultiplierTrees;
            }
            else
            {
                float num = RenderManager.LevelOfDetailFactor * OptionsWrapper<Options>.Options.LodFactorMultiplierTrees;
                m_lodRenderDistance = (float)(Mathf.Sqrt(m_generatedInfo.m_triangleArea) * (double)num + OptionsWrapper<Options>.Options.DistanceOffsetTrees) * OptionsWrapper<Options>.Options.LodDistanceMultiplierTrees;
            }
        }
    }
}
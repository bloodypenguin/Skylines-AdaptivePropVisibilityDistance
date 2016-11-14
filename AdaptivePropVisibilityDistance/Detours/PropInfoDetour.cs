using System.Threading;
using AdaptivePropVisibilityDistance.OptionsFramework;
using AdaptivePropVisibilityDistance.Redirection;
using AdaptivePropVisibilityDistance.Redirection.Attributes;
using UnityEngine;

namespace AdaptivePropVisibilityDistance.Detours
{
    [TargetType(typeof(PropInfo))]
    public class PropInfoDetour : PropInfo
    {
        [RedirectMethod]
        public override void RefreshLevelOfDetail()
        {
            if (m_generatedInfo.m_triangleArea == 0.0f || float.IsNaN(m_generatedInfo.m_triangleArea))
            {
                m_maxRenderDistance = OptionsWrapper<Options>.Options.FallbackRenderDistanceProps;
            }
            else
            {
                float num = RenderManager.LevelOfDetailFactor * OptionsWrapper<Options>.Options.LodFactorMultiplierProps;
                m_maxRenderDistance = (float)(Mathf.Sqrt(m_generatedInfo.m_triangleArea) * (double)num + OptionsWrapper<Options>.Options.DistanceOffsetProps);
                this.m_maxRenderDistance = Mathf.Min(Options.RenderDistanceThreshold, this.m_maxRenderDistance);
            }
            m_lodRenderDistance = m_isDecal || m_isMarker ? 0.0f : (!(m_lodMesh != null) ? m_maxRenderDistance : m_maxRenderDistance * OptionsWrapper<Options>.Options.LodDistanceMultiplierProps);
            if (m_effects == null)
                return;
            for (int index = 0; index < m_effects.Length; ++index)
            {
                if (m_effects[index].m_effect != null)
                    m_maxRenderDistance = Mathf.Max(m_maxRenderDistance, m_effects[index].m_effect.RenderDistance());
            }
            this.m_maxRenderDistance = Mathf.Min(Options.RenderDistanceThresholdEffects, this.m_maxRenderDistance);
        }
    }
}
using System.Threading;
using AdaptivePropVisibilityDistance.Redirection;
using UnityEngine;

namespace AdaptivePropVisibilityDistance.Detours
{
    [TargetType(typeof(PropInfo))]
    public class PropInfoDetour : PropInfo
    {
        [RedirectMethod]
        public override void RefreshLevelOfDetail()
        {
            float num = RenderManager.LevelOfDetailFactor *Options.lodFactorMultiplier;
            if (m_generatedInfo.m_triangleArea == 0.0f)
            {
                m_maxRenderDistance = Options.fallbackRenderDistance;
            }
            else
            {
                m_maxRenderDistance = (float)(Mathf.Sqrt(m_generatedInfo.m_triangleArea) * (double)num + Options.distanceOffset);
                this.m_maxRenderDistance = Mathf.Min(Options.renderDistanceThreshold, this.m_maxRenderDistance);
            }
            m_lodRenderDistance = m_isDecal || m_isMarker ? 0.0f : (!(m_lodMesh != null) ? m_maxRenderDistance : m_maxRenderDistance *Options.lodDistanceMultiplier);
            if (m_effects == null)
                return;
            for (int index = 0; index < m_effects.Length; ++index)
            {
                if (m_effects[index].m_effect != null)
                    m_maxRenderDistance = Mathf.Max(m_maxRenderDistance, m_effects[index].m_effect.RenderDistance());
            }
            this.m_maxRenderDistance = Mathf.Min(Options.renderDistanceThresholdEffects, this.m_maxRenderDistance);
        }
    }
}
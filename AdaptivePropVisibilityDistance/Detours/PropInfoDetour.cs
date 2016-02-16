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
            float num = RenderManager.LevelOfDetailFactor * 200f;
            if (m_generatedInfo.m_triangleArea == 0.0)
            {
                m_maxRenderDistance = 1000f;
            }
            else
            {
                m_maxRenderDistance = (float)(Mathf.Sqrt(m_generatedInfo.m_triangleArea) * (double)num + 100.0);
                //begin mod
                //end mod
            }
            //begin mid
            m_lodRenderDistance = m_isDecal || m_isMarker ? 0.0f : (!(m_lodMesh != null) ? m_maxRenderDistance : m_maxRenderDistance  * 0.125f);
            //end mod
            if (m_effects == null)
                return;
            for (int index = 0; index < m_effects.Length; ++index)
            {
                if (m_effects[index].m_effect != null)
                    m_maxRenderDistance = Mathf.Max(m_maxRenderDistance, m_effects[index].m_effect.RenderDistance());
            }
            //begin mod
            //end mod
        }
    }
}
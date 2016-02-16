using AdaptivePropVisibilityDistance.Redirection;
using ColossalFramework;
using UnityEngine;

namespace AdaptivePropVisibilityDistance.Detours
{
    [TargetType(typeof(Building))]
    public class BuildingDetour
    {
        [RedirectMethod]
        public static void RenderInstance(ref Building b, RenderManager.CameraInfo cameraInfo, ushort buildingID,
            int layerMask)
        {
            if (b.m_flags == Building.Flags.None)
                return;
            BuildingInfo info = b.Info;
            //begin mod
            if ((layerMask & 1 << info.m_prefabDataLayer) == 0 && info.m_buildingAI.GetType() != typeof(ParkAI))
                //end mod
                return;
            Vector3 point = b.m_position;
            float radius = info.m_renderSize + (float)b.m_baseHeight * 0.5f;
            point.y += (float)(((double)info.m_size.y - (double)b.m_baseHeight) * 0.5);
            if (!cameraInfo.Intersect(point, radius))
                return;
            RenderManager instance = Singleton<RenderManager>.instance;
            uint instanceIndex;
            if (!instance.RequireInstance((uint)buildingID, 1U, out instanceIndex))
                return;
            RenderInstance(ref b, cameraInfo, buildingID, layerMask, info, ref instance.m_instances[(uint)instanceIndex]);
        }

        [RedirectReverse]
        private static void RenderInstance(ref Building b, RenderManager.CameraInfo cameraInfo, ushort buildingID,
            int layerMask, BuildingInfo info, ref RenderManager.Instance data)
        {
            UnityEngine.Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            UnityEngine.Debug.Log("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
        }
    }
}
using System;
using System.Runtime.CompilerServices;
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
            if ((b.m_flags & (Building.Flags.Created | Building.Flags.Deleted | Building.Flags.Hidden)) != Building.Flags.Created)
                return;
            BuildingInfo info = b.Info;
            //begin mod
            if (info == null)
            {
                return;
            }
            var ai = info.m_buildingAI;
            if ((layerMask & 1 << info.m_prefabDataLayer) == 0 && !(ai is PlayerBuildingAI || ai is DecorationBuildingAI/* || ai is DummyBuildingAI*/)) //TODO(earalov): do we need to uncomment that?
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
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void RenderInstance(ref Building b, RenderManager.CameraInfo cameraInfo, ushort buildingID,
            int layerMask, BuildingInfo info, ref RenderManager.Instance data)
        {
            UnityEngine.Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            UnityEngine.Debug.Log("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
        }
    }
}
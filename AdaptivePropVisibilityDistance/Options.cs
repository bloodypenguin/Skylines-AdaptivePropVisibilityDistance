using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptivePropVisibilityDistance
{
    public class Options
    {
        public const float renderDistanceThreshold = 100000f; //1000f default
        public const float renderDistanceThresholdEffects = 100000f; //1000f default
        public const float lodDistanceMultiplier = 0.25f; // 0.25f default
        public const float fallbackRenderDistance = 1000f;//1000f default
        public const float lodFactorMultiplier = 200f;
        public const double distanceOffset = 100.0;
    }
}

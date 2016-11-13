using System.Xml.Serialization;
using AdaptivePropVisibilityDistance.OptionsFramework;
using AdaptivePropVisibilityDistance.OptionsFramework.Attibutes;

namespace AdaptivePropVisibilityDistance
{

    public class Options : IModOptions
    {
        private const string TREES = "Trees";
        private const string PROPS = "Props";

        public Options()
        {
            LodDistanceMultiplierProps = 0.25f;
            LodFactorMultiplierProps = 200f;
            DistanceOffsetProps = 100f;

            LodDistanceMultiplierTrees = 0.25f;
            LodFactorMultiplierTrees = 200f;
            DistanceOffsetTrees = 100f;
        }

        [Slider("LOD factor multiplier (default: 200)", 1f, 1000f, 1f, PROPS, nameof(Refresher), nameof(Refresher.Refresh))]
        public float LodFactorMultiplierProps { get; private set; }

        [Slider("LOD distance offset (default: 100)", 1f, 1000f, 1f, PROPS, nameof(Refresher), nameof(Refresher.Refresh))]
        public float DistanceOffsetProps { get; private set; }

        [Slider("LOD distance multiplier (default: 0.25)", 0.05f, 1.0f, 0.05f, PROPS, nameof(Refresher), nameof(Refresher.Refresh))]
        public float LodDistanceMultiplierProps { get; private set; }

        [Slider("LOD factor multiplier (default: 200)", 1f, 1000f, 1f, TREES, nameof(Refresher), nameof(Refresher.Refresh))]
        public float LodFactorMultiplierTrees { get; private set; }

        [Slider("LOD distance offset (default: 100)", 1f, 1000f, 1f, TREES, nameof(Refresher), nameof(Refresher.Refresh))]
        public float DistanceOffsetTrees { get; private set; }

        [Slider("LOD distance multiplier (default: 0.25)", 0.05f, 1.0f, 0.05f, TREES, nameof(Refresher), nameof(Refresher.Refresh))]
        public float LodDistanceMultiplierTrees { get; private set; }

        //hardcoded

        [XmlIgnore]
        public const float RenderDistanceThreshold = 100000f; //1000f default

        [XmlIgnore]
        public const float RenderDistanceThresholdEffects = 100000f; //1000f default

        [XmlIgnore]
        public const float FallbackRenderDistance = 1000f;//1000f default



        [XmlIgnore]
        public string FileName => "AdaptivePropVisibilityDistance";
    }
}

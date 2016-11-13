namespace AdaptivePropVisibilityDistance
{
    public static class Refresher
    {
        public static void Refresh(float value)
        {
            for (ushort i = 0; i < PrefabCollection<PropInfo>.LoadedCount(); i++)
            {
                var info = PrefabCollection<PropInfo>.GetLoaded(i);
                info?.RefreshLevelOfDetail();
            }
            for (ushort i = 0; i < PrefabCollection<TreeInfo>.LoadedCount(); i++)
            {
                var info = PrefabCollection<TreeInfo>.GetLoaded(i);
                info?.RefreshLevelOfDetail();
            }
        }
    }
}
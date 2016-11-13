using System;
using System.Collections.Generic;
using AdaptivePropVisibilityDistance.OptionsFramework.Attibutes;

namespace AdaptivePropVisibilityDistance.OptionsFramework
{
    public static class IModOptionsExtension
    {
        public static string GetPropertyDescription<T>(this T value, string propertyName) where T : IModOptions
        {
            var fi = value.GetType().GetProperty(propertyName);
            var attributes =
                (AbstractOptionsAttribute[]) fi.GetCustomAttributes(typeof(AbstractOptionsAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : null;
        }

        public static string GetPropertyGroup<T>(this T value, string propertyName) where T : IModOptions
        {
            var fi = value.GetType().GetProperty(propertyName);
            var attributes =
                (AbstractOptionsAttribute[]) fi.GetCustomAttributes(typeof(AbstractOptionsAttribute), false);
            return attributes.Length > 0 ? attributes[0].Group : null;
        }

        public static TR GetAttribute<T, TR>(this T value, string propertyName) where T : IModOptions where TR : AbstractOptionsAttribute
        {
            var fi = value.GetType().GetProperty(propertyName);
            var attributes = (TR[])fi.GetCustomAttributes(typeof(TR), false);
            return attributes.Length != 1 ? null : attributes[0];
        }

    }
}
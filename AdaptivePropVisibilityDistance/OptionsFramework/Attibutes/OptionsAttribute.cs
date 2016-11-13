using System;

namespace AdaptivePropVisibilityDistance.OptionsFramework.Attibutes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class OptionsAttribute : Attribute
    {
        public OptionsAttribute(string fileName)
        {
            FileName = fileName;
        }

        public string FileName
        {
            get;
        }
    }
}
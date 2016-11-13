using System.Xml.Serialization;

namespace AdaptivePropVisibilityDistance.OptionsFramework
{
    public interface IModOptions
    {
        [XmlIgnore]
        string FileName
        {
            get;
        }
    }
}
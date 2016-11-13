using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using AdaptivePropVisibilityDistance.OptionsFramework.Attibutes;
using ColossalFramework.IO;
using UnityEngine;

namespace AdaptivePropVisibilityDistance.OptionsFramework
{
    public class OptionsWrapper<T>
    {
        private static T _instance;

        public static T Options
        {
            get
            {
                try
                {
                    Ensure();
                }
                catch (XmlException e)
                {
                    UnityEngine.Debug.LogError("Error reading options XML file");
                    UnityEngine.Debug.LogException(e);
                }
                return _instance;
            }
        }

        public static void Ensure()
        {
            if (_instance != null)
            {
                return;
            }
            var type = typeof(T);
            var attrs = type.GetCustomAttributes(typeof(OptionsAttribute), false);
            if (attrs.Length != 1)
            {
                throw new Exception($"Type {type.FullName} is not an options type!");
            }
            _instance = (T)Activator.CreateInstance(typeof(T));
            LoadOptions();
        }

        private static void LoadOptions()
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                var fileName = Path.Combine(DataLocation.localApplicationData, GetFileName());
                if (!fileName.EndsWith(".xml"))
                {
                    fileName = fileName + ".xml";
                }
                using (var streamReader = new StreamReader(fileName))
                {
                    var options = (T)xmlSerializer.Deserialize(streamReader);
                    foreach (var propertyInfo in typeof(T).GetProperties())
                    {
                        if (!propertyInfo.CanWrite)
                        {
                            continue;
                        }
                        var value = propertyInfo.GetValue(options, null);
                        propertyInfo.SetValue(_instance, value, null);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                SaveOptions();// No options file yet
            }
        }

        internal static void SaveOptions()
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                var fileName = Path.Combine(DataLocation.localApplicationData, GetFileName());
                if (!fileName.EndsWith(".xml"))
                {
                    fileName = fileName + ".xml";
                }
                using (var streamWriter = new StreamWriter(fileName))
                {
                    xmlSerializer.Serialize(streamWriter, _instance);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private static string GetFileName()
        {
            var type = _instance.GetType();
            var attrs = type.GetCustomAttributes(typeof(OptionsAttribute), false);
            return ((OptionsAttribute) attrs[0]).FileName;
        }
    }
}
using System;
using System.IO;
using Models;
using Core;


namespace Management
{
    public class SettingsHandler
    {
        public SettingsHandler()
        {
        }

        public Settings Load(string path)
        {
            if (File.Exists(path))
            {
                return Core.Utilities.Serializer.Instance.Read<Settings>(path);
            }
            else
            {
                return null;
            }
        }


        public void Save(string path, Settings settings)
        {
            string directoryPath = Path.GetDirectoryName(path);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            Core.Utilities.Serializer.Instance.Write(path, settings);
        }

    }
}

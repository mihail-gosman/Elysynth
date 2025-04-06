using System;
using System.IO;
using Models;
using Core;


namespace Management
{
    public class SettingsHandler
    {
        private string _settingsFilePath;
        public Settings ActiveSettings;

        public SettingsHandler()
        {
            ActiveSettings = new Settings();
        }

        public Settings Load() 
        {
            ActiveSettings = Core.Utilities.Serializer.Instance.Read<Settings>(_settingsFilePath);
            return ActiveSettings; 
        }
        
        public void Save() 
        {
            Core.Utilities.Serializer.Instance.Write(_settingsFilePath, ActiveSettings);
        }

        public void SetPath(string path) 
        {
            if (string.IsNullOrEmpty(path))
            {
                _settingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.bin");
            }
            else
            {
                _settingsFilePath = path;
            }
            
            if (!File.Exists(_settingsFilePath))
            {
                Settings settings = new Settings();
                Core.Utilities.Serializer.Instance.Write(_settingsFilePath, settings);
            }
        }
    }
}

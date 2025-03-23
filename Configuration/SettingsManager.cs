using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Configuration
{
    public class SettingsManager
    {
        public Settings ActiveSettings { get; private set; }
        private string _fullPath { get; set; }
        private string _settingsFileName = "settings.bin";

        public SettingsManager()
        {
            ActiveSettings = new Settings();
        }

        public void LoadSettings()
        {
            string filePath = Path.Combine(_fullPath, _settingsFileName);
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    ActiveSettings = (Settings)formatter.Deserialize(fs);
                }
            }
        }

        public void SaveSettings()
        {
            string filePath = Path.Combine(_fullPath, _settingsFileName);
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, ActiveSettings);
            }
        }

        public void SetPath(string path)
        {
            // If the path is empty, set the path to the current directory
            if (string.IsNullOrEmpty(path))
            {
                _fullPath = AppDomain.CurrentDomain.BaseDirectory;
            }
            else
            {
                _fullPath = path;
            }
        }
    }
}

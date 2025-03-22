using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Core.Configuration
{
    public class SettingsManager
    {
        public Settings ActiveSettings { get; private set; }
        string FullPath { get; set; }
        string SettingsFileName = "settings.bin";

        public SettingsManager()
        {
            ActiveSettings = new Settings();
        }

        public void LoadSettings()
        {
            string filePath = Path.Combine(FullPath, SettingsFileName);
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
            string filePath = Path.Combine(FullPath, SettingsFileName);
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
                FullPath = AppDomain.CurrentDomain.BaseDirectory;
            }
            else
            {
                FullPath = path;
            }
        }
    }
}

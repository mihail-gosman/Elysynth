using System.IO;
using System.Xml.Serialization;
using Models;

namespace DataCore
{
    public class SettingsManager
    {
        public Settings Settings { get; set; }
        private string Path { get; set; }

        public SettingsManager(string path)
        {
            Path = path;
            Settings = new Settings();
        }

        public void LoadSettings()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using (FileStream fs = new FileStream(Path, FileMode.Open))
            {
                Settings = (Settings)serializer.Deserialize(fs);
            }
        }

        public void SaveSettings()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using (FileStream fs = new FileStream(Path, FileMode.Create))
            {
                serializer.Serialize(fs, Settings);
            }
        }

    }
}

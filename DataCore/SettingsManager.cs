using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
            if (File.Exists(Path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(Path, FileMode.Open))
                {
                    Settings = (Settings)formatter.Deserialize(stream);
                }
            }
        }

        public void SaveSettings()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(Path, FileMode.Create))
            {
                formatter.Serialize(stream, Settings);
            }
        }

    }
}

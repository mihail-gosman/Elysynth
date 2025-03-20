using System;
namespace Models
{
    [Serializable]
    public class Settings
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string ScenesPath { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Version: {Version}";
        }
    }
}

using System;
using System.Runtime.CompilerServices;

namespace Models
{
    [Serializable]
    public class Settings
    {
        public string AppName { get; set; } = "Elysynth";
        public string AppVersion { get; set; } = "0.1";
        public string ProjectsDirectoryPath { get; set; }
    }
}

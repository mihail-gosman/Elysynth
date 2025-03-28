using System;
using System.Runtime.CompilerServices;

namespace Models
{
    [Serializable]
    public class Settings
    {
        public string FilePath { get; set; }
        public string AppName { get; set; } = "Elysync";
        public string AppVersion { get; set; } = "0.1";

        public string ProjectsDirectoryPath { get; set; }
    }
}

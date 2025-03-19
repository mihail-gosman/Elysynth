using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
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

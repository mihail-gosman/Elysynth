using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Models;

namespace Management
{
    public class ProjectHandler
    {
        public static Project Load(string path)
        {
            return Core.Utilities.Serializer.Instance.Read<Project>(path);
        }

        public static void Save(string path, Project project)
        {
            Core.Utilities.Serializer.Instance.Write(path, project);
        }
    }
}

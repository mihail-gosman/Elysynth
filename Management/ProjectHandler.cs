using System;
using System.IO;
using System.Linq;
using Models;

namespace Management
{
    public class ProjectHandler
    {
       public static Project Load(string path)
       {
            if (File.Exists(path))
            {
                return Core.Utilities.Serializer.Instance.Read<Project>(path);
            }
            else
            {
                return null;
            }
        }

        public static void Save(string path, Project project) 
        {
            Core.Utilities.Serializer.Instance.Write(path, project);
        }
    }
}

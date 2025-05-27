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

        public static Particle AddParticle(Project project)
        {
            var particle = new Models.Particle
            {
                Name = "Particle" + (project.Entities.Count + 1),
                Position = new Vector2(1, 1),
                Velocity = new Vector2(0, 0),
                Acceleration = new Vector2(0, 0),
                Mass = 1,
                Charge = 1

            };
            project.Entities.Add(particle);
            return particle;
        }

        public static Field AddField(Project project)
        {
            var field = new Models.Field
            {
                Name = "Field" + (project.Entities.Count + 1),
                Position = new Vector2(1, 1),
                Charge = 1,
            };
            project.Entities.Add(field);
            return field;
        }
    }
}

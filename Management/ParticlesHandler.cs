using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Numerics;
using Core;
using Models;

namespace Management
{
    public class ParticlesHandler
    {
        public static void Add(Project project, Particle particle)
        {
            project.Particles.Add(particle);
        }

        public static void Remove(Project project, Particle particle)
        {
            project.Particles.Remove(particle);
        }
    }
}

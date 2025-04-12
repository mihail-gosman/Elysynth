using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Numerics;
using System.Security.Cryptography;
using Core;
using Models;

namespace Management
{
    public class ParticlesHandler
    {
        public static void AddParticle(Particle particle, List<Particle> particles)
        {
            /*
            TODO: Incomplete code.
            No checking of variable 'ID' yet. 
            Need to add validation for 'ID' later.
            */

            particle.Id = particles.Count + 1;
            particles.Add(particle);
        }

        public static void RemoveParticleByName(Particle particle, List<Particle> particles)
        {
            foreach (var p in particles)
            {
                if (p.Name == particle.Name)
                {
                    particles.Remove(p);
                    break;
                }
            }
        }
    }
}

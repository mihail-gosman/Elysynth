using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace EngineSystem
{
    public class Engine
    {
        private List<Particle> particles = new List<Particle>();

        public double DeltaTime { get; set; }
        public bool IsRunning { get; private set; }

        public Engine() { }

        public void SetDeltaTime(double deltaTime)
        {
            DeltaTime = deltaTime;
        }

        public double GetDeltaTime()
        {
            return DeltaTime;
        }

        public void Start()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public void AddParticle(Particle particle)
        {
            particles.Add(particle);
        }
        public void RemoveParticle(Particle particle)
        {
            particles.Remove(particle);
        }

        public List<Particle> GetParticles()
        {
            return particles;
        }

        // Updates the particles in the engine
        public void Update()
        {
            if (IsRunning)
            {
                foreach (var particle in particles)
                {
                    particle.Update(DeltaTime);
                }
            }
        }
    }
}

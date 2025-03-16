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
        List<Particle> particles = new List<Particle>();

        double deltaTime { get; set; }
        bool isRunning { get; set; }

        public Engine()
        {
        }

        public void SetDeltaTime(double deltaTime) { this.deltaTime = deltaTime; }

        public double GetDeltaTime() { return deltaTime; }

        public void Start() { isRunning = true; }

        public void Stop() { isRunning = false; }

        public void AddParticle(Particle particle)
        {
            particles.Add(particle);
        }

        public List<Particle> GetParticles() {  return particles; }

        public void Update()
        {
            if (isRunning)
            {
                foreach (var particle in particles)
                {
                    particle.Update(deltaTime);
                }
            }
        }


    }


}

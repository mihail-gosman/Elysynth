using Core;
using Models;
using Management;

using System.Windows.Forms;

namespace Engine
{
    public class Simulation
    {
        public double DeltaTime { get; set; } = 0.5;
        public bool IsRunning = false;
        public Project ActiveProject { get; set; }
        
        public Simulation() { }

        public Simulation(Panel panel, Project project)
        {
            ActiveProject = project;
        }

        public void Update()
        {
            foreach (var entity in ActiveProject.Entities)
            {
                if (entity is Particle particle)
                {
                    particle.Position.X += particle.Velocity.X * DeltaTime;
                    particle.Position.Y += particle.Velocity.Y * DeltaTime;
                }
            }

        }


    }
}

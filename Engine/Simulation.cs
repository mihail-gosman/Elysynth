using Core;
using Models;
using Management;

namespace Engine
{
    public class Simulation
    {
        public double DeltaTime { get; set; }
        public bool IsRunning = false;
        public Project ActiveProject { get; set; }
        
        public Simulation() { }

        public Simulation(Project project)
        {
            ActiveProject = project;
        }

        public void Update()
        {
            if (IsRunning)
            {
                ;
            }
        }

        

    }
}

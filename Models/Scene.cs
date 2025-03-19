using Models;
using System.Collections.Generic;

namespace Models
{
    public class Scene
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public List<Particle> Particles { get; set; }

        public Scene()
        {
            Particles = new List<Particle>();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Particles: {Particles}";
        }
    }
}

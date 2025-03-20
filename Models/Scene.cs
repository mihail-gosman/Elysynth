using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class Scene
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public List<Particle> Particles { get; set; }
        public List<Field> Fields { get; set; }

        public Scene()
        {
            Particles = new List<Particle>();
            Fields = new List<Field>();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Particles: {Particles}";
        }
    }
}

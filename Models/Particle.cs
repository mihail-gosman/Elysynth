using System;
using System.Numerics;

namespace Models
{
    [Serializable]
    public class Particle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public double Mass { get; set; }
        public double Charge { get; set; }

    }
}

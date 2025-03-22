using System;
using System.Numerics;

namespace Models
{
    [Serializable]
    public class Particle
    {
        public int Id { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public float Mass { get; set; }
        public float Charge { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Position: {Position}, Velocity: {Velocity}, Acceleration: {Acceleration}, Mass: {Mass}, Charge: {Charge}";
        }
    }
}

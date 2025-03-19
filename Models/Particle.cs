using System.Numerics;

namespace Models
{
    public class Particle
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public float Mass { get; set; }
        public float Charge { get; set; }


        public override string ToString()
        {
            return $"Position: {Position}, Velocity: {Velocity}, Acceleration: {Acceleration}, Mass: {Mass}, Charge: {Charge}";
        }
    }
}

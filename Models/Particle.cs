using System;

namespace Models
{
    [Serializable]
    public class Particle
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "1";
        public Vector2 Position { get; set; } = new Vector2(1, 1);
        public Vector2 Velocity { get; set; } = new Vector2(1, 1);
        public Vector2 Acceleration { get; set; } = new Vector2(1, 1);
        public double Mass { get; set; } = 1;
        public double Charge { get; set; } = 1;
    }
}

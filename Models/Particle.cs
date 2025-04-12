﻿using System;

namespace Models
{
    [Serializable]
    public class Particle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public double Mass { get; set; }
        public double Charge { get; set; }

    }
}

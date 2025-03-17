using System;
using System.Numerics;

namespace Models
{
    // Represents a particle in a 2D space
    public class Particle
    {
        public double Mass { get; set; }
        public double Charge { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public string Name { get; set; }

        public Particle() { }

        
        public Particle(double mass, double charge, Vector2 position, Vector2 velocity, Vector2 acceleration, string name)
        {
            Mass = mass;
            Charge = charge;
            Position = position;
            Velocity = velocity;
            Acceleration = acceleration;
            Name = name;
        }

        // Updates the particle's position based on its velocity and acceleration
        public void Update(double deltaTime)
        {
            // Update the position using the kinematic equation: x = x0 + v0 * t + 0.5 * a * t^2
            Position += Velocity * (float)deltaTime + 0.5f * Acceleration * (float)Math.Pow(deltaTime, 2);
        }

        // Applies a force to the particle
        public void ApplyForce(Vector2 force)
        {
            // Calculate the acceleration from the applied force using Newton's second law: F = m * a => a = F / m
            Vector2 acc = force / (float)Mass;

            // Update the particle's acceleration
            Acceleration += acc;
        }

        // Converts the particle's properties to a string
        public override string ToString()
        {
            return $"Particle: mass={Mass}, charge={Charge}, position={Position}, velocity={Velocity}, acceleration={Acceleration}";
        }
    }
}

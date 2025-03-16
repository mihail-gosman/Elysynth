using System;
using System.Numerics;
namespace Models
{
    public class Particle
    {
        private double mass;
        private double charge;
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 acceleration;
        private string name;
       

        public Particle()
        {
        }

        public Particle(double mass, double charge, Vector2 position, Vector2 velocity, Vector2 acceleration, string name)
        {
            this.mass = mass;
            this.charge = charge;
            this.position = position;
            this.velocity = velocity;
            this.acceleration = acceleration;
            this.name = name;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public void SetAcceleration(Vector2 acceleration)
        {
            this.acceleration = acceleration;
        }

        public void SetMass(double mass)
        {
            this.mass = mass;
        }

        public void SetCharge(double charge)
        {
            this.charge = charge;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public Vector2 GetVelocity()
        {
            return velocity;
        }

        public Vector2 GetAcceleration()
        {
            return acceleration;
        }

        public double GetCharge()
        {
            return charge;
        }

        public double GetMass()
        {
            return mass;
        }

        public void Update(double deltaTime)
        {
            // Update the position using the kinematic equation: x = x0 + v0 * t + 0.5 * a * t^2
            position += velocity * (float)deltaTime + 0.5f * acceleration * (float)Math.Pow(deltaTime, 2);
        }

        public void ApplyForce(Vector2 force)
        {
            // Calculate the acceleration from the applied force using Newton's second law: F = m * a => a = F / m
            Vector2 acc = force / (float)mass;

            // Update the particle's acceleration
            acceleration += acc;
        }

        public override string ToString()
        {
            return $"Particle: mass={mass}, charge={charge}, position={position}, velocity={velocity}, acceleration={acceleration}";
        }
    }
}

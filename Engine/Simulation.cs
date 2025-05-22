using Core;
using Models;
using Management;
using System.Windows.Forms;
using System;

namespace Engine
{
    public class Simulation
    {
        public double DeltaTime { get; set; } = 0.01; // Adjust as needed for visible motion
        public bool IsRunning = false;
        public Project ActiveProject { get; set; }

        public Simulation() { }

        public Simulation(Project project)
        {
            ActiveProject = project;
        }

        public void Update()
        {
            const double k = 8.99e9; // Coulomb's constant

            // Reset all accelerations of particles
            foreach (var entity in ActiveProject.Entities)
            {
                if (entity is Particle p)
                {
                    p.Acceleration = new Vector2(0, 0);
                }
            }

            // Compute forces for each Particle due to every other entity (Particle or Field)
            for (int i = 0; i < ActiveProject.Entities.Count; i++)
            {
                if (!(ActiveProject.Entities[i] is Particle pi)) continue;

                for (int j = 0; j < ActiveProject.Entities.Count; j++)
                {
                    if (i == j) continue; // Skip self-force

                    var ej = ActiveProject.Entities[j];

                    Vector2 r;
                    double distSq;

                    if (ej is Particle pj)
                    {
                        r = pj.Position - pi.Position;
                        distSq = r.MagnitudeSquared();

                        if (distSq < 1e-4) continue;

                        Vector2 direction = r.Normalized();
                        double forceMag = k * Math.Abs(pi.Charge * pj.Charge) / distSq;
                        double sign = Math.Sign(pi.Charge * pj.Charge);

                        Vector2 force = direction * forceMag * sign;

                        pi.Acceleration += force / pi.Mass;
                        // Apply opposite force on pj for Newton's third law
                        pj.Acceleration -= force / pj.Mass;
                    }
                    else if (ej is Field f)
                    {
                        r = f.Position - pi.Position;
                        distSq = r.MagnitudeSquared();

                        if (distSq < 1e-4) continue;

                        Vector2 direction = r.Normalized();
                        double forceMag = k * Math.Abs(pi.Charge * f.Charge) / distSq;
                        double sign = Math.Sign(pi.Charge * f.Charge);

                        Vector2 force = direction * forceMag * -sign;

                        // Field doesn't move, only particle is affected
                        pi.Acceleration += force / pi.Mass;
                    }
                }
            }

            // Update velocities and positions of particles only
            foreach (var entity in ActiveProject.Entities)
            {
                if (entity is Particle p)
                {
                    p.Velocity += p.Acceleration * DeltaTime;
                    p.Position += p.Velocity * DeltaTime;

                    // Optional damping
                    // p.Velocity *= 0.99;
                }
            }
        }

    }
}

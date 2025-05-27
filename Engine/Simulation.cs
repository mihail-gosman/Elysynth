using Core;
using Models;
using Management;
using System.Windows.Forms;
using System;

namespace Engine
{
    public class Simulation
    {
        public double DeltaTime { get; set; } = 0.01;
        public bool IsRunning = false;
        public Project ActiveProject { get; set; }

        public Simulation() { }

        public Simulation(Project project)
        {
            ActiveProject = project;
        }

        public void Update()
        {
            const double k = 8.99e9;
            
            foreach (var entity in ActiveProject.Entities)
            {
                if (entity is Particle p)
                {
                    p.Acceleration = new Vector2(0, 0);
                }
            }

            for (int i = 0; i < ActiveProject.Entities.Count; i++)
            {
                if (!(ActiveProject.Entities[i] is Particle pi)) continue;

                for (int j = 0; j < ActiveProject.Entities.Count; j++)
                {
                    if (i == j) continue;

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
                        pi.Acceleration += force / pi.Mass;
                    }
                }
            }

            foreach (var entity in ActiveProject.Entities)
            {
                if (entity is Particle p)
                {
                    p.Velocity += p.Acceleration * DeltaTime;
                    p.Position += p.Velocity * DeltaTime;
                }
            }
        }

    }
}

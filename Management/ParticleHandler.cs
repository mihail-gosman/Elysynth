﻿using System.Collections.Specialized;
using System.Numerics;
using Core;
using Models;

namespace Management
{
    public class ParticleHandler
    {
        private Project _activeProject; 
        
        public ParticleHandler(Project project)
        {
            _activeProject = project;
        }

        public Particle NewParticle(Vector2 position, Vector2 velocity, Vector2 acceleration, double mass, double charge)
        {
            Particle particle = new Particle();
            particle.ID = _activeProject.Particles.Count + 1;
            particle.Position = position;
            particle.Velocity = velocity;
            particle.Acceleration = acceleration;
            particle.Mass = mass;
            particle.Charge = charge;
            return particle;
        }

        public void AddParticle(Particle particle)
        {
            _activeProject.Particles.Add(particle);
        }

        public void RemoveParticleById(int id)
        {
            foreach (var particle in _activeProject.Particles)
            {
                if(particle.ID == id)
                {
                    _activeProject.Particles.Remove(particle);
                }
            }
        }
    
    }
}

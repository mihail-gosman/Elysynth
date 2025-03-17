using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;
using Models;
using EngineSystem;

namespace Elysynth
{
    class Program
    {
        static void Main(string[] args)
        {

            Engine engine = new Engine();

            List<Particle> particles = new List<Particle>();
            Vector2 position = new Vector2(0f, 0f);
            Vector2 velocity = new Vector2(1f, 0f);
            engine.SetDeltaTime(1);
            engine.AddParticle(new Particle(1, 1, position, velocity, new Vector2(0, 0), "Electron"));
            engine.AddParticle(new Particle(1, 1, position, velocity, new Vector2(0, 0), "Proton"));
            int a = 0;

            engine.Start();
            engine.RemoveParticle(engine.GetParticles()[1]);
            while (a < 10)
            {
                particles = engine.GetParticles();
                foreach (var par in particles)
                {
                    
                    engine.Update();
                    Console.WriteLine(par.ToString());
                    a++;
                    engine.Stop();
                    engine.Start();
                    
                }
                Thread.Sleep(1000);

            }
        }
    }
}

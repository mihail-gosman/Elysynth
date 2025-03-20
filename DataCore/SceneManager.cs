using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Models;

namespace DataCore
{
    public class SceneManager
    {
        string Path { get; set; }
        private readonly string _absolutePath;

        public List<Scene> Scenes { get; set; }

        public SceneManager(string path)
        {
            Path = path;
            _absolutePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Scenes = new List<Scene>();
        }

        public Scene NewScene(string name)
        {
            Scene scene = new Scene();
            scene.Particles = new List<Particle>();
            scene.Name = name;
            Scenes.Add(scene);
            return scene;
        }

        public void SaveScenes()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            foreach (Scene scene in Scenes)
            {
                using (FileStream stream = new FileStream(_absolutePath + "\\" + Path + "\\" + scene.Name + ".scene", FileMode.Create))
                {
                    formatter.Serialize(stream, scene);
                }
            }

        }

        public void LoadScenes()
        {
            Scenes.Clear();
            BinaryFormatter formatter = new BinaryFormatter();
            foreach (string file in Directory.GetFiles(_absolutePath + "\\" + Path + "\\", "*.scene"))
            {
                using (FileStream stream = new FileStream(file, FileMode.Open))
                {
                    Scene scene = (Scene)formatter.Deserialize(stream);
                    Scenes.Add(scene);
                }
            }
        }

        public void DeleteScene(string name)
        {
            Scene scene = Scenes.Find(s => s.Name == name);
            if (scene != null)
            {
                Scenes.Remove(scene);
                File.Delete(_absolutePath + "\\" + Path + "\\" + name + ".scene");
            }
        }

        public Scene LoadScene(string sceneName)
        {
            Scene scene = Scenes.Find(s => s.Name == sceneName);
            return scene;
        }

        public void AddParticle(string sceneName, Particle particle)
        {
            Scene scene = Scenes.Find(s => s.Name == sceneName);
            if (scene != null)
            {
                scene.Particles.Add(particle);
            }
        }

        public void RemoveParticle(string sceneName, int id)
        {
            Scene scene = Scenes.Find(s => s.Name == sceneName);
            if (scene != null)
            {
                scene.Particles.Remove(scene.Particles.First(p => p.Id == id));
            }
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using Models;


namespace Core.Configuration
{
    public class SceneManager
    {
        private string ScenesFolderName = "Scenes";
        private string FullPath { get; set; }
        public List<Scene> Scenes { get; private set; }

        public SceneManager()
        {
            Scenes = new List<Scene>();
        }

        public void LoadScenes()         {
            string folderPath = Path.Combine(FullPath, ScenesFolderName);

            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath, "*.bin");

                foreach (string file in files)
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        Scene scene = (Scene)formatter.Deserialize(fs);
                        Scenes.Add(scene);
                    }
                }
            }
        }

        public void SaveScenes()
        {
            string folderPath = Path.Combine(FullPath, ScenesFolderName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            foreach (Scene scene in Scenes)
            {
                string filePath = Path.Combine(folderPath, scene.Name + ".bin");
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, scene);
                }
            }
        }

        public Scene NewScene(String name) // Changed to non-static
        {
            Scene scene = new Scene();
            scene.Name = name;
            scene.Id = Scenes.Count + 1;
            Scenes.Add(scene);
            return scene;
        }

        public void RemoveScene(Scene scene) // Changed to non-static
        {
            Scenes.Remove(scene);
            string folderPath = Path.Combine(FullPath, ScenesFolderName);
            string filePath = Path.Combine(folderPath, scene.Name + ".bin");
            File.Delete(filePath);
        }

        public void SetPath(string path) // Changed to non-static
        {
            if (string.IsNullOrEmpty(path))
            {
                FullPath = AppDomain.CurrentDomain.BaseDirectory;
            }
            else
            {
                FullPath = path;
            }
        }
    }
}

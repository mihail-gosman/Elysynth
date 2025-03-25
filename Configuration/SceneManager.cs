using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using Core;
using Models;
using Core.Logging;


namespace Configuration
{
    public class SceneManager
    {
        private string _scenesFolderName = "Scenes";
        private string _fullPath { get; set; }
        public List<Scene> Scenes { get; private set; }

        public SceneManager()
        {
            Scenes = new List<Scene>();
            Logger.Instance.Log("SceneManager initialized", Logger.LogLevel.Info);
        }

        public void LoadScenes()
        {
            string folderPath = Path.Combine(_fullPath, _scenesFolderName);

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
                Logger.Instance.Log("Scenes loaded", Logger.LogLevel.Info);
            }
        }

        public void SaveScenes()
        {
            string folderPath = Path.Combine(_fullPath, _scenesFolderName);

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
                Logger.Instance.Log(filePath, Logger.LogLevel.Info);
            }
        }

        public Scene NewScene(String name) 
        {
            Scene scene = new Scene();
            scene.Name = name;
            scene.Id = Scenes.Count + 1;
            Scenes.Add(scene);
            Logger.Instance.Log($"New Scene: {name}");
            return scene;
        }

        public void RemoveScene(Scene scene) 
        {
            Scenes.Remove(scene);
            string folderPath = Path.Combine(_fullPath, _scenesFolderName);
            string filePath = Path.Combine(folderPath, scene.Name + ".bin");
            File.Delete(filePath);
            Logger.Instance.Log($"Remove scene {scene.Name}");
        }

        public void RenameScene(Scene scene, string newName) 
        {
            string folderPath = Path.Combine(_fullPath, _scenesFolderName);
            string oldFilePath = Path.Combine(folderPath, scene.Name + ".bin");
            string newFilePath = Path.Combine(folderPath, newName + ".bin");
            File.Move(oldFilePath, newFilePath);
            scene.Name = newName;
            Logger.Instance.Log($"Scene {scene.Name} renamed");
        }

        public Scene GetScene(string name) 
        {
            if (Scenes.Find(scene => scene.Name == name) == null)
            {
                Logger.Instance.Log($"Scene {name} not found", Logger.LogLevel.Warning);
                return null;
            }

            return Scenes.Find(scene => scene.Name == name);
        }

        public void SetPath(string path) 
        {
            if (string.IsNullOrEmpty(path))
            {
                _fullPath = AppDomain.CurrentDomain.BaseDirectory;
                Logger.Instance.Log($"Scenes path set to {_fullPath}", Logger.LogLevel.Info);
            }
            else
            {
                _fullPath = path;
            }
        }
    }
}
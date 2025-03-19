using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Models;

namespace DataCore
{
    public class SceneManager
    {
        string Path { get; set; }
        List<Scene> Scenes { get; set; }
        Scene ActiveScene { get; set; }
        List<string> ScenesNames { get; set; } = new List<string>();

        public SceneManager(string path)
        {
            Path = path;
            Scenes = new List<Scene>();
        }

        public  Scene NewScene(string name)
        {
            Scene scene = new Scene();
            scene.Name = name;
            ActiveScene = scene;
            return scene;
        }

        public void LoadScenesNames()
        {
            string[] files = Directory.GetFiles(Path);
            foreach (string file in files)
            {
                Scene scene = new Scene();
                XmlSerializer serializer = new XmlSerializer(typeof(Scene));


                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    scene = (Scene)serializer.Deserialize(fs);
                    ScenesNames.Add(scene.Name);
                }
                
            }
                
        }

        public void LoadScene(string name)
        {
            string file = Path + name + ".xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Scene));
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                ActiveScene = (Scene)serializer.Deserialize(fs);
            }
        }

        public void SaveScene()
        {
            string file = Path + ActiveScene.Name + ".xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Scene));
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                serializer.Serialize(fs, ActiveScene);
            }
        }
    }
}

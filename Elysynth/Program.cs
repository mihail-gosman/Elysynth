using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;
using Models;
using System.IO;
using DataCore;

namespace Elysynth
{
    class Program
    {
        static void Main(string[] args)
        {
            string settingsPath = "config.xml";
            string scenesPath = "Scenes/";

            DataCore.SettingsManager settingsManager = new DataCore.SettingsManager(settingsPath);
            settingsManager.LoadSettings();

            DataCore.SceneManager sceneManager = new DataCore.SceneManager(scenesPath);
            sceneManager.NewScene("lol");
            sceneManager.SaveScene();




        }
    }
}

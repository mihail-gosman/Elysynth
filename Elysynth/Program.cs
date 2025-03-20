using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;
using Models;
using System.IO;
using DataCore;
using System.Data;

namespace Elysynth
{
    class Program
    {
        private static string settingsPath; 
        private static SettingsManager settingsManager;
        private static SceneManager sceneManager;
        private static Scene activeScene;

        enum Command
        {
            exit,
            load,
            save,
            show,
            create,
            delete,
            unknown
        }

        static void Main(string[] args)
        {
            Initialise();
           
            if (args.Length > 0)
            {
                ;
            }
            
            else 
            {
                Console.WriteLine($"Welcome to {settingsManager.Settings.Name} version: {settingsManager.Settings.Version}");
                Console.WriteLine("For help, type: help");
            }

            while (true)
            {
                Console.Write($"elysynth {activeScene?.Name ?? ""}> ");
                string userInput = Console.ReadLine();

                if (userInput == null)
                {
                    continue;
                }

                string[] commandParts = userInput.Split(' ');
                Command command = ParseCommand(commandParts[0]);
                string[] arguments = commandParts.Skip(1).ToArray();

                switch (command)
                {
                    case Command.exit:
                        Exit();
                        return;
                        break;

                    case Command.load:
                        Load(arguments);
                        break;

                    case Command.save:
                        Save(arguments);
                        break;

                    case Command.show:
                        Show(arguments);
                        break;

                    case Command.create:
                        Create(arguments);
                        break;

                    case Command.delete:
                        Delete(arguments);
                        break;

                    case Command.unknown:
                        Console.WriteLine("Unknown command, for help type: help");
                        break;

                }
            }
        }

        private static void Initialise()
        {
            settingsPath = ConfigurationManager.AppSettings["SettingsPath"];
            settingsManager = new SettingsManager(settingsPath);
            settingsManager.LoadSettings();
            sceneManager = new SceneManager(settingsManager.Settings.ScenesPath);
            sceneManager.LoadScenes();
            activeScene = null;
        }

        private static Command ParseCommand(string command) 
        {
            if(Enum.TryParse(command, out Command result))
            {
                return result;
            }
            return Command.unknown;
        }

        private static void Load(string[] arguments)
        {
            if (arguments.Length == 0)
            {
                Console.WriteLine("Please provide a scene name to load");
                return;
            }

            else
            {
                if (arguments[0] == "scenes")
                {
                    sceneManager.LoadScenes();
                    Console.WriteLine("Scenes loaded");
                    return;
                }
                else if (arguments[0] == "settings")
                {
                    settingsManager.LoadSettings();
                    Console.WriteLine("Settings loaded");
                    return;
                }
                else if (arguments[0] == "scene")
                {
                    if (arguments.Length == 1)
                    {
                        Console.WriteLine("Please provide a scene name to load");
                        return;
                    }
                    else
                    {
                        activeScene = sceneManager.Scenes.Find(s => s.Name == arguments[1]);
                        Console.WriteLine($"Scene {activeScene.Name} loaded");
                        return;
                    }
                }
            }
        }

        private static void Save(string[] arguments)
        {
            if (arguments.Length == 0)
            {
                ;
            }
            else if(arguments[0] == "scenes")
            {
                sceneManager.SaveScenes();
                sceneManager.LoadScenes();
                Console.WriteLine("Scenes saved");
                return;
            }
            else if (arguments[0] == "settings")
            {
                settingsManager.SaveSettings();
                Console.WriteLine("Settings saved");
                return;
            }
            else
            {
                Console.WriteLine("Unknown command, for help type: help");
                return;
            }
        }

        private static void Show(string[] arguments)
        {
            if (arguments[0] == "scenes")
            {
                foreach(Scene scene in sceneManager.Scenes)
                {
                    Console.WriteLine($"{scene.Name}");
                }
            }
            else if (arguments[0] == "settings")
            {
                Console.WriteLine(settingsManager.Settings.ToString());
            }
        }

        private static void Create(string[] arguments)
        {
            string name;

            if (arguments.Length == 0)
            {
                Console.Write("Provide a name for the scene: ");
                name = Console.ReadLine();
            }
            else
            {
                name = arguments[0];
            }
            activeScene = null;
            activeScene = new Scene();
            activeScene.Name = name;   
        }

        private static void Delete(string[] arguments)
        {
            if (string.IsNullOrEmpty(arguments[0]))
            {
                ; // De completat
            }
            else if (!string.IsNullOrEmpty(arguments[0]))
            {
                if (arguments[0] == "scene")
                {
                    sceneManager.DeleteScene(arguments[1]);
                    activeScene = null;
                    sceneManager.SaveScenes();
                    sceneManager.LoadScenes();
                }
            }
        }

        private static void Exit()
        {
            Console.WriteLine("Exiting...");
        }
    }
}

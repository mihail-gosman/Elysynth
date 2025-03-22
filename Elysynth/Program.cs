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
using System.Runtime.Remoting.Lifetime;
using System.Runtime;
using System.Data.SqlClient;
using System.Runtime.Hosting;

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
                        break;
                    
                    case Command.load:
                        Load(arguments); 
                        break;

                    case Command.show:
                        Show(arguments);
                        break;

                    case Command.delete:
                        Delete(arguments);
                        break;

                    case Command.create:
                        Create(arguments);
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
            command = command.ToLower();
            if (Enum.TryParse(command, out Command result))
            {
                return result;
            }

            return Command.unknown;

        }

        private static void Load(string[] arguments)
        {
            if (arguments.Length == 0)
            {
                Console.WriteLine("Please provide what to load (scenes / scene / settings)");
                return;
            }
            else if (arguments.Length == 1)
            {
                if (arguments[0] == "settings")
                {
                    settingsManager.LoadSettings();
                }
                else if (arguments[0] == "scenes")
                {
                    sceneManager.LoadScenes();
                }
            }
            else if (arguments.Length == 2 && arguments[0] == "scene")
            {
                activeScene = sceneManager.Scenes.FirstOrDefault(s => s.Name == arguments[1]);
            }
        }

        private static void Show(string[] arguments)
        {
            if (arguments.Length == 0)
            {
                Console.WriteLine("Please provide what to show (scenes / settings)");
                return;
            }
            else if (arguments.Length == 1)
            {
                if (arguments[0] == "settings")
                {
                    Console.WriteLine(settingsManager.Settings);
                }
                else if (arguments[0] == "scenes")
                {
                    foreach (Scene scene in sceneManager.Scenes)
                    {
                        Console.WriteLine(scene.Name);
                    }
                }
            }
            else if (arguments.Length == 2 && arguments[0] == "scene")
            {
                Scene scene = sceneManager.Scenes.FirstOrDefault(s => s.Name == arguments[1]);
                if (scene != null)
                {
                    Console.WriteLine(scene);
                }
            }
        }

        private static void  Delete(string[] arguments)
        {
            if (arguments.Length == 0)
            {
                Console.WriteLine("Please provide what to delete (scene)");
                return;
            }
            else if (arguments.Length == 1 && arguments[0] == "scene")
            {
                Console.WriteLine("Please provide the name of the scene to delete");
                return;
            }
            else if (arguments.Length == 2 && arguments[0] == "scene")
            {
                sceneManager.DeleteScene(arguments[1]);
                sceneManager.SaveScenes();
                sceneManager.LoadScenes();
            }
        }

        private static void Create(string[] arguments)
        {
            if (arguments.Length == 0)
            {
                Console.WriteLine("Please provide what to create (scene)");
                return;
            }
            else if (arguments.Length == 1 && arguments[0] == "scene")
            {
                Console.WriteLine("Please provide the name of the scene to create");
                return;
            }
            else if (arguments.Length == 2 && arguments[0] == "scene")
            {
                activeScene = sceneManager.NewScene(arguments[1]);
                sceneManager.SaveScenes();
                sceneManager.LoadScenes();
            }
        }

        private static void Exit()
        {
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
        }
    }
}

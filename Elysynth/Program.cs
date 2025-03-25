using System;
using Core;
using Models;
using Configuration;
using System.Linq;
using Core.Logging;

namespace Elysynth
{
    class Program
    {
        private enum Command
        {
            none,
            exit,
            load_scene,
            list_scenes,
            add_scene,
            save_scenes,
            remove_scene,
            unknown
        }

        private static SettingsManager _settingsManager;
        private static Settings _activeSettings;
        private static SceneManager _sceneManager;
        private static Scene _activeScene;

        static void Main(string[] args)
        {
            Program program = new Program();
            Initialise();
            
            Console.WriteLine($"Welcome to {_activeSettings.Name} version: {_activeSettings.Version}");
            Console.WriteLine("Type 'help' for a list of commands");
            
            while (true)
            {
                Console.Write($"Elysynth ");
                if (_activeScene != null)
                {
                    Console.Write($"{_activeScene.Name}");
                }
                Console.Write("> ");
                string input = Console.ReadLine();
                


                string[] commandParts = input.Split(' ');
                Command command = ParseCommand(commandParts[0]);
                string[] arguments = commandParts.Skip(1).ToArray();
                

                switch (command)
                {
                    case Command.none:
                        break;

                    case Command.exit:
                        Core.Logging.Logger.Instance.Log("Elysynth exited");
                        return;

                    case Command.load_scene:
                        LoadScene(arguments);
                        break;

                    case Command.list_scenes:
                        ListScenes();
                        break;

                    case Command.add_scene:
                        AddScene(arguments);
                        break;

                    case Command.save_scenes:
                        SaveScenes();
                        break;

                    case Command.remove_scene:
                        RemoveScene(arguments);
                        break;

                    case Command.unknown:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }

        private static void Initialise()
        {
            Logger.Instance.Log("Initialising Elysynth");
            _settingsManager = new SettingsManager();
            _settingsManager.SetPath(null);
            _settingsManager.LoadSettings();
            _activeSettings = _settingsManager.ActiveSettings;

            _sceneManager = new SceneManager();
            _sceneManager.SetPath(null);
            _sceneManager.LoadScenes();
        }

        private static void LoadScene(string[] arguments)
        {
            if (arguments.Length == 0)
            {
                Console.WriteLine("No scene specified");
                return;
            }

            else
            {
                _activeScene = _sceneManager.GetScene(arguments[0]);
                if (_activeScene == null)
                {
                    Console.WriteLine("Scene not found");
                    return;
                }
            }
        }

        private static void ListScenes()
        {
            if (_sceneManager.Scenes.Count == 0)
            {
                Console.WriteLine("No scenes found");
            }
            else
            {
                foreach (Scene scene in _sceneManager.Scenes)
                {
                    Console.WriteLine(scene.Name);
                }
            }
        }
        
        private static void AddScene(string[] arguments)
        {
            if (arguments.Length == 0)
            {
                Console.WriteLine("No scene name specified");
                return;
            }
            else
            {
                _activeScene = _sceneManager.NewScene(arguments[0]);
                Console.WriteLine(_activeScene.Name);
            }
        }

        private static void SaveScenes()
        {
            _sceneManager.SaveScenes();
        }

        private static void RemoveScene(string[] arguments)
        {
            if (arguments.Length == 0)
            {
                Console.WriteLine("No scene specified");
                return;
            }
            else
            {
                Scene scene = _sceneManager.GetScene(arguments[0]);
                _sceneManager.RemoveScene(scene);
                _sceneManager.LoadScenes();
            }
        }

        private static Command ParseCommand(string command)
        {
            if (command == null)
            {
                return Command.none;
            }
            else if (Enum.TryParse(command.Replace("-", "_"), true, out Command result))
            {
                return result;
            }
            return Command.unknown;
        }
    }
}

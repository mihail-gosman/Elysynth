using System;
using Core;
using Models;
using Configuration;
using System.Linq;

namespace Elysynth
{
    class Program
    {
        private enum Command
        {
            none,
            exit,
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
            Core.Logger.Instance.Log("Elysynth started");
            Console.WriteLine($"Welcome to {_activeSettings.Name} version: {_activeSettings.Version}");
            Console.WriteLine("Type 'help' for a list of commands");

            while (true)
            {
                Console.Write($"Elysync {_activeSettings?.Name ?? ""}> ");
                string input = Console.ReadLine();

                string[] commandParts = input.Split(' ');
                Command command = ParseCommand(commandParts[0]);
                string[] arguments = commandParts.Skip(1).ToArray();
                

                switch (command)
                {
                    case Command.none:
                        break;

                    case Command.exit:
                        Core.Logger.Instance.Log("Elysynth exited");
                        return;

                    case Command.unknown:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }

        private static void Initialise()
        {
            _settingsManager = new SettingsManager();
            _settingsManager.SetPath(null);
            _settingsManager.LoadSettings();
            _activeSettings = _settingsManager.ActiveSettings;

            _sceneManager = new SceneManager();
            _sceneManager.SetPath(null);
            _sceneManager.LoadScenes();
        }

        private static Command ParseCommand(string command)
        {
            if (command == null)
            {
                return Command.none;
            }
            else if (Enum.TryParse(command, true, out Command result))
            {
                return result;
            }
            return Command.unknown;
        }
    }
}

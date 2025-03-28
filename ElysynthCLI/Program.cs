using Core;
using Management;
using System;
using System.ComponentModel.Design;
using Models;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
namespace ElysynthCLI
{
    class Program
    {
        static Management.SettingsHandler settingsHandler;
        static Management.ProjectHandler projectHandler;
        static Project ActiveProject = new Project();

        enum Command
        {
            exit,
            new_project,
            save_project,

            unknown,
            none
        }

        static void Main(string[] args)
        {

            Program program = new Program();
            Initialise();
            
            Console.WriteLine($"Welcome to {settingsHandler.ActiveSettings.AppName} version: {settingsHandler.ActiveSettings.AppVersion}");
            Console.WriteLine("Type 'help' for a list of commands\n");

            while (true)
            {
                string input;
                Console.Write($"elysynth {ActiveProject?.Name ?? ""}> ");
                input = Console.ReadLine();

                string[] commandParts = input.Split(' ');
                Command command = ParseCommand(commandParts[0]);
                string[] arguments = commandParts.Skip(1).ToArray();

                switch (command)
                {
                    case Command.exit:
                        Core.Logger.Instance.Log("Elysynth exited");
                        return;

                    case Command.new_project:
                        NewProject(arguments);
                        break;

                    case Command.save_project:
                        SaveProject(arguments);
                        break;

                    case Command.unknown:
                        Console.WriteLine("Unknown command");
                        break;
                }
                
            }
        }
        
        static void Initialise()
        {
            Core.Logger.Instance.Log("Initialising Elysynth");
            settingsHandler = new SettingsHandler();
            settingsHandler.SetPath(null);
            settingsHandler.Load();

            projectHandler = new ProjectHandler();
            projectHandler.SetPath(null);
            
        }

        static private Command ParseCommand(string command)
        {
            if(string.IsNullOrEmpty(command))
            {
                return Command.none;
            }
            else if (Enum.TryParse(command.Replace("-", "_"), true, out Command result))
            {
                return result;
            }
            return Command.unknown;
        }

        static private void NewProject(string[] arguments)
        {
            Project project = new Project();
            project.Name = arguments[0];
            ActiveProject = project;
        }

        static private void SaveProject(string[] arguments)
        {
            string lol = "";
            projectHandler.SaveProject(lol, ActiveProject);
        }
    }
}

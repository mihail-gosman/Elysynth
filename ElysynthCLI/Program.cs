using Core;
using Management;
using System;
using System.ComponentModel.Design;
using Models;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Hosting;
using System.Xml.Linq;

namespace ElysynthCLI
{
    class Program
    {
        static Management.SettingsHandler settingsHandler;
        static Management.ProjectHandler projectHandler;
        static Management.ParticleHandler particleHandler;
        static Project ActiveProject = new Project();

        enum Command
        {
            exit,
            list_projects,
            new_project,
            save_project,
            delete_project,
            load_project,
            add_particle,
            remove_particle,
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

                    case Command.delete_project:
                        DeleteProject(arguments);
                        break;

                    case Command.load_project:
                        LoadProject(arguments);
                        break;

                    case Command.list_projects:
                        ListProjects(arguments);
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
            if (arguments.Length == 0)
            {
                Console.Write("Please provide the name for the project: ");
                string name = Console.ReadLine();
                Project project = new Project();
                project.Name = name;
                ActiveProject = project;
            }
            else
            {
                Project project = new Project();
                project.Name = arguments[0];
                ActiveProject = project;
            }
            particleHandler = new Management.ParticleHandler(ActiveProject);   
        }

        static private void SaveProject(string[] arguments)
        {
            if (arguments.Length == 0)
            {
                projectHandler.SaveProject(null, ActiveProject);
            }
            else
            {
                projectHandler.SaveProject(arguments[0], ActiveProject);
            }
        }

        static private void DeleteProject(string[] arguments)
        {
            if (arguments.Length != 0)
            {
                projectHandler.DeleteProjectByName(arguments[0]);
                if (arguments[0] == ActiveProject.Name)
                {
                    ActiveProject = null;
                }
            }
        }

        static private void LoadProject(string[] arguments)
        {
            if (arguments.Length == 0)
            {
                Console.Write("Please provide the name for the project: ");
                string name = Console.ReadLine();

                if (name ==  null)
                {
                    Console.WriteLine("Invalid name");
                }
                else
                {
                    ActiveProject = projectHandler.NewProject(name);
                }
            }
            else
            {
                ActiveProject = projectHandler.LoadProjectByName(arguments[0]);
            }
            particleHandler = new ParticleHandler(ActiveProject);
        }


        static private void ListProjects(string[] arguments)
        {
            string[] names;
            names = projectHandler.ListProjects(null);
        }
    }
}

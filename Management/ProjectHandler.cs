using System;
using System.IO;
using System.Linq;
using Models;

namespace Management
{
    public class ProjectHandler
    {
        private string _directoryPath {  get; set; }

        public string[] GetProjectsNames ()
        {
           return Directory.GetFiles (_directoryPath, "*");
        }

        public string[] ListProjects(string path)
        {
            if (path == null)
            {
                string[] filePaths = Directory.GetFiles(_directoryPath, "*.ely");
                string[] fileNames = new string[filePaths.Length]; 

                int index = 0;
                foreach (string filePath in filePaths)
                {
                    fileNames[index] = Path.GetFileName(filePath); 
                    index++;
                }

                // Print the file names
                foreach (string fileName in fileNames)
                {
                    Console.WriteLine(fileName);
                }

                return fileNames;
            }
            return null;
        }
        

        public Project GetProjectByName(string name)
        {
            string filePath = Path.Combine(_directoryPath, name + ".ely");
            if (File.Exists(filePath))
            {
                return Core.Utilities.Serializer.Instance.Read<Project>(filePath);
            }
            return null;
        }
    
        public void SaveProject(string path, Project project)
        {
            string filePath;
            if (string.IsNullOrEmpty(path))
            {
                filePath = Path.Combine(_directoryPath, project.Name + ".ely");
            }
            else
            {
                filePath = Path.Combine(path, project.Name + ".ely");
            }

            Core.Utilities.Serializer.Instance.Write<Project>(filePath, project);
        }

        public Project LoadProjectByName(string name)
        {
            string filePath = Path.Combine (_directoryPath, name + ".ely");
            if (File.Exists(filePath))
            {
               return Core.Utilities.Serializer.Instance.Read<Project>(filePath) as Project;
            }
            return null;
        }

        public Project NewProject(string name)
        {
            Project project = new Project();
            project.Name = name;
            return project;
        }

        public void DeleteProjectByName(string name)
        {
            string filePath = Path.Combine(_directoryPath, name + ".ely");

            if (File.Exists(filePath))
            {
                File.Delete(filePath); 
            }
        }

        public void SetPath(string path)
        {
            if (path == null)
            {
                _directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Projects");
            }
            else
            {
                _directoryPath = path;
            } 
        }

        // Particles & Fields
    }
}

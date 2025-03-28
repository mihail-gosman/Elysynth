using System;
using System.IO;
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

        public Project GetProjectByName(string name)
        {
            string filePath = Path.Combine(_directoryPath, name);
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
                filePath = Path.Combine(_directoryPath, project.Name);
            }

            filePath = Path.Combine(path, project.Name);

            Core.Utilities.Serializer.Instance.Write<Project>(filePath, project);
        }

        public Project NewProject(string name)
        {
            Project project = new Project();
            project.Name = name;
            return project;
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
    }
}

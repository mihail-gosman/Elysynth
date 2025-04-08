using System;
using Core;
using Models;

namespace Management
{
    class FieldsHandler
    {
        private Project _activeProject;

        public FieldsHandler(Project project) 
        {
            _activeProject = project;
        }

        public Field NewField(Vector2 position, double charge)
        {
            Field field = new Field();
            field.Id = _activeProject.Particles.Count + 1;
            field.Position = position;
            field.Charge = charge;
            return field;
        }

        public void AddField(Field field)
        {
            _activeProject.Fields.Add(field);
        }

        public void RemoveFieldById(int id)
        {
            foreach (Field field in _activeProject.Fields)
            {
                if (field.Id == id)
                {
                    _activeProject.Fields.Remove(field);
                }
            }
        }
    }
}

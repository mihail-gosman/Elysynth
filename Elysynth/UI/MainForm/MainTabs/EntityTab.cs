using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elysynth.UI.MainForm
{
    public partial class MainForm
    {
        private object _currentEntity;

        private void UpdateEntityTab(object entity, string keyword = null)
        {
            _currentEntity = entity;
            grid_entity.Rows.Clear();
            grid_entity.Columns.Clear();

            if (entity == null)
                return;

            grid_entity.Location = new Point(0, 0);
            grid_entity.Dock = DockStyle.Fill;
            grid_entity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid_entity.ColumnHeadersVisible = false;
            grid_entity.RowHeadersVisible = false;
            grid_entity.AllowUserToAddRows = false;
            grid_entity.AllowUserToDeleteRows = false;
            grid_entity.AllowUserToResizeRows = false;
            grid_entity.BackgroundColor = Color.White;

            var propertyColumn = grid_entity.Columns.Add("Property", "Property");
            var valueColumn = grid_entity.Columns.Add("Value", "Value");

            grid_entity.Columns[propertyColumn].ReadOnly = true;
            grid_entity.Columns[propertyColumn].Selected = false;
            grid_entity.Columns[valueColumn].ReadOnly = false;

            foreach (var prop in entity.GetType().GetProperties())
            {
                object value = prop.GetValue(entity);
                string displayValue = "";
                if (value is Vector2)
                {
                    displayValue = ((Vector2)value).X + ", " + ((Vector2)value).Y;
                }
                else
                {
                    displayValue = value?.ToString() ?? "";
                }
                if (prop.Name == "Id")
                    continue;

                grid_entity.Rows.Add(prop.Name, displayValue);
            }

            grid_entity.CellEndEdit -= Grid_entity_CellEndEdit;
            grid_entity.CellEndEdit += Grid_entity_CellEndEdit;

            // Force CellValueChanged to trigger on edit
            grid_entity.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (grid_entity.IsCurrentCellDirty)
                    grid_entity.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }

        private void Grid_entity_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_currentEntity == null || e.RowIndex < 0 || e.ColumnIndex != 1)
                return;

            string propertyName = grid_entity.Rows[e.RowIndex].Cells[0].Value?.ToString();
            string newValueStr = grid_entity.Rows[e.RowIndex].Cells[1].Value?.ToString();

            if (string.IsNullOrWhiteSpace(propertyName) || newValueStr == null)
                return;

            var property = _currentEntity.GetType().GetProperty(propertyName);
            if (property == null || !property.CanWrite)
                return;

            try
            {
                object convertedValue = null;
                if (property.PropertyType == typeof(Vector2))
                {
                    string[] values = newValueStr.Split(',');
                    convertedValue = new Vector2(double.Parse(values[0]), double.Parse(values[1]));
                    property.SetValue(_currentEntity, convertedValue);
                }
                else
                {
                    convertedValue = Convert.ChangeType(newValueStr, property.PropertyType);
                    property.SetValue(_currentEntity, convertedValue);
                }
            }
            catch (Exception ex)
            {
                UpdateEntityTab(_currentEntity);
            }

            UpdateSimulationPanel();
            UpdateEntitiesPanel();
        }

    }
}

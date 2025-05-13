using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Core;
using Models;
using Management;
using System.Runtime.InteropServices;
using System.IO;

namespace Elysynth
{
    public partial class MainWindow : MetroForm
    {
        private string _fullPath = AppDomain.CurrentDomain.BaseDirectory;

        private Settings _settings;
        private Project _activeProject;
        private string _activeProjectPath;

        private Label _selectedEntityLabel;
        private object _activeEntity;

        public MainWindow()
        {
            InitializeComponent();
            _settings = SettingsHandler.Load(_fullPath + "settings.bin");

            if (_settings == null)
            {
                _settings = new Settings();
                _settings.AppName = "Elysynth";
                _settings.AppVersion = "0.1";
                SettingsHandler.Save(_fullPath + "settings.bin", _settings);
            }

            lbl_elysynth.Text += "  " + _settings.AppVersion;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        #region Menu Strip 
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newProjectWindow = new NewProjectWindow();

            if (newProjectWindow.ShowDialog() == DialogResult.OK)
            {
                _activeProject = newProjectWindow.project;
                _activeProjectPath = newProjectWindow.path;

                saveAsToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                projectToolStripMenuItem.Enabled = true;
                UpdateEntitiesPanel(string.Empty);
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Forms.OptionsWindow(_settings);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                _settings = form.settings;
                SettingsHandler.Save(_fullPath + "settings.bin", _settings);
            }
            else
            {
                _settings = form.settings;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Elysynth Project Files (*.ely)|*.ely";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fileDialog.Title = "Open Elysynth Project";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                _activeProjectPath = fileDialog.FileName;
                _activeProject = ProjectHandler.Load(_activeProjectPath);
                if (_activeProject != null)
                {
                    saveAsToolStripMenuItem.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;
                    projectToolStripMenuItem.Enabled = true;
                    UpdateEntitiesPanel(string.Empty);
                }
                else
                {
                    MessageBox.Show("Failed to load project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectHandler.Save(_activeProjectPath, _activeProject);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Elysynth Project Files (*.ely)|*.ely";
            fileDialog.InitialDirectory = Path.GetDirectoryName(_activeProjectPath);
            fileDialog.Title = "Save Elysynth Project As";
            fileDialog.FileName = Path.GetFileName(_activeProjectPath);

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                _activeProjectPath = fileDialog.FileName;
                ProjectHandler.Save(_activeProjectPath, _activeProject);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void particleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Particle particle = new Particle();
            _activeProject.Entities.Add(particle);
            UpdateEntitiesPanel(string.Empty);
        }
        #endregion

        #region UI Updates
        private void UpdateEntitiesPanel(string txt_keys)
        {
            panel_entities.Controls.Clear(); // clear current UI

            if (_activeProject != null)
            {
                int y = 5;

                foreach (var entity in _activeProject.Entities)
                {
                    string name = entity.GetType().GetProperty("Name")?.GetValue(entity)?.ToString();

                    if (!string.IsNullOrEmpty(txt_keys) &&
                        (string.IsNullOrEmpty(name) || !name.ToLower().Contains(txt_keys.ToLower())))
                    {
                        continue;
                    }

                    Label lbl_entity = new Label()
                    {
                        Text = name,
                        Location = new Point(10, y),
                        AutoSize = true,
                        Cursor = Cursors.Hand,
                        Tag = entity
                    };

                    lbl_entity.Click += (s, e) =>
                    {
                        if (_selectedEntityLabel != null)
                        {
                            _selectedEntityLabel.ForeColor = Color.Black;
                            _selectedEntityLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        }

                        _activeEntity = entity;
                        _selectedEntityLabel = lbl_entity;
                        lbl_entity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        UpdateEntityPanel(entity, string.Empty);
                    };

                    panel_entities.Controls.Add(lbl_entity);
                    y += 15;
                }
            }
        }

        private void UpdateEntityPanel(object entity, string txt_property)
        {
            panel_properties.Controls.Clear();

            if (entity == null) return;

            var properties = entity.GetType().GetProperties();
            int y = 5;

            foreach (var prop in properties)
            {
                if (!prop.CanRead || !prop.CanWrite)
                    continue;

                if (!string.IsNullOrEmpty(txt_property) &&
                    !prop.Name.ToLower().Contains(txt_property.ToLower()))
                    continue;

                if (prop.PropertyType != typeof(string) &&
                    !prop.PropertyType.IsValueType &&
                    prop.PropertyType != typeof(Vector2))
                    continue;

                Label lbl = new Label()
                {
                    Text = prop.Name,
                    Location = new Point(0, y),
                    AutoSize = true,
                };

                Control input;

                if (prop.PropertyType == typeof(Vector2))
                {
                    Vector2 value = (Vector2)prop.GetValue(entity);

                    TextBox txtX = new TextBox()
                    {
                        Text = value.X.ToString(),
                        Location = new Point(65, y),
                        Width = 40,
                        Tag = "X"
                    };

                    TextBox txtY = new TextBox()
                    {
                        Text = value.Y.ToString(),
                        Location = new Point(115, y),
                        Width = 40,
                        Tag = "Y"
                    };

                    txtX.TextChanged += (s, e) =>
                    {
                        if (float.TryParse(txtX.Text, out float newX))
                        {
                            value.X = newX;
                            prop.SetValue(entity, value);
                        }
                    };

                    txtY.TextChanged += (s, e) =>
                    {
                        if (float.TryParse(txtY.Text, out float newY))
                        {
                            value.Y = newY;
                            prop.SetValue(entity, value);
                        }
                    };

                    panel_properties.Controls.Add(lbl);
                    panel_properties.Controls.Add(txtX);
                    panel_properties.Controls.Add(txtY);
                }
                else
                {
                    input = new TextBox()
                    {
                        Text = prop.GetValue(entity)?.ToString(),
                        Location = new Point(60, y),
                        Width = 100,
                    };

                    input.TextChanged += (s, e) =>
                    {
                        var textBox = s as TextBox;
                        try
                        {
                            object newValue = Convert.ChangeType(textBox.Text, prop.PropertyType);
                            prop.SetValue(entity, newValue);
                        }
                        catch
                        {
                            // optional: handle conversion errors silently
                        }
                        UpdateEntitiesPanel(string.Empty);
                    };

                    panel_properties.Controls.Add(lbl);
                    panel_properties.Controls.Add(input);
                }

                y += 30;
            }
        }
        #endregion

        private void txt_entitiesSearch_Enter(object sender, EventArgs e)
        {
            txt_entitiesSearch.Text = string.Empty;
            txt_entitiesSearch.ForeColor = Color.Black;
        }

        private void txt_entitiesSearch_Leave(object sender, EventArgs e)
        {
            if (txt_entitiesSearch.Text == string.Empty)
            {
                txt_entitiesSearch.Text = "Search";
                txt_entitiesSearch.ForeColor = Color.Gray;
            }

            UpdateEntitiesPanel(string.Empty);
        }

        private void txt_entitiesSearch_TextChanged(object sender, EventArgs e)
        {
            UpdateEntitiesPanel(txt_entitiesSearch.Text);
        }

        private void txt_propertySearch_TextChanged(object sender, EventArgs e)
        {
            UpdateEntityPanel(_activeEntity, txt_propertySearch.Text);
        }

        private void txt_propertySearch_Enter(object sender, EventArgs e)
        {
            txt_propertySearch.Text = string.Empty;
            txt_propertySearch.ForeColor = Color.Black;
        }

        private void txt_propertySearch_Leave(object sender, EventArgs e)
        {
            if (txt_propertySearch.Text == string.Empty)
            {
                txt_propertySearch.ForeColor = Color.Gray;
                txt_propertySearch.Text = "Search";
                UpdateEntityPanel(_activeEntity, String.Empty);
            }
            else
            {
                UpdateEntityPanel(_activeEntity, txt_propertySearch.Text);

            }
        }
    }
}

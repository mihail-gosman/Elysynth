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
                int y = 10;

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
                        
                        _selectedEntityLabel = lbl_entity;
                        lbl_entity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        UpdateEntityPanel(entity);
                    };

                    panel_entities.Controls.Add(lbl_entity);
                    y += 20;
                }
            }
        }

        private void UpdateEntityPanel(object entity)
        {
            
            Label lbl_name = new Label()
            {
                Text = "Name",
                Location = new Point(0, 2),
                AutoSize = true,
            };
            
            TextBox txt_name = new TextBox()
            {
                Text = entity.GetType().GetProperty("Name").GetValue(entity).ToString(),
                Location = new Point(45, 0),
                
            };

            txt_name.TextChanged += (s, e) =>
            {
                var textBox = s as TextBox;
                if (textBox != null && entity != null)
                {
                    var nameProp = entity.GetType().GetProperty("Name");
                    if (nameProp != null && nameProp.CanWrite)
                    {
                        nameProp.SetValue(entity, textBox.Text);
                        UpdateEntitiesPanel(string.Empty); 
                    }
                }
            };

            Label lbl_x = new Label()
            {
                Text = "X",
                Location = new Point(0, lbl_name.Location.Y + 25),
                AutoSize = true,
            };

            Vector2 position = (Vector2)entity.GetType().GetProperty("Position").GetValue(entity);

            TextBox txt_x = new TextBox()
            {
                Text = position.X.ToString(),
                Location = new Point(45, lbl_name.Location.Y + 25),
            };
          

            panel_properties.Controls.Clear();
            panel_properties.Controls.Add(lbl_name);
            panel_properties.Controls.Add(txt_name);
            panel_properties.Controls.Add(lbl_x);
            panel_properties.Controls.Add(txt_x);
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
        }

        private void txt_entitiesSearch_TextChanged(object sender, EventArgs e)
        {
            UpdateEntitiesPanel(txt_entitiesSearch.Text);
        }

       
    }
}

     

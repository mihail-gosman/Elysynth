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
    public partial class MainWindow: MetroForm
    {
        private string _fullPath = AppDomain.CurrentDomain.BaseDirectory;

        private Settings _settings;
        private Project _activeProject;
        private string _activeProjectPath;


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
            UpdateTabControl();
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
                UpdateTabControl();
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
                    UpdateEntitiesPanel();
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
            UpdateEntitiesPanel();
        }
        #endregion

        #region UI Updates
        private void UpdateEntitiesPanel()
        {
            if (_activeProject != null)
            {
                splitContainer4.Panel1.Controls.Clear();
                foreach (var entity in _activeProject.Entities)
                {
                    if (entity is Particle particle)
                    {
                        Label label = new Label();
                        label.Text = particle.Name;
                        label.AutoSize = true;

                        label.Location = new Point(10, splitContainer4.Panel1.Controls.Count * 10);
                        splitContainer4.Panel1.Controls.Add(label);

                        /*label.Click += (s, e) =>
                        {
                            // Handle click event for the entity
                            // For example, you can show entity properties in a separate panel
                            MessageBox.Show($"Clicked on {entity.Name}");
                        };*/
                    }
                }

            }
        }

        private void UpdateTabControl()
        {
            
        }

        #endregion

        private void list_entities_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

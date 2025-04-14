using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Forms;
using Core;
using Models;
using Management;
using System.Drawing;
using System.Runtime.Versioning;
using MetroFramework.Controls;

namespace Elysynth
{
    public partial class MainWindow : MetroForm
    {
        private SettingsHandler _settingsHandler;
        private Settings _settings;


        private string _currentProjectPath;
        private Project _activeProject;

        private TabPage _activeElementSelectedTabPage;

        public MainWindow()
        {
            InitializeComponent();
            _currentProjectPath = Directory.GetCurrentDirectory();

            _settingsHandler = new SettingsHandler();
            _settings = _settingsHandler.Load(Path.Combine(_currentProjectPath, "settings.bin"));

            if (_settings == null)
            {
                _settings = new Settings();
                _settingsHandler.Save(Path.Combine(_currentProjectPath, "settings.bin"), _settings);
            }
        }

        #region UI Updates
        private void MainWindow_Load(object sender, EventArgs e)
        {
           
        }

        private void UpdateMenuStrip()
        {
            if (_activeProject != null)
            {
                metroLabelAppName.Text = $"{_activeProject.Name} - {_settings.AppName}  {_settings.AppVersion}";
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                projectToolStripMenuItem.Enabled = true;
            }
            else
            {
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                projectToolStripMenuItem.Enabled = false;
            }
        }

        private void UpdateListViewSceneElements()
        {
            listViewSceneElements.Items.Clear();
            listViewSceneElements.HeaderStyle = ColumnHeaderStyle.None;

            listViewSceneElements.Items.Add("");

            foreach (var particle in _activeProject.Particles)
            {
                var item = new ListViewItem(particle.Name, 0);
                listViewSceneElements.Items.Add(item);

            }
        }
        #endregion

        #region File Operations
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new NewProject();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                _activeProject = new Project();
                _activeProject.Name = form.ProjectName;
                _currentProjectPath = form.ProjectLocation;

                ProjectHandler.Save(_currentProjectPath, _activeProject);

                UpdateMenuStrip();
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new OpenFileDialog();
            form.Title = "Select the project file you want to open.";
            form.Filter = "Project Files (*.ely)|*.ely";
            form.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (form.ShowDialog() == DialogResult.OK)
            {
                _currentProjectPath = form.FileName;

                _activeProject = ProjectHandler.Load(_currentProjectPath);

                UpdateMenuStrip();
                UpdateListViewSceneElements();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectHandler.Save(_currentProjectPath, _activeProject);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Title = "Save Project As",
                Filter = "Project Files (*.ely)|*.ely",
                InitialDirectory = _currentProjectPath,
                FileName = _activeProject?.Name + ".ely" 
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                _currentProjectPath = saveFileDialog.FileName;

                ProjectHandler.Save(_currentProjectPath, _activeProject);

                UpdateMenuStrip();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Project Operations
        private void particleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParticlesHandler.AddParticle(new Particle(), _activeProject.Particles);
            UpdateListViewSceneElements();
        }
        #endregion

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listViewSceneElements_Click(object sender, EventArgs e)
        {
            if (this._activeElementSelectedTabPage != null)
            {
                metroTabControl1.TabPages.Remove(this._activeElementSelectedTabPage);
            }

            string selectedElementName = listViewSceneElements.SelectedItems[0].Text;
            Particle selectedParticle = _activeProject.Particles.Find(p => p.Name == selectedElementName);

            _activeElementSelectedTabPage = new TabPage("Particle");
            
            var lblPosX = new MetroLabel
            {
                Text = "Position X",
                Location = new Point(10, 10),
                AutoSize = true
            };

            var textPosX = new MetroTextBox
            {
                Location = new Point(10, 30),
                Width = 100,
                Text = selectedParticle.Position.X.ToString()
            };


            _activeElementSelectedTabPage.Controls.Add(lblPosX);
            _activeElementSelectedTabPage.Controls.Add(textPosX);
            metroTabControl1.TabPages.Add(_activeElementSelectedTabPage);
        }
    }
}

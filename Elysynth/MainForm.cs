using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Models;
using Management;
using System.IO;
using System.Reflection;

// This is a partial class for the MainForm of the Elysynth application.
namespace Elysynth
{
    public partial class MainForm: Form
    {
        private List<List<Tuple<Label, TextBox>>> labelTextBoxLists = new List<List<Tuple<Label, TextBox>>>();


        private Settings _activeSettings;
        private Project _activeProject;
        private string _activeProjectPath;
        private string _baseDirectoryPath;

        private SettingsHandler _settingsHandler = new SettingsHandler();

        public MainForm()
        {
            InitializeComponent();
            _baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            _activeSettings = _settingsHandler.Load(Path.Combine(_baseDirectoryPath, "settings.bin"));

            if (_activeSettings == null)
            {
                _activeSettings = new Settings();
                _settingsHandler.Save(Path.Combine(_baseDirectoryPath, "settings.bin"), _activeSettings);
            }

            Text = $"{_activeSettings.AppName} - {_activeSettings.AppVersion}";
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_activeProject != null)
            {
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
            }
            else
            {
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new NewProjectForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                _activeProject = new Project();
                _activeProject.Name = form.ProjectName;
                string path = Path.Combine(form.ProjectLocation, form.ProjectName + ".ely");
                _activeProjectPath = path;
                ProjectHandler.Save(_activeProjectPath, _activeProject);
                Text = $"{_activeSettings.AppName} - {_activeSettings.AppVersion} - {_activeProject.Name}";
                projectToolStripMenuItem.Enabled = true;    
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Elysynth Project Files (*.ely)|*.ely";
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dialog.Title = "Open Elysynth Project";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = dialog.FileName;
                    _activeProjectPath = path;
                    _activeProject = ProjectHandler.Load(path);
                    projectToolStripMenuItem.Enabled = true;
                    UpdateSceneElementsList();

                    if (_activeProject != null)
                    {
                        Text = $"{_activeSettings.AppName} - {_activeSettings.AppVersion} - {_activeProject.Name}";
                    }
                    else
                    {
                        MessageBox.Show("Failed to load project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectHandler.Save(_activeProjectPath, _activeProject);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Elysynth Project Files (*.ely)|*.ely";
                dialog.InitialDirectory = Directory.GetParent(_activeProjectPath).FullName;
                dialog.Title = "Save Elysynth Project";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = dialog.FileName;
                    _activeProjectPath = path;
                    ProjectHandler.Save(_activeProjectPath, _activeProject);
                }
            }
        }

        private void particleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Particle particle = new Particle();
            int index = 1;

            while (_activeProject.Particles.Any(p => p.Name == $"Particle{index}"))
            {
                index++;
            }
            particle.Name = $"Particle{index}";

            ParticlesHandler.Add(_activeProject, particle);
            UpdateSceneElementsList();
            */

            var form = new AddParticleForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Particle particle = new Particle();
                particle.Name = form.ParticleName;
                particle.Position = new Vector2(form.ParticlePosX, form.ParticlePosY);
                particle.Mass = form.ParticleMass;
                particle.Charge = form.ParticleCharge;
                ParticlesHandler.Add(_activeProject, particle);
            }

            UpdateSceneElementsList();
        }

        private void UpdateSceneElementsList()
        {
            listSceneElements.Items.Clear();
            foreach (var element in _activeProject.Particles)
            {
                listSceneElements.Items.Add(new ListViewItem(element.Name));
            }
        }

        private void listSceneElements_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSceneElements.SelectedItems.Count > 0)
            {
                string selectedItemName = listSceneElements.SelectedItems[0].Text;
                var selectedParticle = _activeProject.Particles.FirstOrDefault(p => p.Name == selectedItemName);

                if (selectedParticle != null)
                {
                    // MessageBox.Show($"Single-clicked: {selectedParticle.Name}", "Single Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AddListParticleProprieties();
                }
            }
        }

        private void listSceneElements_ItemActivate(object sender, EventArgs e)
        {
            if (listSceneElements.SelectedItems.Count > 0)
            {
                string selectedItemName = listSceneElements.SelectedItems[0].Text;

                var selectedParticle = _activeProject.Particles.FirstOrDefault(p => p.Name == selectedItemName);

                if (selectedParticle != null)
                {
                    //MessageBox.Show($"Double-clicked: {selectedParticle.Name}", "Double Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
            }
        }

        private void AddListParticleProprieties()
        {

            panelElementProprieties.Controls.Clear();

            Label lbl = new Label();
            lbl.Text = "Position X:";
            lbl.Location = new Point(3, 7);
            lbl.AutoSize = true;
            panelElementProprieties.Controls.Add(lbl);

            TextBox txt = new TextBox();
            txt.Location = new Point(60,3);
            txt.Width = 20;
            panelElementProprieties.Controls.Add(txt);
        }
    }
}

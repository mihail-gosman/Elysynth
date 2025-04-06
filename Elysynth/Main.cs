using System;
using System.Windows.Forms;
using Core;
using Models;
using Management;
using System.IO;

namespace Elysynth
{
    public partial class Main : Form
    {
        private SettingsHandler _settingsHandler;
        private Settings _settings;
        private ProjectHandler _projectHandler;
        private Project _activeProject;
        private ParticlesHandler _particlesHandler;
        private string _activeProjectPath;

        public Main()
        {
            InitializeComponent();

            _settingsHandler = new SettingsHandler();
            _settingsHandler.SetPath(null);
            _settings = _settingsHandler.Load();

            _projectHandler = new ProjectHandler();

            this.Text = $"{_settingsHandler.ActiveSettings.AppName}  {_settingsHandler.ActiveSettings.AppVersion}";

            // Disable Save until a project is active
            saveToolStripMenuItem.Enabled = false;
            projectToolStripMenuItem.Enabled = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SettingsForm(_settings);

            if (form.ShowDialog() == DialogResult.OK)
            {
                this.Text = $"{_settingsHandler.ActiveSettings.AppName}  {_settingsHandler.ActiveSettings.AppVersion}";
                _settingsHandler.Save();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new NewProject();

            if (form.ShowDialog() == DialogResult.OK)
            {
                _activeProject = new Project();
                _activeProject.Name = form.ProjectName;
                Core.Utilities.Serializer.Instance.Write(form.Path, _activeProject);
                _activeProjectPath = form.Path;

                saveToolStripMenuItem.Enabled = true;
                this.Text = $"{_settingsHandler.ActiveSettings.AppName}  {_settingsHandler.ActiveSettings.AppVersion}  {_activeProject?.Name ?? ""}";
            }
            
            particleToolStripMenuItem.Enabled = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Project Files (*.ely)|*.ely|All Files (*.*)|*.*";
                openFileDialog.Title = "Open Project File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    _activeProject = _projectHandler.GetProjectByPath(filePath);
                    _activeProjectPath = filePath;

                    if (_activeProject != null)
                    {
                        saveToolStripMenuItem.Enabled = true;
                        this.Text = $"{_settingsHandler.ActiveSettings.AppName}  {_settingsHandler.ActiveSettings.AppVersion}  {_activeProject.Name}";
                    }
                }
            }
            projectToolStripMenuItem.Enabled = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_activeProject != null && !string.IsNullOrEmpty(_activeProjectPath))
            {
                _projectHandler.SaveProject(_activeProjectPath, _activeProject);
            }
        }

        private void particleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AddParticle();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _particlesHandler = new ParticlesHandler(_activeProject);
                MessageBox.Show(_activeProject.Name);
                _particlesHandler.AddParticle(form.particle);
                UpdateParticleBoxList();
            }
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void UpdateParticleBoxList()
        {
            if (_activeProject != null)
            {
                particleListBox.Items.Clear();
                foreach (var particle in _activeProject.Particles)
                {
                    particleListBox.Items.Add(particle.Name);
                }
            }
        }
    }
}

using System;
using System.Windows.Forms;
using Core;
using Models;
using Management;
using System.IO;

namespace Elysynth
{
    public partial class Main: Form
    {
        private SettingsHandler _settingsHandler;
        private Settings _settings;

        public Main()
        {
            InitializeComponent();
        
            _settingsHandler = new SettingsHandler();
            _settingsHandler.SetPath(null);
            _settings  = _settingsHandler.Load();
        
            this.Text = $"{_settingsHandler.ActiveSettings.AppName}  {_settingsHandler.ActiveSettings.AppVersion}";
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
            else if (form.DialogResult == DialogResult.Cancel)
            {
                // Do nothing
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Choose a folder to create your new project:";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = dialog.SelectedPath;

                    // You can prompt for a project name here (e.g., with InputBox or a custom dialog)
                    string projectName = "NewProject"; // Replace with user input ideally
                    string projectPath = Path.Combine(selectedPath, projectName);

                    if (!Directory.Exists(projectPath))
                    {
                        Directory.CreateDirectory(projectPath);
                        MessageBox.Show($"Project folder created at:\n{projectPath}", "Project Created");
                    }
                    else
                    {
                        MessageBox.Show("A project with this name already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    _settingsHandler.Save();
                }
            }
        }
    }
}

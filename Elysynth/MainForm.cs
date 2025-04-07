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

// This is a partial class for the MainForm of the Elysynth application.
namespace Elysynth
{
    public partial class MainForm: Form
    {
        private Settings _activeSettings;
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new NewProjectForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                
            }
        }
    }
}

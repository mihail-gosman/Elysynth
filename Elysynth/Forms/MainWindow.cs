using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Forms;
using Core;
using Models;
using Management;

namespace Elysynth
{
    public partial class MainWindow: MetroForm
    {
        private string _currentProjectPath;

        private SettingsHandler _settingsHandler;
        private Settings _settings;

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

        private void MainWindow_Load(object sender, EventArgs e)
        {
            metroLabelAppName.Text += " - " + _settings.AppVersion;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new NewProject();
            form.ShowDialog();
        }
    }
}

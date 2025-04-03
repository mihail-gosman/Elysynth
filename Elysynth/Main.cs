using System;
using System.Windows.Forms;
using Core;
using Models;
using Management;

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
            _settingsHandler.Load();
        
            this.Text = $"{_settingsHandler.ActiveSettings.AppName}  {_settingsHandler.ActiveSettings.AppVersion}";
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

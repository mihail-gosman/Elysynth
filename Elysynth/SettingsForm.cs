using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace Elysynth
{
    public partial class SettingsForm: Form
    {
        private Settings _activeSettings;
        
        public SettingsForm(Settings settings)
        {
            InitializeComponent();
            _activeSettings = settings;

            this.Text = $"{_activeSettings.AppName}  Settings";
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void Apply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}

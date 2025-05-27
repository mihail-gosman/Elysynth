using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Models;

namespace Elysynth
{
    public partial class OptionsForm: MetroForm
    {
        Settings userSettings;
        public OptionsForm(Settings _userSettings)
        {
            userSettings = _userSettings;
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            if (userSettings.AutoSaveInterval)
            {
                chk_autosave.Checked = true;
            }
            else
            {
                chk_autosave.Checked = false;
            }

            num_fileSize.Value = userSettings.MaxFileSize;

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            userSettings.AutoSaveInterval = chk_autosave.Checked;

            if (num_fileSize.Value < 1)
            {
                MessageBox.Show("File size must be at least 1 MB.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            userSettings.MaxFileSize = (int)num_fileSize.Value;

            DialogResult = DialogResult.OK;
        }
    }
}

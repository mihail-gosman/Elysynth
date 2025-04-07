using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elysynth
{
    public partial class NewProjectForm : Form
    {
        public NewProjectForm()
        {
            InitializeComponent();
        }

        private void NewProjectForm_Load(object sender, EventArgs e)
        {
            txtLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProjectName.Text))
            {
                lblInvalidName.Visible = true;
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                lblInvalidLocation.Visible = true;
                return;
            }

            if (!System.IO.Directory.Exists(txtLocation.Text))
            {
                lblInvalidLocation.Visible = true;

            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnFileExplorer_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select the project location";
                folderBrowserDialog.SelectedPath = txtLocation.Text;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtLocation.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void txtProjectName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProjectName.Text))
            {
                lblInvalidName.Visible = true;
            }
            else
            {
                lblInvalidName.Visible = false;
            }
        }

        private void txtLocation_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                lblInvalidLocation.Visible = true;
            }
            else
            {
                lblInvalidLocation.Visible = false;
            }
        }
    }      
}
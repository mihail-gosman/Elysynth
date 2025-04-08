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
        public string ProjectName;
        public string ProjectLocation;

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
                ProjectName = txtProjectName.Text;
                ProjectLocation = txtLocation.Text;
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

        private void txtProjectName_TextChanged(object sender, EventArgs e)
        {
            if (txtProjectName.Text.Length > 0)
            { 
                if (char.IsLetter(txtProjectName.Text[0]))
                {
                    lblInvalidName.Visible = false;
                }
                else
                {
                    lblInvalidName.Visible = true;
                }
            }
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            if (txtLocation.Text.Length > 0)
            {
                if (char.IsLetter(txtLocation.Text[0]))
                {
                    lblInvalidLocation.Visible = false;
                }
                else
                {
                    lblInvalidLocation.Visible = true;
                }
            }
        }
    }
}
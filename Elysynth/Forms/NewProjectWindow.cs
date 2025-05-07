using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Models;
using Management;

namespace Elysynth
{
    public partial class NewProjectWindow: MetroForm
    {
        public Project project = null;
        public string path = string.Empty;
        public NewProjectWindow()
        {
            InitializeComponent();
            txt_projectName.Text = "New Project";
            txt_location.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void NewProjectWindow_Load(object sender, EventArgs e)
        {

        }

        private void btn_fileExplorer_Click(object sender, EventArgs e)
        {
            var fileDialog = new FolderBrowserDialog();
            fileDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_location.Text = fileDialog.SelectedPath;
            }
        }

        private bool ValidateInput()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txt_projectName.Text))
            {
                lbl_invalidName.Visible = true;
                isValid = false;
            }
            else
            {
                lbl_invalidName.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txt_location.Text))
            {
                lbl_invalidLocation.Visible = true;
                isValid = false;
            }
            else
            {
                lbl_invalidLocation.Visible = false;
            }

            return isValid;
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                project = new Project();
                project.Name = txt_projectName.Text;
                path = Path.Combine(txt_location.Text, txt_projectName.Text + ".ely");
                ProjectHandler.Save(path, project);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        
    }
}

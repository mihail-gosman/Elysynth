using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using MetroFramework.Forms;
using Management;
using Models;

namespace Elysynth.UI.NewProjectForm
{
    public partial class NewProjectForm : MetroForm
    {
        private string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        
        public string projectName { get; set; }
        public string projectLocation { get; set; }

        public NewProjectForm()
        {
            InitializeComponent();
        }

        private void NewProjectForm_Load(object sender, EventArgs e)
        {
            txt_name.Text = "NewProject";
            txt_location.Text = documentsPath;
        }

        private void btn_files_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder for the new project";
                folderDialog.ShowNewFolderButton = true;
                folderDialog.SelectedPath = documentsPath;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txt_location.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            
            if (ValidateInput())
            {
                projectName = txt_name.Text;
                projectLocation = txt_location.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidateInput()
        {
            bool nameValid = ValidateName();
            bool locationValid = ValidateLocation();

            return nameValid && locationValid;
        }

        private bool ValidateName()
        {
            lbl_invalidName.Visible = true;

            if (string.IsNullOrEmpty(txt_name.Text))
            {
                return false;
            }

            lbl_invalidName.Visible = false;
            return true;
        }

        private bool ValidateLocation()
        {
            lbl_invalidLocation.Visible = true;

            if (string.IsNullOrEmpty(txt_location.Text))
            {

                return false;
            }

            lbl_invalidLocation.Visible = false;
            return true;
        }
    }
}

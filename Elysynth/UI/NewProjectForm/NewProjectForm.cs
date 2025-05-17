using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using MetroFramework.Forms;

namespace Elysynth.UI.NewProjectForm
{
    public partial class NewProjectForm : MetroForm
    {
        private string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

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

        private void btn_create_Click(object sender, EventArgs e)
        {

        }

        private bool IsFormInputValid()
        {
            if (ValidateName() && ValidateLocation())
                return true; 
            else
                return false;
        }

        private bool ValidateName()
        {
            if (!string.IsNullOrEmpty(txt_name.Text))
            {
                char[] invalidChars = Path.GetInvalidFileNameChars();
                foreach (char c in invalidChars)
                {
                    if (txt_name.Text.Contains(c))
                    {
                        lbl_invalidName.Visible = true;
                        txt_name.Focus();
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        private bool ValidateLocation()
        {
            return true;
        }
    }
}

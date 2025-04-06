using System;
using System.Drawing;
using System.Windows.Forms;

namespace Elysynth
{
    public partial class NewProject : Form
    {
        public string ProjectName;
        public string Path;
        public string DefaultPath;

        Label lblMessage = new Label();

        public NewProject()
        {
            DefaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            InitializeComponent();
        }

        private void NewProject_Load(object sender, EventArgs e)
        {
            txtLocation.Text = DefaultPath;

            // Setup lblMessage
            lblMessage.AutoSize = true;
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = "";
            lblMessage.Visible = false;

            // Position lblMessage under txtName
            lblMessage.Location = new Point(txtName.Left, txtName.Bottom + 5);

            // Add to form
            this.Controls.Add(lblMessage);
        }

        private void btnOpenFileExplorer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                lblMessage.Text = "Please enter a name for the project first.";
                lblMessage.Visible = true;
                return;
            }
            else
            {
                lblMessage.Visible = false;
            }

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a project directory";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    txtLocation.Text = System.IO.Path.Combine(selectedPath, txtName.Text);
                    Path = txtLocation.Text += ".ely";
                    lblMessage.Text = "";
                    ProjectName = txtName.Text;
                    lblMessage.Visible = false;
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Optional: Validate name and path here
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ProjectName = txtName.Text;
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            Path = txtLocation.Text;
        }
    }
}

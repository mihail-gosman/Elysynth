using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Core;
using Models;
using Management;

namespace Elysynth
{
    public partial class NewProject: MetroForm
    {
        public string ProjectName
        {
            get { return metroTextBoxName.Text; }
        }

        public string ProjectLocation
        {
            get { return metroTextBoxLocation.Text; }
        }

        public NewProject()
        {
            InitializeComponent();
        }

        private void NewProject_Load(object sender, EventArgs e)
        {
            metroLabelInvalidName.Visible = false;
            metroLabelInvalidLocation.Visible = false;
            metroTextBoxLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void metroButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void metroTextBoxName_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBoxName.Text.Length == 0 || !char.IsLetter(metroTextBoxName.Text[0]))
            {
                metroLabelInvalidName.Visible = true;
            }
            else
            {
                metroLabelInvalidName.Visible = false;
            }
        }

        private void metroTextBoxLocation_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBoxLocation.Text.Length == 0 || !System.IO.Directory.Exists(metroTextBoxLocation.Text))
            {
                metroLabelInvalidLocation.Visible = true;
            }
            else
            {
                metroLabelInvalidLocation.Visible = false;
            }
        }

        private void metroButtonFilesExplorer_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select the folder where you want to create the project.";
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Elysynth";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                metroTextBoxLocation.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void metroButtonCreate_Click(object sender, EventArgs e)
        {
            if (metroLabelInvalidLocation.Visible)
            {
                MessageBox.Show("Please select a valid location for the project.");
                return;
            }
            else if (metroLabelInvalidName.Visible)
            {
                MessageBox.Show("Please select a valid name for the project.");
                return;
            }
            else
            { 
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        
    }
}

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

namespace Elysynth
{
    public partial class NewProject: MetroForm
    {
        public NewProject()
        {
            InitializeComponent();
        }

        private void NewProject_Load(object sender, EventArgs e)
        {
            metroLabelInvalidName.Visible = false;
            metroLabelInvalidLocation.Visible = false;
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

        private void metroTextBoxName_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonCreate_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBoxLocation_Click(object sender, EventArgs e)
        {

        }

        private void metroLabelLocation_Click(object sender, EventArgs e)
        {

        }

        private void metroLabelInvalidName_Click(object sender, EventArgs e)
        {

        }

        private void metroLabelName_Click(object sender, EventArgs e)
        {

        }

        private void metroLabelInvalidLocation_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonFilesExplorer_Click(object sender, EventArgs e)
        {

        }
    }
}

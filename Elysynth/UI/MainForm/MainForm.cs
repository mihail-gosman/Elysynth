using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Models;
using Management;
using Engine;

namespace Elysynth.UI.MainForm
{
    public partial class MainForm: MetroForm
    {

        private string exeDirectory = Path.GetDirectoryName(Application.ExecutablePath);

        Settings userSettings;
        Project activeProject;
        Project activeProjectCopy;
        Simulation simulation;

        string activeProjectPath;

        object selectedEntity;

        Timer timer = new Timer();

        public MainForm()
        {
            InitializeComponent();
            userSettings = Management.SettingsHandler.Load(exeDirectory + "settings.bin");
            if (userSettings == null)
            {
                userSettings = new Settings();
                Management.SettingsHandler.Save(Path.Combine(exeDirectory, "settings.bin"), userSettings);
            }

            panelSimulation.Paint += PanelSimulationPaint;
           

            timer.Interval = 1000 / 60;
            timer.Tick += UpdateSimulation;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lbl_title.Text += "  " + userSettings.AppVersion;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new NewProjectForm.NewProjectForm();
            if(form.ShowDialog() == DialogResult.OK)
            {
                activeProject = new Project();
                activeProject.Name = form.projectName;
                activeProjectPath = Path.Combine(form.projectLocation, activeProject.Name + ".ely");
                ProjectHandler.Save(activeProjectPath, activeProject);

                UpdateSimulationPanel();

                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                projectToolStripMenuItem.Enabled = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a file";
            openFileDialog.Filter = "ELY files (*.ely)|*.ely|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                activeProjectPath = selectedFilePath;
                activeProject = ProjectHandler.Load(activeProjectPath);
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                projectToolStripMenuItem.Enabled = true;
            }

            UpdateSimulationPanel();
            UpdateEntitiesPanel();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectHandler.Save(activeProjectPath, activeProject);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SaveFileDialog();
            form.Title = "Save Project As";
            form.Filter = "Elysynth Project (*.ely)|*.ely";
            form.DefaultExt = "ely";
            form.AddExtension = true;


            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(form.FileName);
                ProjectHandler.Save(form.FileName, activeProject);
            }
        }

        

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeProjectCopy = Cloner.DeepClone(activeProject);
            simulation = new Simulation(activeProject);
            UpdateEntityTab(null);
            timer.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Stop();
            activeProject = Cloner.DeepClone(activeProjectCopy);
            UpdateSimulationPanel();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

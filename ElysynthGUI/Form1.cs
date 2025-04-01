using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Core;
using Models;
using Management;

namespace ElysynthGUI
{
    public partial class Form1 : Form
    {
        private Management.ProjectHandler ProjectHandler = new ProjectHandler();
        private Management.SettingsHandler SettingsHandler = new SettingsHandler();

        private Label _lblProject;
        private Label[] _lblsProjects;

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;

        public Form1()
        {
            InitializeComponent();
            ProjectHandler.SetPath(null);
            SettingsHandler.SetPath(null);

            
            this.Size = new Size(500, 300); 
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(110, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.LimeGreen;
            this.Text = "Elysynth";

            _lblProject = new Label();
            _lblProject.Width = LATIME_CONTROL;
            _lblProject.Text = "Projects";
            _lblProject.Left = DIMENSIUNE_PAS_X;
            _lblProject.ForeColor = Color.DarkGreen;
            this.Controls.Add(_lblProject);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowProjects();
        }

        private void ShowProjects()
        {
            string[] projectNames = ProjectHandler.GetProjectsNames();

            int yOffset = DIMENSIUNE_PAS_Y; 

            _lblsProjects = new Label[projectNames.Length];

            for (int i = 0; i < projectNames.Length; i++)
            {
                
                _lblsProjects[i] = new Label();
                _lblsProjects[i].Width = 400;
                _lblsProjects[i].Text = Path.GetFileName(projectNames[i]);
                _lblsProjects[i].Left = DIMENSIUNE_PAS_X + LATIME_CONTROL; 
                _lblsProjects[i].Top = yOffset;
                _lblsProjects[i].ForeColor = Color.DarkGreen;
                this.Controls.Add(_lblsProjects[i]);

                yOffset += DIMENSIUNE_PAS_Y;
            }
        }
    }
}

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

        private Label _lblProjects;
        private Label[] _lblsProjects;

        private const int CONTROL_WIDTH = 120;
        private const int Y_OFFSET = 30;
        private const int X_OFFSET = 150;

        public Form1()
        {
            InitializeComponent();
            ProjectHandler.SetPath(null);
            SettingsHandler.SetPath(null);

            // Window Settings
            this.Size = new Size(500, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Arial", 9, FontStyle.Regular);
            this.ForeColor = Color.Black;
            this.Text = "Elysynth";

            // Setup "Projects" label
            _lblProjects = new Label
            {
                Width = CONTROL_WIDTH,
                Text = "Projects:",
                Left = X_OFFSET,
                Top = 20,
                ForeColor = Color.Black,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            this.Controls.Add(_lblProjects);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowProjects();
        }

        private void ShowProjects()
        {
            string[] projectNames = ProjectHandler.GetProjectsNames();
            int yOffset = Y_OFFSET + 20;

            _lblsProjects = new Label[projectNames.Length];

            for (int i = 0; i < projectNames.Length; i++)
            {
                _lblsProjects[i] = new Label
                {
                    Width = 350,
                    Text = Path.GetFileName(projectNames[i]),
                    Left = X_OFFSET + CONTROL_WIDTH,
                    Top = yOffset,
                    ForeColor = Color.Black,
                    Font = new Font("Arial", 9, FontStyle.Regular)
                };
                this.Controls.Add(_lblsProjects[i]);

                yOffset += Y_OFFSET;
            }
        }
    }
}

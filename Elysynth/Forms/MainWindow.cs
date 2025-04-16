using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Forms;
using Core;
using Models;
using Management;
using System.Drawing;
using System.Runtime.Versioning;
using MetroFramework.Controls;

namespace Elysynth
{
    public partial class MainWindow : MetroForm
    {
        private SettingsHandler _settingsHandler;
        private Settings _settings;


        private string _currentProjectPath;
        private Project _activeProject;

        private TabPage _activeElementSelectedTabPage;

        public MainWindow()
        {
            InitializeComponent();
            _currentProjectPath = Directory.GetCurrentDirectory();

            _settingsHandler = new SettingsHandler();
            _settings = _settingsHandler.Load(Path.Combine(_currentProjectPath, "settings.bin"));

            if (_settings == null)
            {
                _settings = new Settings();
                _settingsHandler.Save(Path.Combine(_currentProjectPath, "settings.bin"), _settings);
            }
        }

        #region UI Updates
        private void MainWindow_Load(object sender, EventArgs e)
        {
           
        }

        private void UpdateMenuStrip()
        {
            if (_activeProject != null)
            {
                metroLabelAppName.Text = $"{_activeProject.Name} - {_settings.AppName}  {_settings.AppVersion}";
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                projectToolStripMenuItem.Enabled = true;
            }
            else
            {
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                projectToolStripMenuItem.Enabled = false;
            }
        }

        private void UpdateListViewSceneElements()
        {
            listViewSceneElements.Items.Clear();
            listViewSceneElements.HeaderStyle = ColumnHeaderStyle.None;

            listViewSceneElements.Items.Add("");

            foreach (var particle in _activeProject.Particles)
            {
                var item = new ListViewItem(particle.Name, 0);
                listViewSceneElements.Items.Add(item);

            }
        }
        #endregion

        #region File Operations
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new NewProject();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                _activeProject = new Project();
                _activeProject.Name = form.ProjectName;
                _currentProjectPath = Path.Combine(form.ProjectLocation, form.ProductName);
                MessageBox.Show($"Project created at {form.ProjectLocation}", "Project Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProjectHandler.Save(_currentProjectPath, _activeProject);

                UpdateMenuStrip();
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new OpenFileDialog();
            form.Title = "Select the project file you want to open.";
            form.Filter = "Project Files (*.ely)|*.ely";
            form.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (form.ShowDialog() == DialogResult.OK)
            {
                _currentProjectPath = form.FileName;

                _activeProject = ProjectHandler.Load(_currentProjectPath);

                UpdateMenuStrip();
                UpdateListViewSceneElements();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectHandler.Save(_currentProjectPath, _activeProject);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Title = "Save Project As",
                Filter = "Project Files (*.ely)|*.ely",
                InitialDirectory = _currentProjectPath,
                FileName = _activeProject?.Name + ".ely" 
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                _currentProjectPath = saveFileDialog.FileName;

                ProjectHandler.Save(_currentProjectPath, _activeProject);

                UpdateMenuStrip();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Project Operations
        private void particleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParticlesHandler.AddParticle(new Particle(), _activeProject.Particles);
            UpdateListViewSceneElements();
        }
        #endregion

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        // Next Steps:
        // 1. Implement the `settingsToolStripMenuItem_Click` method to allow users to modify application settings.
        // 2. Add error handling for cases where `_activeProject` or `listViewSceneElements.SelectedItems` is null in `listViewSceneElements_Click`.
        // 3. Refactor `listViewSceneElements_Click` to dynamically handle different types of elements (e.g., Fields, Particles).
        // 4. Add functionality to save changes made in the dynamically created tab page back to the `_activeProject` object.
        // 5. Ensure proper disposal of dynamically created controls to avoid memory leaks.
        private void listViewSceneElements_Click(object sender, EventArgs e)
        {
            if (this._activeElementSelectedTabPage != null)
            {
                metroTabControl1.TabPages.Remove(this._activeElementSelectedTabPage);
            }

            string selectedElementName = listViewSceneElements.SelectedItems[0].Text;
            Particle selectedParticle = _activeProject.Particles.Find(p => p.Name == selectedElementName);

            _activeElementSelectedTabPage = new TabPage("Particle");
            _activeElementSelectedTabPage.BackColor = Color.White;

            var lblName = new MetroLabel { Text = "Name", Location = new Point(10, 10), AutoSize = true };
            var textName = new MetroTextBox { Location = new Point(10, 30), Width = 200, Text = selectedParticle.Name };

            var lblPosX = new MetroLabel { Text = "Position X", Location = new Point(10, 60), AutoSize = true };
            var textPosX = new MetroTextBox { Location = new Point(10, 80), Width = 100, Text = selectedParticle.Position.X.ToString() };

            var lblPosY = new MetroLabel { Text = "Position Y", Location = new Point(10, 110), AutoSize = true };
            var textPosY = new MetroTextBox { Location = new Point(10, 130), Width = 100, Text = selectedParticle.Position.Y.ToString() };

            var lblVelocityX = new MetroLabel { Text = "Velocity X", Location = new Point(10, 160), AutoSize = true };
            var textVelocityX = new MetroTextBox { Location = new Point(10, 180), Width = 100, Text = selectedParticle.Velocity.X.ToString() };

            var lblVelocityY = new MetroLabel { Text = "Velocity Y", Location = new Point(10, 210), AutoSize = true };
            var textVelocityY = new MetroTextBox { Location = new Point(10, 230), Width = 100, Text = selectedParticle.Velocity.Y.ToString() };

            var lblMass = new MetroLabel { Text = "Mass", Location = new Point(10, 260), AutoSize = true };
            var textMass = new MetroTextBox { Location = new Point(10, 280), Width = 100, Text = selectedParticle.Mass.ToString() };

            var lblCharge = new MetroLabel { Text = "Charge", Location = new Point(10, 310), AutoSize = true };
            var textCharge = new MetroTextBox { Location = new Point(10, 330), Width = 100, Text = selectedParticle.Charge.ToString() };

            // Event handlers to update the particle when text changes
            textName.TextChanged += (s, args) => selectedParticle.Name = textName.Text;
            textPosX.TextChanged += (s, args) =>
            {
                if (float.TryParse(textPosX.Text, out float posX))
                {
                    selectedParticle.Position = new Vector2(posX, selectedParticle.Position.Y);
                }
            };
            textPosY.TextChanged += (s, args) =>
            {
                if (float.TryParse(textPosY.Text, out float posY))
                {
                    selectedParticle.Position = new Vector2(selectedParticle.Position.X, posY);
                }
            };
            textVelocityX.TextChanged += (s, args) =>
            {
                if (float.TryParse(textVelocityX.Text, out float velX))
                {
                    selectedParticle.Velocity = new Vector2(velX, selectedParticle.Velocity.Y);
                }
            };
            textVelocityY.TextChanged += (s, args) =>
            {
                if (float.TryParse(textVelocityY.Text, out float velY))
                {
                    selectedParticle.Velocity = new Vector2(selectedParticle.Velocity.X, velY);
                }
            };
            textMass.TextChanged += (s, args) =>
            {
                if (double.TryParse(textMass.Text, out double mass))
                {
                    selectedParticle.Mass = mass;
                }
            };
            textCharge.TextChanged += (s, args) =>
            {
                if (double.TryParse(textCharge.Text, out double charge))
                {
                    selectedParticle.Charge = charge;
                }
            };

            _activeElementSelectedTabPage.Controls.Add(lblName);
            _activeElementSelectedTabPage.Controls.Add(textName);
            _activeElementSelectedTabPage.Controls.Add(lblPosX);
            _activeElementSelectedTabPage.Controls.Add(textPosX);
            _activeElementSelectedTabPage.Controls.Add(lblPosY);
            _activeElementSelectedTabPage.Controls.Add(textPosY);
            _activeElementSelectedTabPage.Controls.Add(lblVelocityX);
            _activeElementSelectedTabPage.Controls.Add(textVelocityX);
            _activeElementSelectedTabPage.Controls.Add(lblVelocityY);
            _activeElementSelectedTabPage.Controls.Add(textVelocityY);
            _activeElementSelectedTabPage.Controls.Add(lblMass);
            _activeElementSelectedTabPage.Controls.Add(textMass);
            _activeElementSelectedTabPage.Controls.Add(lblCharge);
            _activeElementSelectedTabPage.Controls.Add(textCharge);

            metroTabControl1.TabPages.Add(_activeElementSelectedTabPage);
        }
    }
}
